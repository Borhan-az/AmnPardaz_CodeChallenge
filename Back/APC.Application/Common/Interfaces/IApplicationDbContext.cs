using APC.Domain.Entities.Users;

namespace APC.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Domain.Entities.TodoLists.Todo> Todos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}