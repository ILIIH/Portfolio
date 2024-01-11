using System.ComponentModel.DataAnnotations.Schema;

public class CourseDetails
{
    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("duration")]
    public DateTime Duration { get; set; }

    [Column("task_amount")]
    public int TasksAmount { get; set; }

    [Column("online_classes_amount")]
    public int OnlineClassesAmount { get; set; }

    [Column("offline_classes_amount")]
    public int OfflineClassesAmount { get; set; }

    [Column("course_description")]
    public string CourseDescription { get; set; }

    [Column("tutor_id")]
    public int TutorId { get; set; }
}