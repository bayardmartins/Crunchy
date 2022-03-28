namespace Lessons.Api.Features.BaseFeature.Contracts.Responses
{
    public class BasesResponse<TBaseResponse> where TBaseResponse : BaseResponse
    {
        public IEnumerable<TBaseResponse> Items { get; set; }
    }
}