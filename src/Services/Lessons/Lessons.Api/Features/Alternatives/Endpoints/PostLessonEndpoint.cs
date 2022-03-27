using Lessons.Api.Features.Alternatives.Contracts.Requests;
using Lessons.Api.Features.Alternatives.Contracts.Responses;
using Lessons.Api.Features.Alternatives.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Alternatives.Endpoints
{
    public class PostAlternativeEndpoint : Endpoint<AlternativeRequest,AlternativeResponse,AlternativeMapper>
    {
        private readonly IAlternativesRepository _repository;

        public PostAlternativeEndpoint(IAlternativesRepository repository)
        {
            _repository = repository;
        }
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("alternative");
            AllowAnonymous();
            Describe(x => x
                .Accepts<AlternativeRequest>("application/json")
                .Produces<AlternativeRequest>(200, "application/json"));
        }

        public override async Task HandleAsync(AlternativeRequest req,CancellationToken ct)
        {
            req.Id = Guid.NewGuid();
            Alternative requestedAlternative = Map.ToEntity(req);
            Alternative alternative = await _repository.Add(requestedAlternative);
            AlternativeResponse response = Map.FromEntity(alternative);
            await SendAsync(response, cancellation: ct);
        }
    }
}