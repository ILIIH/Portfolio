using Microsoft.EntityFrameworkCore;
public class RazorPagesProfile : DbContext
{
    public RazorPagesProfile(DbContextOptions<RazorPagesProfile> options)
         : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the model here if needed
    }

}



public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Courses == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Courses.Any())
            {
                return;   // DB has been seeded
            }

            context.Courses.AddRange(
                new Course
                {
                    CourseId = 1,
                    CourseName = "Introduction to Programming",
                    CourseImgLink = "https://example.com/intro-programming.jpg"
                },

            new Course
                {
                    CourseId = 2,
                    CourseName = "Test4",
                    CourseImgLink = "https://example.com/intro-programming.jpg"
                },

                new Course
                {
                    CourseId = 3,
                    CourseName = "Test4535",
                    CourseImgLink = "https://example.com/intro-programming.jpg"
                },

                new Course
                {
                    CourseId = 4,
                    CourseName = "Test4gsgdf",
                    CourseImgLink = "https://example.com/intro-programming.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}