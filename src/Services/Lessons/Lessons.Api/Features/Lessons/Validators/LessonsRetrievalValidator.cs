using FastEndpoints.Validation;
using Lessons.Api.Features.Lessons.Contracts.Requests;

namespace Lessons.Api.Features.Lessons.Validators
{
    public class LessonsRetrievalValidator : Validator<LessonRequest>
    {
        public LessonsRetrievalValidator()
        {
            RuleFor(x => x.Question).NotEmpty().WithMessage("Question is required");
            RuleFor(x => x.Level).NotEmpty().WithMessage("Level is required");
        }
    }
}