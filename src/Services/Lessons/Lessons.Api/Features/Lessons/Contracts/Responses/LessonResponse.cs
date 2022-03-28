using Lessons.Api.Features.BaseFeature.Contracts.Responses;

namespace Lessons.Api.Features.Lessons.Contracts.Responses
{
    public class LessonResponse : BaseResponse
    {
        public Level Level { get; set; }
        public string Question { get; set; }
        public Guid IdCategory { get; set; }
    }
}