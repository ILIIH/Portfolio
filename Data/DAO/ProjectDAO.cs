using Microsoft.EntityFrameworkCore;


public class ProjectDAO
{
    IServiceProvider serviceProvider;

    public ProjectDAO(IServiceProvider serviceProvider) { 
        this.serviceProvider = serviceProvider;
    }
    public List<Project> getAllProjects()
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Projects == null)
            {
                throw new ArgumentNullException("Null Project");
            }

            return context.Projects.AsEnumerable().ToList();
        }
    }

    public void addProjects(List<Project> projects)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Projects == null)
            {
                throw new ArgumentNullException("Null Project");
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
    }

    public void updateProject(Project updatedProject)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Projects == null)
            {
                throw new ArgumentNullException("Null updatedProject");
            }

            var existingProject = context.Projects.Find(updatedProject.ProjectId);

            if (existingProject != null)
            {
                context.Entry(existingProject).CurrentValues.SetValues(updatedProject);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The updating course with id {updatedProject.ProjectId} does not exist ");
            }
        }
    }


    public void deleteProject(int projectId)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Projects == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            var projectToDelete = context.Projects.Find(projectId);

            if (projectToDelete != null)
            {
                context.Projects.Remove(projectToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The project with id {projectId} does not exist ");
            }
        }
    }

}