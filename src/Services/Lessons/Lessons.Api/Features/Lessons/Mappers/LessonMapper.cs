using Lessons.Api.Features.Lessons.Contracts.Requests;
using Lessons.Api.Features.Lessons.Contracts.Responses;

namespace Lessons.Api.Features.Lessons.Mappers
{
    public class LessonMapper : Mapper<LessonRequest, LessonResponse, Lesson>
    {
        public override LessonResponse FromEntity(Lesson e)
        {
            return new LessonResponse
            {
                Id = e.Id,
                Level = e.Level,
                Question = e.Question,
                IdCategory = e.IdCategory
            };
        }

        public override Lesson ToEntity(LessonRequest r) => new()
        {
            Id = r.Id,
            Level = (Level)r.Level,
            Question = r.Question,
            IdCategory = r.IdCategory,
        };
    }
}