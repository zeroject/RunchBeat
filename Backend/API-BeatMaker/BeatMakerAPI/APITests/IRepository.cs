
namespace APITests
{
    public interface IRepository<K, T>
    {
            int Count { get; }
            void Add(T item);
            void Remove(T item);
            T GetByID(K id);
            List<T> GetAll();
    }
}
