using System;
using System.Text;
using capredv2.backend.api.Constants;
using capredv2.backend.api.Middlewares;
using capredv2.backend.domain.DatabaseEntities;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.DataContexts.UnitOfWork;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Identity;
using capredv2.backend.domain.Identity.Interfaces;
using capredv2.backend.domain.Repositories;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services;
using capredv2.backend.domain.Services.Interfaces;
using capredv2.backend.domain.Validators;
using capredv2.backend.domain.Validators.DomainEntities.CapRedV2LoginDTOValidators;
using capredv2.backend.domain.Validators.DomainEntities.CapRedV2SignUpDTOValidators;
using capredv2.backend.domain.Validators.DomainEntities.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace capredv2.backend.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DB Context
            services.AddDbContext<CapRedV2Context>(
                options => options.UseSqlServer(Configuration.GetConnectionString("CapREDV2SQLDatabase"),
                    b => b.MigrationsAssembly("capredv2.backend.domain")));

            //Identity
            services.AddIdentity<CapRedV2User, IdentityRole>()
                .AddEntityFrameworkStores<CapRedV2Context>();

            //Hangfire
            services.AddHangfire(
                x => x.UseSqlServerStorage(Configuration.GetConnectionString("HangfireJobPersistence")));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Jwt";
                options.DefaultChallengeScheme = "Jwt";
            }).AddJwtBearer("Jwt", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = Configuration["TokenSettings:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["TokenSettings:Issuer"],

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConstants.TokenSalt)),

                    ValidateLifetime = true, //validate the expiration and not before values in the token

                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            // configure identity options
            //TODO FS: Discuss this
            services.Configure<IdentityOptions>(o =>
            {
                o.SignIn.RequireConfirmedEmail = false;
            });

            services.AddScoped<ICapRedV2UserManager<CapRedV2User>, CapRedV2UserManager>();
            services.AddScoped<ICapRedV2SignInManager<CapRedV2User>, CapRedV2SignInManager>();

            services.AddScoped<IDomainEntitiesValidator<CapRedV2UserLoginDTO>, LoginEmailValidator>();
            services.AddScoped<IDomainEntitiesValidator<CapRedV2UserLoginDTO>, LoginPasswordValidator>();
            services.AddScoped<IDomainEntitiesValidator<CapRedV2UserSignUpDTO>, SignUpInvalidEmailValidator>();
            services.AddScoped<IDomainEntitiesValidator<CapRedV2UserSignUpDTO>, SignUpPasswordConfirmPasswordMatchValidator>();
            services.AddScoped<IDomainEntitiesValidator<CapRedV2UserSignUpDTO>, SignUpPasswordValidator>();

            services.AddScoped<ValidatorEngine<CapRedV2UserLoginDTO>, ValidatorEngine<CapRedV2UserLoginDTO>>();
            services.AddScoped<ValidatorEngine<CapRedV2UserSignUpDTO>, ValidatorEngine<CapRedV2UserSignUpDTO>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectInformationRepository, ProjectInformationRepository>();
            services.AddScoped<IProjectInvoiceRepository, ProjectInvoiceRepository>();
            services.AddScoped<ICapitalPlanRepository, CapitalPlanRepository>();
            services.AddScoped<ICoupaImporterRepository, CoupaImporterRepository>();
            services.AddScoped<IProjectPurchaseOrderRepository, ProjectPurchaseOrderRepository>();
            services.AddScoped<IProjectRequisitionRepository, ProjectRequisitionRepository>();
            services.AddScoped<IDropdownRepository, DropdownRepository>();

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectInformationService, ProjectInformationService>();
            services.AddScoped<ICapitalPlanService, CapitalPlanService>();
            services.AddScoped<ICoupaImporterService, CoupaImporterService>();
            services.AddScoped<IProjectPurchaseOrderService, ProjectPurchaseOrderService>();
            services.AddScoped<IProjectRequisitionService, ProjectRequisitionService>();
            services.AddScoped<IDropdownService, DropdownService>();

            services.AddScoped<IUserService, UserService>();


            services.AddCors(options => options.AddPolicy("ApiCorsPolicys", builder =>
            {
                builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (!serviceScope.ServiceProvider.GetService<CapRedV2Context>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<CapRedV2Context>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<CapRedV2Context>().Seed();
                }
            }
            app.UseSwagger();
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseErrorHandlingMiddleware();

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseCors("ApiCorsPolicys");
            app.UseMvc();
        }
    }
}
