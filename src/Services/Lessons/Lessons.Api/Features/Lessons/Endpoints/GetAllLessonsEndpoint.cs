using Lessons.Api.Features.Lessons.Contracts.Responses;
using Lessons.Api.Features.Lessons.Contracts.Requests;
using Lessons.Api.Features.Lessons.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Lessons.Endpoints
{
    public class GetAllLessonsEndpoint : Endpoint<LessonRequest,LessonsResponse,LessonMapper>
    {
        private readonly ILessonsRepository _repository;

        public GetAllLessonsEndpoint(ILessonsRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("lesson");
            AllowAnonymous();
            DontThrowIfValidationFails();
            Describe(x => x
                .Produces<LessonsResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(LessonRequest req, CancellationToken ct)
        {
            IEnumerable<Lesson> lessons = await _repository.GetAll();
            LessonsResponse response = new LessonsResponse
            {
                Lessons = lessons.Select(Map.FromEntity)
            };
            await SendAsync(response, cancellation: ct);
        }
    }
}