using Lessons.Api.Features.BaseFeature.Contracts.Requests;

namespace Lessons.Api.Features.Categories.Contracts.Requests
{
    public class CategoryRequest : BaseRequest
    {
        public string Description { get; set; }
    }
}