using Microsoft.EntityFrameworkCore;


public class ProjectToolDAO
{
    IServiceProvider serviceProvider;

    public ProjectToolDAO(IServiceProvider serviceProvider) { 
        this.serviceProvider = serviceProvider;
    }
    public List<ProjectTool> getAllProjectTools()
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.ProjectTools == null)
            {
                throw new ArgumentNullException("Null ProjectTool");
            }

            return context.ProjectTools.AsEnumerable().ToList();
        }
    }

    public void addProjectTools(List<ProjectTool> projectTools)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.ProjectTools == null)
            {
                throw new ArgumentNullException("Null ProjectTool");
            }

            context.ProjectTools.AddRange(projectTools);
            context.SaveChanges();
        }
    }

    public void updateProjectTool(ProjectTool updatedProjectTool)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.ProjectTools == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            var existingProjectTool = context.ProjectTools.Find(updatedProjectTool.ProjectToolId);

            if (existingProjectTool != null)
            {
                context.Entry(existingProjectTool).CurrentValues.SetValues(updatedProjectTool);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The updating project tool with id {updatedProjectTool.ProjectId} does not exist ");
            }
        }
    }


    public void deleteProjectTool(int projectToolId)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.ProjectTools == null)
            {
                throw new ArgumentNullException("Null projectTool");
            }

            var projectToolDelete = context.ProjectTools.Find(projectToolId);

            if (projectToolDelete != null)
            {
                context.ProjectTools.Remove(projectToolDelete);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The project Tool with id {projectToolId} does not exist ");
            }
        }
    }

}