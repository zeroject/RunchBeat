﻿using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public class BeatRepository : IBeatRepository
    {
        private DbContextOptions<DbContext> _options;
        public BeatRepository()
        {
            _options = new DbContextOptionsBuilder<DbContext>().UseSqlite("Data Source = db.db").Options;
        }

        public List<Beat> GetAllBeatsFromUser(int userId_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                return (context._beatEntries.Where(x => x.UserId == userId_).ToList() ?? throw new KeyNotFoundException("Could not find User"));
            }
        }

        public Beat CreateNewBeat(Beat beat_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Transient))
            {
                _ = context._beatEntries.Add(beat_) ?? throw new Exception("Could not create beat in database"); ;
                context.SaveChanges();
                return beat_;
            }
        }

        public Beat UpdateBeat(Beat beat_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                context._beatEntries.Update(beat_);
                context.SaveChanges();
                return beat_;
            }
        }

        public void DeleteBeat(int id_)
        {
            using (var context = new DbContext(_options, ServiceLifetime.Scoped))
            {
                Beat beatToDelete = context._beatEntries.Find(id_);
                context._beatEntries.Remove(beatToDelete);
                context.SaveChanges();
            }
        }
    }
}
