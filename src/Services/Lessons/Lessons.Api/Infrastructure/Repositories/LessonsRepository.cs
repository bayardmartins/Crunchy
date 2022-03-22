using Microsoft.EntityFrameworkCore;
using Lessons.Api.Infrastructure.Data;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Infrastructure.Repositories
{
    public class LessonsRepository: BaseRepository<Lesson>, ILessonsRepository
    {
        public LessonsRepository(LessonsApiContext context): base(context) {}
        public virtual async Task<Lesson?> Update(Lesson item)
        {
            var itemToUpdate = await this.Get(item.Id);
            if(itemToUpdate == null) { return null; }
            itemToUpdate.Level = item.Level;
            itemToUpdate.Question = item.Question;
            await _context.SaveChangesAsync();
            return itemToUpdate;
        }
    }
}