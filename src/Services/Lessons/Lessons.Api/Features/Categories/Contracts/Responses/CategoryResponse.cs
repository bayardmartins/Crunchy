namespace Lessons.Api.Features.Categories.Contracts.Responses
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<Lesson> LessonList { get; set; }
    }
}