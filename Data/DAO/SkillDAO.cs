using Microsoft.EntityFrameworkCore;


public class SkillDAO
{
    IServiceProvider serviceProvider;

    public SkillDAO(IServiceProvider serviceProvider) { 
        this.serviceProvider = serviceProvider;
    }
    public List<Skill> getAllSkills()
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Skills == null)
            {
                throw new ArgumentNullException("Null Skill");
            }

            return context.Skills.AsEnumerable().ToList();
        }
    }

    public void addSkills(List<Skill> skills)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Skills == null)
            {
                throw new ArgumentNullException("Null Skills");
            }

            context.Skills.AddRange(skills);
            context.SaveChanges();
        }
    }

    public void updateSkill(Skill updatedSkill)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Skills == null)
            {
                throw new ArgumentNullException("Null Skills");
            }

            var skill = context.ProjectResps.Find(updatedSkill.SkillId);

            if (skill != null)
            {
                context.Entry(skill).CurrentValues.SetValues(updatedSkill);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The updating projectResps with id {updatedSkill.SkillId} does not exist ");
            }
        }
    }


    public void deleteSkill(int skillId)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.Skills == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            var skillToDelete = context.Skills.Find(skillId);

            if (skillToDelete != null)
            {
                context.Skills.Remove(skillToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The skills with id {skillId} does not exist ");
            }
        }
    }

}