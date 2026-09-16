using Core.ProjectAggregate.Events;
using Core.ProjectAggregate.Interfaces;
using Mediator;
using Microsoft.Extensions.Logging;

namespace Core.ProjectAggregate.Handlers;

public class ProjectNameUpdatedEmailNotificationHandle(
    ILogger<ProjectNameUpdatedEmailNotificationHandle> logger,
    IEmailSender emailSender) : INotificationHandler<ProjectNameUpdatedEvent>
{
    public async ValueTask Handle(ProjectNameUpdatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling Project Name Updated event for {projectId}", domainEvent.Project.Id);

        await emailSender.SendEmailAsync("to@test.com",
                                         "from@test.com",
                                         $"Project {domainEvent.Project.Id} Name Updated",
    $"Project with id {domainEvent.Project.Id} had their name updated to {domainEvent.Project.Name}.");
    }
}
