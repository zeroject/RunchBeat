using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyResolver
{
    public class DependencyResolverService
    {
        public static void REGISTERINFRASTRUCTURELAYER(IServiceCollection services_)
        {
            services_.AddScoped<IBeatRepository, BeatRepository>();
            services_.AddScoped<IUserRepository, UserRepository>();
            services_.AddScoped<IDbRepository, DbRepository>();
        }
    }
}
