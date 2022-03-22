using Lessons.Api.Features.Alternatives.Contracts.Requests;
using Lessons.Api.Features.Alternatives.Contracts.Responses;
using Lessons.Api.Features.Alternatives.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Alternatives.Endpoints
{
    public class PutAlternativeEndpoint : Endpoint<AlternativeRequest,AlternativeResponse,AlternativeMapper>
    {
        private readonly IAlternativesRepository _repository;

        public PutAlternativeEndpoint(IAlternativesRepository repository)
        {
            _repository = repository;
        }
        public override void Configure()
        {
            Verbs(Http.PUT);
            Routes("alternative");
            AllowAnonymous();
            Describe(x => x
                .Accepts<AlternativeRequest>("application/json+custom")
                .Produces<AlternativeResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(AlternativeRequest req,CancellationToken ct)
        {
            Alternative requestedAlternative = Map.ToEntity(req);
            Alternative? alternative = await _repository.Update(requestedAlternative);
            AlternativeResponse response = Map.FromEntity(alternative);
            await SendAsync(response, cancellation: ct);
        }
    }
}