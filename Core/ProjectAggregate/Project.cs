using Ardalis.SharedKernel;

namespace Core.ProjectAggregate;

public class Project(ProjectName name) : EntityBase<Project, ProjectId>, IAggregateRoot
{
    public ProjectName Name { get; private set; } = name;
    public ProjectDescription Description { get; private set; }

    public Project UpdateName(ProjectName newName)
    {
        if (newName == Name) return this;
        Name = newName;
        //RegisterDomainEvent(new )
        return this;
    }
}
