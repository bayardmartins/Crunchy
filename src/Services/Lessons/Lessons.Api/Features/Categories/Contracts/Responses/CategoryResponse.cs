using Lessons.Api.Features.BaseFeature.Contracts.Responses;

namespace Lessons.Api.Features.Categories.Contracts.Responses
{
    public class CategoryResponse : BaseResponse
    {
        public string Description { get; set; }
    }
}