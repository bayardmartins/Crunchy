using Lessons.Api.Features.Alternatives.Contracts.Requests;
using Lessons.Api.Features.Alternatives.Contracts.Responses;

namespace Lessons.Api.Features.Alternatives.Mappers
{
    public class AlternativeMapper : Mapper<AlternativeRequest, AlternativeResponse, Alternative>
    {
        public override AlternativeResponse FromEntity(Alternative e)
        {
            return new AlternativeResponse
            {
                Id = e.Id,
                Description = e.Description,
                IsRightAnswer = e.IsRightAnswer,
                Lesson = e.Lesson,
            };
        }

        public override Alternative ToEntity(AlternativeRequest r) => new()
        {
            Description = r.Description,
            IsRightAnswer = r.IsRightAnswer,
            Lesson = r.Lesson,
        };
    }
}