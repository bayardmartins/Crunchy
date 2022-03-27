namespace Lessons.Api.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T?> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T item);
        Task<T?> Delete(Guid id);
        Task<T?> Update(T item);
    }
    public interface ICategoriesRepository : IBaseRepository<Category> { }
    public interface ILessonsRepository : IBaseRepository<Lesson> { }
    public interface IAlternativesRepository : IBaseRepository<Alternative> { }
}