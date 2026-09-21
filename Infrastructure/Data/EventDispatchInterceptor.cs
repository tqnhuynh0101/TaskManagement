using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Data;

public class EventDispatchInterceptor(IDomainEventDispatcher domainEventDispatcher) : SaveChangesInterceptor
{
    private readonly IDomainEventDispatcher _domainEventDispatcher = domainEventDispatcher;

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        if (context is not AppDbContext appDbContext)
        {
            return await base.SavingChangesAsync(eventData, result, cancellationToken).ConfigureAwait(false);
        }

        var entitiesWithEvents = appDbContext.ChangeTracker.Entries<HasDomainEventsBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _domainEventDispatcher.DispatchAndClearEvents(entitiesWithEvents);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

}
