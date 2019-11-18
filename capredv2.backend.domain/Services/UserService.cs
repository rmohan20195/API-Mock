using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using capredv2.backend.domain.DatabaseEntities;
using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Exceptions;
using capredv2.backend.domain.Identity.Interfaces;
using capredv2.backend.domain.Services.Interfaces;
using capredv2.backend.domain.Validators;
using Microsoft.AspNetCore.Identity;

namespace capredv2.backend.domain.Services
{
    public class UserService : IUserService
    {
        private readonly ICapRedV2UserManager<CapRedV2User> _userManager;
        private readonly ICapRedV2SignInManager<CapRedV2User> _signInManager;
        private readonly ValidatorEngine<CapRedV2UserSignUpDTO> _signUpValidatorEngine;
        private readonly ValidatorEngine<CapRedV2UserLoginDTO> _loginValidatorEngine;

        public UserService(ICapRedV2UserManager<CapRedV2User> userManager, ICapRedV2SignInManager<CapRedV2User> signInManager, ValidatorEngine<CapRedV2UserSignUpDTO> signUpValidatorEngine, ValidatorEngine<CapRedV2UserLoginDTO> loginValidatorEngine)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _signUpValidatorEngine = signUpValidatorEngine ?? throw new ArgumentNullException(nameof(signUpValidatorEngine));
            _loginValidatorEngine = loginValidatorEngine ?? throw new ArgumentNullException(nameof(loginValidatorEngine));
        }

        public async Task<IdentityResult> RegisterAsync(CapRedV2UserSignUpDTO capRedV2UserSignUpDTO)
        {
            _signUpValidatorEngine.Validate(capRedV2UserSignUpDTO);

            var user = new CapRedV2User
            {
                UserName = capRedV2UserSignUpDTO.Email,
                Email = capRedV2UserSignUpDTO.Email
            };

            return await _userManager.CreateAsync(user, capRedV2UserSignUpDTO.Password);
        }

        public async Task<Tuple<CapRedV2User, SignInResult>> LoginAsync(CapRedV2UserLoginDTO capRedV2UserLoginDTO)
        {
            _loginValidatorEngine.Validate(capRedV2UserLoginDTO);

            var user = await _userManager.FindByNameAsync(capRedV2UserLoginDTO.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, capRedV2UserLoginDTO.Password))
                throw new BusinessValidationException("Invalid Login and/or password");

            var signInResult = await _signInManager.PasswordSignInAsync(user, capRedV2UserLoginDTO.Password,
                true, false);

            return new Tuple<CapRedV2User, SignInResult>(user, signInResult);
        }

        public async Task<IList<string>> GetRolesAsync(CapRedV2User user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}
