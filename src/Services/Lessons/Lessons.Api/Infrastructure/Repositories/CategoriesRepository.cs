using Microsoft.EntityFrameworkCore;
using Lessons.Api.Infrastructure.Data;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Infrastructure.Repositories
{
    public class CategoriesRepository: BaseRepository<Category>, ICategoriesRepository 
    {
        public CategoriesRepository(LessonsApiContext context) : base(context) {}
    }
}