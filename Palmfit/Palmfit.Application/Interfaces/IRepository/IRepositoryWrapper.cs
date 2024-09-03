

using Palmfit.Domain.Entities.Users;

namespace Palmfit.Application.Interfaces.IRepository
{
    public interface IRepositoryWrapper
    {
        IBaseRepository<AppUser> AppUserRepository { get; }
        IBaseRepository<UserRole> UserRoleRepository { get; }
        IBaseRepository<SystemRole> SystemRoleRepository { get; }
        IBaseRepository<RefreshTokenInfo> RefreshTokenRepository { get; }
    }
}
