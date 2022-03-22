using Microsoft.EntityFrameworkCore;
using Lessons.Api.Infrastructure.Data;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Infrastructure.Repositories
{
    public class CategoriesRepository: BaseRepository<Category>, ICategoriesRepository 
    {
        public CategoriesRepository(LessonsApiContext context) : base(context) {}
        public virtual async Task<Category?> Update(Category item)
        {
            var itemToUpdate = await this.Get(item.Id);
            if(itemToUpdate == null) { return null; }
            itemToUpdate.Description = item.Description;
            await _context.SaveChangesAsync();
            return itemToUpdate;
        }
    }
}