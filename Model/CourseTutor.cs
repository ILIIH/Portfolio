using System.ComponentModel.DataAnnotations.Schema;

public class CourseTutor
{
    [Column("tutor_id")]
    public int TutorId { get; set; }

    [Column("tutor_name")]
    public string TutorName { get; set; }

    [Column("tutor_img_link")]
    public string TutorImgLink { get; set; }
}