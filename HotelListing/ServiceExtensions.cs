using HotelListing.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HotelListing
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUser>(op=> op.User.RequireUniqueEmail = true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var issuer = configuration.GetSection("JwtSettings").GetSection("Issuer").Value;
            var key = configuration.GetSection("JwtSettings").GetSection("ApiKey").Value;

            services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(op => op.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidIssuer = issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            });
        }
    }
}
