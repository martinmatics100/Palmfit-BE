

namespace Palmfit.Application.Interfaces.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        //Task SaveChangesAsync();
        Task DeprecateAsync(Guid userId);
    }
}
