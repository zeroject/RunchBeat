using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options_, ServiceLifetime service_) : base(options_)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder_)
        {
            //User MODEL BUILDER
            //Auto generate ID
            modelBuilder_.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            // Set email property to unique
            modelBuilder_.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            //Set username property to unique
            modelBuilder_.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            //Beat MODEL BUILDER
            //Auto generate ID
            modelBuilder_.Entity<Beat>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();
            //Add One To Many Relationship & cascade on user delete
            modelBuilder_.Entity<Beat>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
        }

        //Mapping to entity classes
        public DbSet<Beat> _beatEntries { get; set; }
        public DbSet<User> _userEntries { get; set; }
    }
}