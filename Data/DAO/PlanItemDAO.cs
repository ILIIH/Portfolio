using Microsoft.EntityFrameworkCore;


public class PlanItemsDAO
{
    IServiceProvider serviceProvider;

    public PlanItemsDAO(IServiceProvider serviceProvider) { 
        this.serviceProvider = serviceProvider;
    }
    public List<PlanItem> getAllPlanItems()
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.PlanItems == null)
            {
                throw new ArgumentNullException("Null PlanItems");
            }

            return context.PlanItems.AsEnumerable().ToList();
        }
    }

    public void addPlanItems(List<PlanItem> planItems)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.PlanItems == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            context.PlanItems.AddRange(planItems);
            context.SaveChanges();
        }
    }

    public void updatePlanItem(PlanItem updatedPlanItem)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.PlanItems == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            var existingPlanItem = context.PlanItems.Find(updatedPlanItem.PlanId);

            if (existingPlanItem != null)
            {
                context.Entry(existingPlanItem).CurrentValues.SetValues(updatedPlanItem);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The updating PlanItem with id {updatedPlanItem.PlanId} does not exist ");
            }
        }
    }


    public void deletePlanItem(int planItemId)
    {
        using (var context = new RazorPagesProfile(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProfile>>()))
        {
            if (context == null || context.PlanItems == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            var planItemToDelete = context.PlanItems.Find(planItemId);

            if (planItemToDelete != null)
            {
                context.PlanItems.Remove(planItemToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException($"The plan with id {planItemId} does not exist ");
            }
        }
    }

}