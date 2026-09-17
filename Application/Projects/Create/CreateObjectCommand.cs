
using Core.ProjectAggregate;

namespace Application.Projects.Create;

public record CreateObjectCommand(ProjectName name, ProjectDescription description) : ICommand<Result<ProjectId>>;

