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
                LessonList = e.LessonList,
            };
        }

        public override Category ToEntity(CategoryRequest r) => new()
        {
            Description = r.Description,
            LessonList = r.LessonList,
        };
    }
}