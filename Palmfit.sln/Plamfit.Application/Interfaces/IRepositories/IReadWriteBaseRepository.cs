

namespace Plamfit.Application.Interfaces.IRepositories
{
    public interface IReadWriteBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
