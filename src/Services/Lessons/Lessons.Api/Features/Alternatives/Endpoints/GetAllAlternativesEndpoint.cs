using Lessons.Api.Features.Alternatives.Contracts.Responses;
using Lessons.Api.Features.Alternatives.Contracts.Requests;
using Lessons.Api.Features.Alternatives.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Alternatives.Endpoints
{
    public class GetAllAlternativesEndpoint : Endpoint<AlternativeRequest,AlternativesResponse,AlternativeMapper>
    {
        private readonly IAlternativesRepository _repository;

        public GetAllAlternativesEndpoint(IAlternativesRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("alternative");
            AllowAnonymous();
            DontThrowIfValidationFails();
            Describe(x => x.Produces<AlternativeResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(AlternativeRequest req,CancellationToken ct)
        {
            IEnumerable<Alternative> alternatives = await _repository.GetAll();
            AlternativesResponse response = new AlternativesResponse
            {
                Alternatives = alternatives.Select(Map.FromEntity)
            };
            await SendAsync(response, cancellation: ct);
        }
    }
}