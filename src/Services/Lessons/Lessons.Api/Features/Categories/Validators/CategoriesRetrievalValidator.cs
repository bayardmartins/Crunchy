using FastEndpoints.Validation;
using Lessons.Api.Features.Categories.Contracts.Requests;

namespace Lessons.Api.Features.Categories.Validators
{
    public class CategoriesRetrievalValidator : Validator<CategoryRequest>
    {
        public CategoriesRetrievalValidator()
        {
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Description`s minimum lenght is 5");
            RuleFor(x => x.Description).MaximumLength(255).WithMessage("Description's maximum lenght is 255");
        }
    }
}