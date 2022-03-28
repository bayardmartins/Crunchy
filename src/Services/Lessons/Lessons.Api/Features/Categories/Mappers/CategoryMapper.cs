using Lessons.Api.Features.Categories.Contracts.Requests;
using Lessons.Api.Features.Categories.Contracts.Responses;
using Lessons.Api.Features.BaseFeature.Mappers;

namespace Lessons.Api.Features.Categories.Mappers
{
    public class CategoryMapper : BaseMapper<Category, CategoryRequest, CategoryResponse>
    {
        public override CategoryResponse FromEntity(Category e)
        {
            return new CategoryResponse
            {
                Id = e.Id,
                Description = e.Description,
            };
        }

        public override Category ToEntity(CategoryRequest r) => new()
        {
            Id = r.Id,
            Description = r.Description,
        };
    }
}