using Lessons.Api.Features.Categories.Contracts.Responses;
using Lessons.Api.Features.Categories.Contracts.Requests;
using Lessons.Api.Features.Categories.Mappers;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Features.Categories.Endpoints
{
    public class DeleteCategoryEndpoint : Endpoint<CategoryRequest,CategoryResponse,CategoryMapper>
    {
        private readonly ICategoriesRepository _repository;

        public DeleteCategoryEndpoint(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Verbs(Http.DELETE);
            Routes("category/{id}");
            AllowAnonymous();
            Describe(x => x.Produces<CategoryResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(CategoryRequest req,CancellationToken ct)
        {
            //TODO: Validar delete de entidade não encontrada
            Category requestedCategory = Map.ToEntity(req);
            Category? category = await _repository.Delete(requestedCategory.Id);
            CategoryResponse response = Map.FromEntity(category);
            await SendAsync(response, cancellation: ct);
        }
    }
}