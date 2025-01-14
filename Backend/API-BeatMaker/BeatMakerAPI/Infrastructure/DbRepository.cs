﻿using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public class DbRepository : IDbRepository
    {
        private DbContextOptions<DbContext> _options;
        public DbRepository()
        {
            _options = new DbContextOptionsBuilder<DbContext>().UseSqlite("Data Source = db.db").Options;
        }
        /// <summary>
        /// Deletes the Database if there is one, then creates a new one.
        /// </summary>
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
