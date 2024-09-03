

using Microsoft.EntityFrameworkCore;
using Palmfit.Application.Interfaces.IRepository;
using Palmfit.Domain.Enums;
using Palmfit.Infrastructure.Data.Context;

namespace Palmfit.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly PalmfitDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(PalmfitDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            try
            {
                await _dbSet.AddAsync(entity);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await _dbSet.FirstOrDefaultAsync(entity => EF.Property<Guid>(entity, "Id") == Id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
        }

        public async Task DeprecateAsync(Guid userId)
        {
            var user = await _dbSet.FirstOrDefaultAsync(entity => EF.Property<Guid>(entity, "Id") == userId);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User not found");
            }

            var deprecationProperty = typeof(T).GetProperty("IsDeprecated");
            if (deprecationProperty != null)
            {
                deprecationProperty.SetValue(user, IsDeprecationStatus.True);
            }
            else
            {
                throw new InvalidOperationException("IsDeprecated property not found on the entity");
            }
            await SaveChangesAsync();
        }

    }
}
