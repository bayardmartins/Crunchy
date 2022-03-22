namespace Lessons.Api.Models;
public class Alternative : EntityBase
{
    public string Description { get; set; }
    public bool IsRightAnswer { get; set; }
    public Lesson Lesson { get; set; }
}