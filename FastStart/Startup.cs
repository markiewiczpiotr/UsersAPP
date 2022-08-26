using FastStart.Entities;
using FastStart.Middleware;
using FastStart.Migrations;
using FastStart.Models;
using FastStart.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using FastStart.Authorization;
using Microsoft.AspNetCore.Authorization;
using FastStart.Validators;
using Microsoft.EntityFrameworkCore;

namespace FastStart
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            var authenticationSettings = new AuthenticationSettings();

            Configuration.GetSection("Authentication").Bind(authenticationSettings);

            services.AddSingleton(authenticationSettings);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AtLeast18", builder => builder.AddRequirements(new MinimumAgeRequirement(18)));
            });
            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
            services.AddControllers().AddFluentValidation();
            services.AddDbContext<UsersDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("UsersDbConnection")));
            services.AddScoped<UsersSeeder>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IUserService, UserService>();
            //       services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPasswordHasher<Users>, PasswordHasher<Users>>();
            services.AddScoped<IValidator<CreateUsersDTO>, UserValidatorDTO>();
            services.AddScoped<ErrorHandlingMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UsersSeeder seeder)
        {
            app.UseResponseCaching();
            app.UseStaticFiles();
            seeder.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
