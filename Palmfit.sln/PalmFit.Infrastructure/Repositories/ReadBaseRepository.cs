

using Microsoft.EntityFrameworkCore;
using PalmFit.Infrastructure.Context;
using Plamfit.Application.Interfaces.IRepositories;

namespace PalmFit.Infrastructure.Repositories
{
    public class ReadBaseRepository<T> : IReadBaseRepository<T> where T : class
    {
        private readonly PalmfitDbContext _readPalmfitDbContext;
        private readonly DbSet<T> _readDbSet;

        public ReadBaseRepository(PalmfitDbContext readWritePalmfitDbContext)
        {
            _readPalmfitDbContext = readWritePalmfitDbContext ?? throw new ArgumentNullException(nameof(readWritePalmfitDbContext));
            _readDbSet = _readPalmfitDbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _readDbSet
        .AsQueryable()
        .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid Id)
        {
            return await _readDbSet
                .Where(entity => EF.Property<Guid>(entity, "Id") == Id)
                .FirstOrDefaultAsync();
        }
    }
}
