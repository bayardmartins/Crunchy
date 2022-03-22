using FastEndpoints.Validation;
using Lessons.Api.Features.Categories.Contracts.Requests;

namespace Lessons.Api.Features.Categories.Validators
{
    public class CategoriesRetrievalValidator : Validator<CategoryRequest>
    {
        public CategoriesRetrievalValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.LessonList).NotNull().WithMessage("LessonList is required");
        }
    }
}