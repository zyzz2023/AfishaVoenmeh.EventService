using AfishaVoenmeh.EventService.Domain.EventAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AfishaVoenmeh.EventService.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) // Необходимо сделать конфигурации !!!
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}