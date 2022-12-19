using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver
{
    public class DependencyResolverService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services_"></param>
        public static void RegisterApplicationLayer(IServiceCollection services_)
        {
            services_.AddScoped<IBeatService, BeatService>();
            services_.AddScoped<IUserService, UserService>();
            services_.AddScoped<IDbService, DbService>();
            services_.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
