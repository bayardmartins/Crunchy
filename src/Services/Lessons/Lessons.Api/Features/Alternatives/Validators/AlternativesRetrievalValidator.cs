using FastEndpoints.Validation;
using Lessons.Api.Features.Alternatives.Contracts.Requests;

namespace Lessons.Api.Features.Alternatives.Validators
{
    public class AlternativesRetrievalValidator : Validator<AlternativeRequest>
    {
        public AlternativesRetrievalValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.IsRightAnswer).NotNull().WithMessage("IsRightAnswer is required");
            RuleFor(x => x.Lesson).NotNull().WithMessage("Lesson is required");
        }
    }
}