
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Course
{
 
    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("course_name")]
    public required string CourseName { get; set; }

    [Column("course_img_link")]
    public required string CourseImgLink { get; set; }
}