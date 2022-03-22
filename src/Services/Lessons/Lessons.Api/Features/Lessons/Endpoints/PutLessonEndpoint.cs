using Lessons.Api.Features.Lessons.Contracts.Requests;
using Lessons.Api.Features.Lessons.Contracts.Responses;
using Lessons.Api.Features.Lessons.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Lessons.Endpoints
{
    public class PutLessonEndpoint : Endpoint<LessonRequest,LessonResponse,LessonMapper>
    {
        private readonly ILessonsRepository _repository;

        public PutLessonEndpoint(ILessonsRepository repository)
        {
            _repository = repository;
        }
        public override void Configure()
        {
            Verbs(Http.PUT);
            Routes("lesson");
            AllowAnonymous();
            Describe(x => x
                .Accepts<LessonRequest>("application/json+custom")
                .Produces<LessonsResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(LessonRequest req,CancellationToken ct)
        {
            Lesson requestedLesson = Map.ToEntity(req);
            Lesson? lesson = await _repository.Update(requestedLesson);
            LessonResponse response = Map.FromEntity(lesson);
            await SendAsync(response, cancellation: ct);
        }
    }
}