using Lessons.Api.Features.Lessons.Contracts.Responses;
using Lessons.Api.Features.Lessons.Contracts.Requests;
using Lessons.Api.Features.Lessons.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Lessons.Endpoints
{
    public class GetLessonByIdEndpoint : Endpoint<LessonRequest,LessonResponse,LessonMapper>
    {
        private readonly ILessonsRepository _repository;

        public GetLessonByIdEndpoint(ILessonsRepository repository)
        {
            _repository = repository;
        }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("lesson/{id}");
            AllowAnonymous();
            Describe(x => x.Produces<LessonResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(LessonRequest req,CancellationToken ct)
        {
            Lesson lesson = await _repository.Get(req.Id);
            LessonResponse response = Map.FromEntity(lesson);
            await SendAsync(response, cancellation: ct);
        }
    }
}