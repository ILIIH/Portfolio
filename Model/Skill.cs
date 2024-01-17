using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Skill
{
    [Key]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [Column("tutor_id")]
    public int TutorId { get; set; }

    [Column("skill_name")]
    public string SkillName { get; set; }

    [Column("skill_photo")]
    public string SkillPhoto { get; set; }
}