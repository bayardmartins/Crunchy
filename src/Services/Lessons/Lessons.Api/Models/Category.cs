namespace Lessons.Api.Models;
public class Category : EntityBase
{
    public string Description { get; set; }
    public List<Lesson> LessonList { get; set; }
}