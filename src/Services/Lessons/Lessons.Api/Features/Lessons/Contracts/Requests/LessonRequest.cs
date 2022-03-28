using Lessons.Api.Features.BaseFeature.Contracts.Requests;

namespace Lessons.Api.Features.Lessons.Contracts.Requests
{
    public class LessonRequest : BaseRequest
    {
        public int Level { get; set; }
        public string Question { get; set;}
        public Guid IdCategory { get; set; }
    }
}