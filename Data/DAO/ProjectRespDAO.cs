using Microsoft.EntityFrameworkCore;


public class ProjectRespDAO
{
    IServiceProvider serviceProvider;

    public ProjectRespDAO(IServiceProvider serviceProvider) { 
        this.serviceProvider = serviceProvider;
    }
    public List<ProjectResp> getAllProjectResps()
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.ProjectResps == null)
            {
                throw new ArgumentNullException("Null ProjectResp");
            }

            return context.ProjectResps.AsEnumerable().ToList();
        }
    }

    public void addProjectResps(List<ProjectResp> projectResp)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.ProjectResps == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            context.ProjectResps.AddRange(projectResp);
            context.SaveChanges();
        }
    }

    public void updateProjectResp(ProjectResp updatedprojectResps)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.ProjectResps == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            var projectRespsCourse = context.ProjectResps.Find(updatedprojectResps.RepsId);

            if (projectRespsCourse != null)
            {
                context.Entry(projectRespsCourse).CurrentValues.SetValues(updatedprojectResps);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The updating projectResps with id {updatedprojectResps.RepsId} does not exist ");
            }
        }
    }


    public void deleteProjectResps(int projectRespId)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.ProjectResps == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            var projectRespToDelete = context.ProjectResps.Find(projectRespId);

            if (projectRespToDelete != null)
            {
                context.ProjectResps.Remove(projectRespToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The project resps with id {projectRespId} does not exist ");
            }
        }
    }

}