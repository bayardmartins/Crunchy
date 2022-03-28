using Lessons.Api.Features.BaseFeature.Contracts.Requests;
using Lessons.Api.Features.BaseFeature.Contracts.Responses;
using Lessons.Api.Features.Categories.Contracts.Requests;
using Lessons.Api.Features.Categories.Contracts.Responses;

namespace Lessons.Api.Features.BaseFeature.Mappers
{
    public class BaseMapper<T, TBaseRequest, TBaseResponse> : Mapper<TBaseRequest, TBaseResponse, T>
                                                                where T : class
                                                                where TBaseRequest : BaseRequest, new()
                                                                where TBaseResponse : BaseResponse, new()
    {
    }
}