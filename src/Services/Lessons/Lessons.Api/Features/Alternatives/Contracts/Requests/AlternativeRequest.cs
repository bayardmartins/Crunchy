using Lessons.Api.Features.BaseFeature.Contracts.Requests;

namespace Lessons.Api.Features.Alternatives.Contracts.Requests
{
    public class AlternativeRequest : BaseRequest
    {
        public string Description { get; set; }
        public bool IsRightAnswer { get; set; }
        public Guid IdLesson { get; set; }
    }
}