using FamilyTree.Domain.Persons;
using FamilyTree.Domain.Trees;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Infrastructure.Databases;

public sealed class EntityFrameworkDbContext(DbContextOptions<EntityFrameworkDbContext> options) : DbContext(options)
{
    public DbSet<Tree> Trees { get; set; }
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityFrameworkDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
