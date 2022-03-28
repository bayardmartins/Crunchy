using Lessons.Api.Features.BaseFeature.Contracts.Responses;

namespace Lessons.Api.Features.Alternatives.Contracts.Responses
{
    public class AlternativeResponse : BaseResponse
    {
        public string Description { get; set; }
        public bool IsRightAnswer { get; set; }
        public Guid IdLesson { get; set; }
    }
}