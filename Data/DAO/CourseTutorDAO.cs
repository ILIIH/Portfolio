using Microsoft.EntityFrameworkCore;


public class CourseTutorDAO
{
    IServiceProvider serviceProvider;

    public CourseTutorDAO(IServiceProvider serviceProvider) { 
        this.serviceProvider = serviceProvider;
    }
    public List<CourseTutor> getAllCourseTutor()
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.CourseTutors == null)
            {
                throw new ArgumentNullException("Null CourseTutor");
            }

            return context.CourseTutors.AsEnumerable().ToList();
        }
    }

    public void addCourseTutors(List<CourseTutor> coursesTutor)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.CourseTutors == null)
            {
                throw new ArgumentNullException("Null CourseTutors");
            }

            context.CourseTutors.AddRange(coursesTutor);
            context.SaveChanges();
        }
    }

    public void updateCourseTutors(CourseTutor updatedCourseTutor)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.CourseTutors == null)
            {
                throw new ArgumentNullException("Null CourseTutor");
            }

            var existingCourseTutor = context.CourseTutors.Find(updatedCourseTutor.TutorId);

            if (existingCourseTutor != null)
            {
                context.Entry(existingCourseTutor).CurrentValues.SetValues(updatedCourseTutor);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The updating CourseTutor.TutorId does not exist \");\r\n            }} with id {existingCourseTutor.TutorId} does not exist ");
            }
        }
    }


    public void deleteCourseTutor(int tutorId)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.CourseTutors == null)
            {
                throw new ArgumentNullException("Null CourseTutor");
            }

            var tutorToDelete = context.CourseTutors.Find(tutorId);

            if (tutorToDelete != null)
            {
                context.CourseTutors.Remove(tutorToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The course with id {tutorId} does not exist ");
            }
        }
    }

}