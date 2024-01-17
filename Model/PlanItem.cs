using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PlanItem
{
    [Key]
    [Column("plan_id")]
    public int PlanId { get; set; }

    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("plan_item_name")]
    public string PlanItemName { get; set; }
}