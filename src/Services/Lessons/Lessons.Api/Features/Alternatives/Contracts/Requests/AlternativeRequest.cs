namespace Lessons.Api.Features.Alternatives.Contracts.Requests
{
    public class AlternativeRequest
    {
        public Guid Id {get; set;}
        public string Description { get; set; }
        public bool IsRightAnswer { get; set; }
        public Lesson Lesson { get; set; }
    }
}