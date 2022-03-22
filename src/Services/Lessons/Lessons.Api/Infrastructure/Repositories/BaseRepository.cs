using Microsoft.EntityFrameworkCore;
using Lessons.Api.Infrastructure.Data;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseInterface<T> where T : EntityBase
    {
        internal readonly LessonsApiContext _context;
        internal DbSet<T> dbSet;
        public BaseRepository(LessonsApiContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        
        public async virtual Task<T?> Get(Guid id)
        {
            return await dbSet.Where(item => item.Id == id).FirstOrDefaultAsync();
        }
        public async virtual Task<IEnumerable<T>> GetAll()
        { 
            return await dbSet.ToListAsync<T>();
        }
        public async virtual Task<T> Add(T item)
        {
            await dbSet.AddAsync(item);
            await _context.SaveChangesAsync();  
            return item;  
        }

        public async virtual Task<T?> Delete(Guid id)
        {
            var itemToDelete = await dbSet.FindAsync(id);
            if (itemToDelete == null)
            {
                return null;
            }
            dbSet.Remove(itemToDelete);
            await _context.SaveChangesAsync();
            return itemToDelete;
        }
        public virtual async Task<T?> Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}