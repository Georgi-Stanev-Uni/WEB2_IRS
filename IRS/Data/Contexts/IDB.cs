namespace IRS.Data.Contexts
{
    public interface IDB<T, K>
    {
        Task CreateAsync(T item);

        Task ReadAsync(K key);

        Task <IEnumerable<T>> ReadAllAsync();
        Task UpdateAsync(T item);
        Task DeleteAsync(K key);

    }
}
