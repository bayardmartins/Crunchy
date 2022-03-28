using Lessons.Api.Features.BaseFeature.Contracts.Responses;
using Lessons.Api.Features.BaseFeature.Contracts.Requests;
using Lessons.Api.Features.BaseFeature.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.BaseFeature.Endpoints
{
    public abstract class GetAllBaseEndpoint<T, TRequest, TResponse, TResponses, TMapper> : Endpoint<TRequest, TResponses, TMapper>
                                                            where T : EntityBase
                                                            where TRequest : BaseRequest, new()
                                                            where TResponses : BasesResponse<TResponse>, new()
                                                            where TResponse : BaseResponse, new()
                                                            where TMapper : BaseMapper<T, TRequest, TResponse>, new()
    {
        private readonly IBaseRepository<T> _repository;
        public string _route;

        public GetAllBaseEndpoint(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            AllowAnonymous();
            DontThrowIfValidationFails();
            Describe(x => x.Produces<TRequest>(200, "application/json"));
        }

        public override async Task HandleAsync(TRequest req, CancellationToken ct)
        {
            IEnumerable<T> items = await _repository.GetAll();
            TResponses response = new TResponses
            {
                Items = items.Select(Map.FromEntity)
            };
            await SendAsync(response, cancellation: ct);
        }
    }
}