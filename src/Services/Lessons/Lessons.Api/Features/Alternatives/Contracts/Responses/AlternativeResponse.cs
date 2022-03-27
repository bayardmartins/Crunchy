namespace Lessons.Api.Features.Alternatives.Contracts.Responses
{
    public class AlternativeResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRightAnswer { get; set; }
        public Guid IdLesson { get; set; }
    }
}