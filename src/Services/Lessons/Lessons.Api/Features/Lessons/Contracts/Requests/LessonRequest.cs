namespace Lessons.Api.Features.Lessons.Contracts.Requests
{
    public class LessonRequest
    {
        public Guid Id {get; set;}
        public int Level { get; set; }
        public string Question { get; set;}
        public Guid IdCategory { get; set; }
    }
}