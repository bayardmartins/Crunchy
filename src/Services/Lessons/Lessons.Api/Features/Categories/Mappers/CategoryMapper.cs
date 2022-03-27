using Lessons.Api.Features.Categories.Contracts.Requests;
using Lessons.Api.Features.Categories.Contracts.Responses;

namespace Lessons.Api.Features.Categories.Mappers
{
    public class CategoryMapper : Mapper<CategoryRequest, CategoryResponse, Category>
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