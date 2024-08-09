

namespace Plamfit.Application.Interfaces.IRepositories
{
    public interface IReadBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid Id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
