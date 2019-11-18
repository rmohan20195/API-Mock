using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using capredv2.backend.api.Constants;
using capredv2.backend.domain.DatabaseEntities;
using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace capredv2.backend.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        [Authorize]
        public async Task<IActionResult> Register([FromBody]CapRedV2UserSignUpDTO capRedV2UserSignUpDTO)
        {
            if(capRedV2UserSignUpDTO == null) return BadRequest("All fields are required.");

            var userCreationResult = await _userService.RegisterAsync(capRedV2UserSignUpDTO);
            if (userCreationResult.Succeeded) return Ok();

            var errors = userCreationResult.Errors.Select(x => $"[{x.Code}] {x.Description}");
            return BadRequest($"An error occurred when creating the user, see nested errors - {errors}");
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Token([FromBody]CapRedV2UserLoginDTO capRedV2UserLoginDTO)
        {
            var userSignInResult = await _userService.LoginAsync(capRedV2UserLoginDTO);

            if (!userSignInResult.Item2.Succeeded) return BadRequest("Invalid Login and/or password");

            var roles = await _userService.GetRolesAsync(userSignInResult.Item1);

            return new ObjectResult(GenerateToken(userSignInResult.Item1, roles, _configuration));
        }

        private static object GenerateToken(CapRedV2User user, IEnumerable<string> roles, IConfiguration configuration)
        {
            var issuedOn = DateTime.Now;
            var expiration = DateTime.Now.AddDays(14);
            var enumerableOfRoles = roles as string[] ?? roles.ToArray();
            var rolesClaim = enumerableOfRoles.Any() ? enumerableOfRoles.Aggregate((i, j) => i + "," + j) : string.Empty;

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, rolesClaim),
                new Claim(JwtRegisteredClaimNames.Aud, configuration["TokenSettings:Audience"]),
                new Claim(JwtRegisteredClaimNames.Iss, configuration["TokenSettings:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(issuedOn).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(expiration).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConstants.TokenSalt)),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                token_type = "bearer JWT",
                issuedOn,
                expiration
            };
        }
    }
}
