using Lessons.Api.Features.Categories.Contracts.Responses;
using Lessons.Api.Features.Categories.Contracts.Requests;
using Lessons.Api.Features.Categories.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Categories.Endpoints
{
    public class GetCategoryByIdEndpoint : Endpoint<CategoryRequest,CategoryResponse,CategoryMapper>
    {
        private readonly ICategoriesRepository _repository;

        public GetCategoryByIdEndpoint(ICategoriesRepository repository)
        {
            _repository = repository;
        }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("category/{id}");
            AllowAnonymous();
            Describe(x => x.Produces<CategoryResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(CategoryRequest req,CancellationToken ct)
        {
            Category category = await _repository.Get(req.Id);
            CategoryResponse response = Map.FromEntity(category);
            await SendAsync(response, cancellation: ct);
        }
    }
}