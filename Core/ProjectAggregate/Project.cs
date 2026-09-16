using Ardalis.SharedKernel;
using Core.Events;

namespace Core.ProjectAggregate;

public class Project(ProjectName name) : EntityBase<Project, ProjectId>, IAggregateRoot
{
    public ProjectName Name { get; private set; } = name;
    public ProjectDescription Description { get; private set; }

    public Project UpdateName(ProjectName newName)
    {
        if (newName == Name) return this;
        Name = newName;
        RegisterDomainEvent(new ProjectNameUpdatedEvent(this));
        return this;
    }
    public Project UpdateDescription(ProjectDescription newDescription)
    {
        if (newDescription == Description) return this;
        Description = newDescription;
        return this;
    }
}
