namespace Lessons.Api.Interfaces
{
    public interface IBaseInterface<T>
    {
        Task<T?> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T item);
        Task<T?> Delete(Guid id);
        Task<T?> Update(T item);
    }
    public interface ICategoriesRepository : IBaseInterface<Category> { }
    public interface ILessonsRepository : IBaseInterface<Lesson> { }
    public interface IAlternativesRepository : IBaseInterface<Alternative> { }
}