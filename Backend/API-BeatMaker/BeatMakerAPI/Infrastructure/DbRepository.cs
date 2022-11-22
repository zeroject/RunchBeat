using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DbRepository : IDbRepository
    {
        private DbContextOptions<DbContext> _options;
        public DbRepository()
        {
            _options = new DbContextOptionsBuilder<DbContext>().UseSqlite("").Options;
        }

        public void RecreateDb()
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
