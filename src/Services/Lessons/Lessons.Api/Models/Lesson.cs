namespace Lessons.Api.Models;
public class Lesson : EntityBase
{
    public Level Level { get; set; }
    public string Question { get; set;}
    public Guid IdCategory { get; set; }
}