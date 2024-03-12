using Application.Data;
using Domain.Events;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence;

public class ApplicationDbContext: DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher _publiser;

    public ApplicationDbContext(DbContextOptions options, IPublisher publiser): base (options)
    {
        _publiser = publiser ?? throw new ArgumentNullException(nameof(publiser));
    }

    public DbSet<Event> Events{get; set;}

   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
        .Select(e=> e.Entity)
        .Where(e=> e.GetDomainEvents().Any())
        .SelectMany(e=> e.GetDomainEvents());

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await _publiser.Publish(domainEvent,cancellationToken);
        }
        return result;
    }

  
}