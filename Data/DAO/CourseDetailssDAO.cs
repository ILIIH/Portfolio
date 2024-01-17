using Microsoft.EntityFrameworkCore;


public class CourseDetailsDAO
{
    IServiceProvider serviceProvider;

    public CourseDetailsDAO(IServiceProvider serviceProvider) { 
        this.serviceProvider = serviceProvider;
    }
    public List<CourseDetails> getAllCourseDetails()
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.CourseDetails == null)
            {
                throw new ArgumentNullException("Null CourseDetails");
            }

            return context.CourseDetails.AsEnumerable().ToList();
        }
    }

    public void addCourseDetails(List<CourseDetails> courseDetails)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.CourseDetails == null)
            {
                throw new ArgumentNullException("Null CourseDetails");
            }

            context.CourseDetails.AddRange(courseDetails);
            context.SaveChanges();
        }
    }

    public void updateCourseDetails(CourseDetails updatedCourseDetails)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Courses == null)
            {
                throw new ArgumentNullException("Null CourseDetails");
            }

            var existingCourse = context.CourseDetails.Find(updatedCourseDetails.CourseId);

            if (existingCourse != null)
            {
                context.Entry(existingCourse).CurrentValues.SetValues(updatedCourseDetails);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The updating courseDetails with id {updatedCourseDetails.CourseId} does not exist ");
            }
        }
    }


    public void deleteCourseDetails(int courseDetailsId)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Courses == null)
            {
                throw new ArgumentNullException("Null CourseDetails");
            }

            var courseDetailToDelete = context.CourseDetails.Find(courseDetailsId);

            if (courseDetailToDelete != null)
            {
                context.CourseDetails.Remove(courseDetailToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The course detail with id {courseDetailsId} does not exist ");
            }
        }
    }

}