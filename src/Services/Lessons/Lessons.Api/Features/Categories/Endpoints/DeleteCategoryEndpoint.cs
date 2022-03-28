using Lessons.Api.Features.Categories.Contracts.Responses;
using Lessons.Api.Features.Categories.Contracts.Requests;
using Lessons.Api.Features.Categories.Mappers;
using Lessons.Api.Interfaces;
using Lessons.Api.Features.BaseFeature.Endpoints;

namespace Lessons.Api.Features.Categories.Endpoints
{
    public class DeleteCategoryEndpoint : DeleteBaseEndpoint<Category, CategoryRequest, CategoryResponse, CategoryMapper>
    {
        public DeleteCategoryEndpoint(ICategoriesRepository repository) : base(repository) { }

        public override void Configure()
        {
            Routes("category/{id}");
            base.Configure();
        }
    }
}