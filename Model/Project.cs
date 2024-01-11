using System.ComponentModel.DataAnnotations.Schema;

public class Project
{
    [Column("project_id")]
    public int ProjectId { get; set; }

    [Column("tutor_id")]
    public int TutorId { get; set; }

    [Column("project_name")]
    public string ProjectName { get; set; }

    [Column("project_photo")]
    public string ProjectPhoto { get; set; }
}