using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.DependencyResolver
{
    public class DependencyResolverService
    {
        public static void RegisterInfrastructureLayer(IServiceCollection services_)
        {
            services_.AddScoped<IBeatRepository, BeatRepository>();
            services_.AddScoped<IUserRepository, UserRepository>();
            services_.AddScoped<IDbRepository, DbRepository>();
            services_.AddScoped<ILoginRepository, LoginRepository>();
        }
    }
}
