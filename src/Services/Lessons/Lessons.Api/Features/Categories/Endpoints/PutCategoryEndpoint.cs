using Lessons.Api.Features.Categories.Contracts.Responses;
using Lessons.Api.Features.Categories.Contracts.Requests;
using Lessons.Api.Features.Categories.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Categories.Endpoints
{
    public class PutCategoryEndpoint : Endpoint<CategoryRequest,CategoryResponse,CategoryMapper>
    {
        private readonly ICategoriesRepository _repository;

        public PutCategoryEndpoint(ICategoriesRepository repository)
        {
            _repository = repository;
        }
        public override void Configure()
        {
            Verbs(Http.PUT);
            Routes("category");
            AllowAnonymous();
            Describe(x => x
                .Accepts<CategoryRequest>("application/json+custom")
                .Produces<CategoryRequest>(200, "application/json"));
        }

        public override async Task HandleAsync(CategoryRequest req,CancellationToken ct)
        {
            Category requestedCategory = Map.ToEntity(req);
            Category? category = await _repository.Update(requestedCategory);
            CategoryResponse response = Map.FromEntity(category);
            await SendAsync(response, cancellation: ct);
        }
    }
}