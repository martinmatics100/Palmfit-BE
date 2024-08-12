

using Microsoft.EntityFrameworkCore;
using Palmfit.Domain.Entities;

namespace Palmfit.Infrastructure.Data.Context
{
    public class PalmfitDbContext : DbContext
    {
        public PalmfitDbContext(DbContextOptions<PalmfitDbContext> dbContextoptions) : base(dbContextoptions) { }

        //public DbSet<AppUser> AppUsers { get; set; }
    }
}
