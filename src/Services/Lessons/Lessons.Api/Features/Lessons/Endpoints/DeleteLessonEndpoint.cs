using Lessons.Api.Features.Lessons.Contracts.Responses;
using Lessons.Api.Features.Lessons.Contracts.Requests;
using Lessons.Api.Features.Lessons.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Lessons.Endpoints
{
    public class DeleteLessonEndpoint : Endpoint<LessonRequest,LessonResponse,LessonMapper>
    {
        private readonly ILessonsRepository _repository;

        public DeleteLessonEndpoint(ILessonsRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Verbs(Http.DELETE);
            Routes("lesson/{id}");
            AllowAnonymous();
            Describe(x => x.Produces<LessonsResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(LessonRequest req,CancellationToken ct)
        {
            //TODO: Validar delete de entidade não encontrada
            Lesson requestedLesson = Map.ToEntity(req);
            Lesson? lesson = await _repository.Delete(requestedLesson.Id);
            LessonResponse response = Map.FromEntity(lesson);
            await SendAsync(response, cancellation: ct);
        }
    }
}