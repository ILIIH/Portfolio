using Microsoft.EntityFrameworkCore;
public class RazorPagesProfile : DbContext
{
    public RazorPagesProfile(DbContextOptions<RazorPagesProfile> options)
         : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseDetails> CourseDetails { get; set; }
    public DbSet<CourseTutor> CourseTutors { get; set; }
    public DbSet<PlanItem> PlanItems { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectResp> ProjectResps { get; set; }
    public DbSet<ProjectTool> ProjectTools { get; set; }
    public DbSet<Skill> Skills { get; set; }


}
