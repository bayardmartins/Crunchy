using FastEndpoints.Validation;
using Lessons.Api.Features.Alternatives.Contracts.Requests;

namespace Lessons.Api.Features.Alternatives.Validators
{
    public class AlternativesRetrievalValidator : Validator<AlternativeRequest>
    {
        public AlternativesRetrievalValidator()
        {
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Description`s minimum lenght is 5");
            RuleFor(x => x.Description).MaximumLength(125).WithMessage("Description's maximum lenght is 125");
            RuleFor(x => x.IsRightAnswer).NotNull().WithMessage("IsRightAnswer is required");
        }
    }
}