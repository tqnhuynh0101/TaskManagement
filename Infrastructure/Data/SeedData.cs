using Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class SeedData
{
    public const int NUMBER_OF_PROJECTS = 27;

    public static async Task InitializeAsync(AppDbContext context)
    {
        if (await context.Projects.AnyAsync())
        {
            return; // DB has been seeded
        }
        var projects = new List<Project>();
        for (int i = 1; i <= NUMBER_OF_PROJECTS; i++)
        {
            var name = ProjectName.From($"Project {i}");
            var description = ProjectDescription.From($"This is the description for project {i}.");
            projects.Add(new Project(name, description));
            await context.Database.ExecuteSqlInterpolatedAsync($"INSERT INTO [Projects] ([Name], [Description]) VALUES ({name}, {description})");

        }
    }

}
