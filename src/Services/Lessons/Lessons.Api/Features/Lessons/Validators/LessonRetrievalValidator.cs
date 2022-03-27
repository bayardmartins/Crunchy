using FastEndpoints.Validation;
using Lessons.Api.Features.Lessons.Contracts.Requests;

namespace Lessons.Api.Features.Lessons.Validators
{
    public class LessonRetrievalValidator : Validator<LessonRequest>
    {
        public LessonRetrievalValidator()
        {
            RuleFor(x => x.Question).MinimumLength(5).WithMessage("Question`s minimum lenght is 5");
            RuleFor(x => x.Question).MaximumLength(255).WithMessage("Question's maximum lenght is 255");
            RuleFor(x => x.Level).NotNull().WithMessage("Level is required");
        }
    }
}