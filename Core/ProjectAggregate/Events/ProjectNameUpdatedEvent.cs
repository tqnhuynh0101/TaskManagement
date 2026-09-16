using Ardalis.SharedKernel;
using Core.ProjectAggregate;

namespace Core.ProjectAggregate.Events;

public sealed class ProjectNameUpdatedEvent(Project project) : DomainEventBase
{
    public Project Project { get; init; } = project;
}
