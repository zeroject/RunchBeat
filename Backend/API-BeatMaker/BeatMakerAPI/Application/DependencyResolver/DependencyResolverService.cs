using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DependencyResolver
{
    public class DependencyResolverService
    {
        public static void REGISTERAPPLICATIONLAYER(IServiceCollection services_)
        {
            services_.AddScoped<IBeatService, BeatService>();
            services_.AddScoped<IUserService, UserService>();
            services_.AddScoped<IDbService, DbService>();
        }
    }
}
