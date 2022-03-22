using Microsoft.EntityFrameworkCore;
using Lessons.Api.Infrastructure.Data;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Infrastructure.Repositories
{
    public class AlternativesRepository: BaseRepository<Alternative>, IAlternativesRepository 
    {
        public AlternativesRepository(LessonsApiContext context) : base(context) {}
        public virtual async Task<Alternative?> Update(Alternative item)
        {
            var itemToUpdate = await this.Get(item.Id);
            if(itemToUpdate == null) { return null; }
            itemToUpdate.Description = item.Description;
            itemToUpdate.IsRightAnswer = item.IsRightAnswer;
            itemToUpdate.Lesson = item.Lesson;
            await _context.SaveChangesAsync();
            return itemToUpdate;
        }
    }
}