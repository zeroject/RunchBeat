using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public class DbContext(DbContextOptions<DbContext> options, ServiceLifetime serviceLifetime) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //User MODEL BUILDER
        //Auto generate ID
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

        //Beat MODEL BUILDER
        //Auto generate ID
        modelBuilder.Entity<Beat>()
            .Property(w => w.Id)
            .ValueGeneratedOnAdd();
        //Add One To Many Relationship
        modelBuilder.Entity<Beat>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(w => w.UserId);
    }

    //Mapping to entity classes
    public DbSet<Beat> BeatEntries { get; set; }
    public DbSet<User> _userEntries { get; set; }
}