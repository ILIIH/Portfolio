using System.ComponentModel.DataAnnotations.Schema;

public class ProjectResp
{
    [Column("reps_id")]
    public int RepsId { get; set; }

    [Column("project_id")]
    public int ProjectId { get; set; }

    [Column("reps_name")]
    public string RepsName { get; set; }
}