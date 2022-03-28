using Lessons.Api.Features.BaseFeature.Contracts.Responses;
using Lessons.Api.Features.BaseFeature.Contracts.Requests;
using Lessons.Api.Features.BaseFeature.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.BaseFeature.Endpoints
{
    public abstract class GetBaseByIdEndpoint<T, TRequest, TResponse, TMapper> : Endpoint<TRequest, TResponse, TMapper>
                                                            where T : EntityBase
                                                            where TRequest : BaseRequest, new()
                                                            where TResponse : BaseResponse, new()
                                                            where TMapper : BaseMapper<T, TRequest, TResponse>, new()
    {
        private readonly IBaseRepository<T> _repository;
        public string _route;

        public GetBaseByIdEndpoint(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public override void Configure()
        {
            Verbs(Http.GET);
            AllowAnonymous();
            Describe(x => x.Produces<TRequest>(200, "application/json"));
        }

        public override async Task HandleAsync(TRequest req, CancellationToken ct)
        {
            T item = await _repository.Get(req.Id);
            TResponse response = Map.FromEntity(item);
            await SendAsync(response, cancellation: ct);
        }
    }
}