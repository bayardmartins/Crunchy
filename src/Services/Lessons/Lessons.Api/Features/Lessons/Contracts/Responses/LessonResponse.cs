namespace Lessons.Api.Features.Lessons.Contracts.Responses
{
    public class LessonResponse
    {
        public Guid Id { get; set; }
        public Level Level { get; set; }
        public string Question { get; set; }
        public Guid IdCategory { get; set; }
    }
}