using Lessons.Api.Features.Lessons.Contracts.Responses;
using Lessons.Api.Features.Lessons.Contracts.Requests;
using Lessons.Api.Features.Lessons.Mappers;
using Lessons.Api.Interfaces;
using Lessons.Api.Features.BaseFeature.Endpoints;

namespace Lessons.Api.Features.Lessons.Endpoints
{
    public class GetLessonByIdEndpoint : GetBaseByIdEndpoint<Lesson,LessonRequest,LessonResponse,LessonMapper>
    {
        public GetLessonByIdEndpoint(ILessonsRepository repository) : base(repository) { }
        public override void Configure()
        {
            Routes("lesson/{id}");
            base.Configure();
        }
    }
}