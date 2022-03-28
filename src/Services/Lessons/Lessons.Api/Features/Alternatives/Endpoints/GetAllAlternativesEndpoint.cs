using Lessons.Api.Features.Alternatives.Contracts.Responses;
using Lessons.Api.Features.Alternatives.Contracts.Requests;
using Lessons.Api.Features.Alternatives.Mappers;
using Lessons.Api.Interfaces;
using Lessons.Api.Features.BaseFeature.Endpoints;

namespace Lessons.Api.Features.Alternatives.Endpoints
{
    public class GetAllAlternativesEndpoint : GetAllBaseEndpoint<Alternative, AlternativeRequest, AlternativeResponse, AlternativesResponse, AlternativeMapper>
    {
        public GetAllAlternativesEndpoint(IAlternativesRepository repository) : base(repository) { }

        public override void Configure()
        {
            Routes("alternative");
            base.Configure();
        }
    }
}