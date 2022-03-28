using Lessons.Api.Features.Alternatives.Contracts.Requests;
using Lessons.Api.Features.Alternatives.Contracts.Responses;
using Lessons.Api.Features.BaseFeature.Mappers;

namespace Lessons.Api.Features.Alternatives.Mappers
{
    public class AlternativeMapper : BaseMapper<Alternative, AlternativeRequest, AlternativeResponse>
    {
        public override AlternativeResponse FromEntity(Alternative e)
        {
            return new AlternativeResponse
            {
                Id = e.Id,
                Description = e.Description,
                IsRightAnswer = e.IsRightAnswer,
                IdLesson = e.IdLesson
            };
        }

        public override Alternative ToEntity(AlternativeRequest r) => new()
        {
            Id = r.Id,
            Description = r.Description,
            IsRightAnswer = r.IsRightAnswer,
            IdLesson = r.IdLesson
        };
    }
}