using HS14JWT.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HS14JWT.Extentions;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<JwtContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));
        services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<JwtContext>().AddDefaultTokenProviders();
        return services;
    }
}
