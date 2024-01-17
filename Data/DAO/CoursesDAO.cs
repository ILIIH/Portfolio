using Microsoft.EntityFrameworkCore;


public class CoursesDAO
{
    IServiceProvider serviceProvider;

    public CoursesDAO(IServiceProvider serviceProvider) { 
        this.serviceProvider = serviceProvider;
    }
    public List<Course> getAllCourses()
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Courses == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            return context.Courses.AsEnumerable().ToList();
        }
    }

    public void addCourses(List<Course> courses)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Courses == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            context.Courses.AddRange(courses);
            context.SaveChanges();
        }
    }

    public void UpdateCourse(Course updatedCourse)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Courses == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            var existingCourse = context.Courses.Find(updatedCourse.CourseId);

            if (existingCourse != null)
            {
                context.Entry(existingCourse).CurrentValues.SetValues(updatedCourse);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The updating course with id {updatedCourse.CourseId} does not exist ");
            }
        }
    }


    public void DeleteCourse(int courseId)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Courses == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            var courseToDelete = context.Courses.Find(courseId);

            if (courseToDelete != null)
            {
                context.Courses.Remove(courseToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The course with id {courseId} does not exist ");
            }
        }
    }

}