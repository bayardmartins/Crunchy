using Lessons.Api.Features.Categories.Contracts.Responses;
using Lessons.Api.Features.Categories.Contracts.Requests;
using Lessons.Api.Features.Categories.Mappers;
using Lessons.Api.Interfaces;
using Lessons.Api.Features.BaseFeature.Endpoints;

namespace Lessons.Api.Features.Categories.Endpoints
{
    public class PutCategoryEndpoint : PutBaseEndpoint<Category, CategoryRequest, CategoryResponse, CategoryMapper>
    {
        public PutCategoryEndpoint(ICategoriesRepository repository) : base(repository) { }

        public override void Configure()
        {
            Routes("category");
            base.Configure();
        }
    }
}