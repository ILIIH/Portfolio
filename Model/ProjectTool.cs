using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProjectTool
{
    [Key]
    [Column("project_tool_id")]
    public int ProjectToolId { get; set; }

    [Column("project_id")]
    public int ProjectId { get; set; }

    [Column("tool_name")]
    public string ToolName { get; set; }

    [Column("image_link_name")]
    public string ImageLinkName { get; set; }
}