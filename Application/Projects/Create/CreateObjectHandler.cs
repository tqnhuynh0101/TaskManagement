
using Core.ProjectAggregate;

namespace Application.Projects.Create;

public class CreateObjectHandler(IRepository<Project> _repository) : 
    ICommandHandler<CreateObjectCommand, Result<ProjectId>>
{
    public async ValueTask<Result<ProjectId>> Handle(CreateObjectCommand command, CancellationToken cancellationToken)
    {
        var newProject = new Project(command.name, command.description);
        var createdItem = await _repository.AddAsync(newProject, cancellationToken);
        return createdItem.Id;
    }
}
