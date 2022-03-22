using Lessons.Api.Features.Alternatives.Contracts.Responses;
using Lessons.Api.Features.Alternatives.Contracts.Requests;
using Lessons.Api.Features.Alternatives.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Alternatives.Endpoints
{
    public class GetAlternativeByIdEndpoint : Endpoint<AlternativeRequest,AlternativeResponse,AlternativeMapper>
    {
        private readonly IAlternativesRepository _repository;

        public GetAlternativeByIdEndpoint(IAlternativesRepository repository)
        {
            _repository = repository;
        }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("alternative/{id}");
            AllowAnonymous();
            Describe(x => x.Produces<AlternativeResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(AlternativeRequest req,CancellationToken ct)
        {
            Alternative alternative = await _repository.Get(req.Id);
            AlternativeResponse response = Map.FromEntity(alternative);
            await SendAsync(response, cancellation: ct);
        }
    }
}