using Lessons.Api.Features.Categories.Contracts.Responses;
using Lessons.Api.Features.Categories.Contracts.Requests;
using Lessons.Api.Features.Categories.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Categories.Endpoints
{
    public class GetAllCategoriesEndpoint : Endpoint<CategoryRequest,CategoriesResponse,CategoryMapper>
    {
        private readonly ICategoriesRepository _repository;

        public GetAllCategoriesEndpoint(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("category");
            AllowAnonymous();
            DontThrowIfValidationFails();
            Describe(x => x.Produces<CategoryResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(CategoryRequest req,CancellationToken ct)
        {
            IEnumerable<Category> categories = await _repository.GetAll();
            CategoriesResponse response = new CategoriesResponse
            {
                Categories = categories.Select(Map.FromEntity)
            };
            await SendAsync(response, cancellation: ct);
        }
    }
}