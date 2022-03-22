namespace Lessons.Api.Features.Lessons.Contracts.Responses
{
    public class LessonsResponse
    {
        public IEnumerable<LessonResponse> Lessons { get; set; }
    }
}