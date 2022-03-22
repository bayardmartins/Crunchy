using Lessons.Api.Features.Alternatives.Contracts.Responses;
using Lessons.Api.Features.Alternatives.Contracts.Requests;
using Lessons.Api.Features.Alternatives.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Alternatives.Endpoints
{
    public class DeleteAlternativeEndpoint : Endpoint<AlternativeRequest,AlternativeResponse,AlternativeMapper>
    {
        private readonly IAlternativesRepository _repository;

        public DeleteAlternativeEndpoint(IAlternativesRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Verbs(Http.DELETE);
            Routes("alternative/{id}");
            AllowAnonymous();
            Describe(x => x.Produces<AlternativeResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(AlternativeRequest req,CancellationToken ct)
        {
            //TODO: Validar delete de entidade não encontrada
            Alternative requestedLesson = Map.ToEntity(req);
            Alternative? lesson = await _repository.Delete(requestedLesson.Id);
            AlternativeResponse response = Map.FromEntity(lesson);
            await SendAsync(response, cancellation: ct);
        }
    }
}