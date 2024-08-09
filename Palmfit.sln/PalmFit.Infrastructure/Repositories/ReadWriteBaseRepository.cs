using Microsoft.EntityFrameworkCore;
using PalmFit.Infrastructure.Context;
using Plamfit.Application.Interfaces.IRepositories;

namespace PalmFit.Infrastructure.Repositories
{
    public class ReadWriteBaseRepository<T> : IReadWriteBaseRepository<T> where T : class
    {
        private readonly PalmfitDbContext _readWritePalmfitDbContext;
        private readonly DbSet<T> _readWriteDbSet;

        public ReadWriteBaseRepository(PalmfitDbContext readWritePalmfitDbContext)
        {
            _readWritePalmfitDbContext = readWritePalmfitDbContext ?? throw new ArgumentNullException(nameof(readWritePalmfitDbContext));
            _readWriteDbSet = _readWritePalmfitDbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
                await _readWriteDbSet.AddAsync(entity);
                await SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
                _readWriteDbSet.Remove(entity);
                await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
                await _readWritePalmfitDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
                _readWriteDbSet.Update(entity);
                await SaveChangesAsync();
        }
    }
}
