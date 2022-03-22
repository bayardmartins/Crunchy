namespace Lessons.Api.Features.Categories.Contracts.Requests
{
    public class CategoryRequest
    {
        public Guid Id {get; set;}
        public string Description { get; set; }
        public List<Lesson> LessonList { get; set; }
    }
}