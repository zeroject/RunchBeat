
namespace APITests
{
    public interface IRepository<T>
    {
            int Count { get; }
            void Add(T item);
            void Remove(T item);
            List<T> GetAll();
    }
}
