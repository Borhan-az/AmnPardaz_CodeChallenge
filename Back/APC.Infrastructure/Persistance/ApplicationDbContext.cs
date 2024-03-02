namespace APC.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<User> Users => Set<User>();

        public DbSet<Domain.Entities.TodoLists.Task> Tasks => Set<Domain.Entities.TodoLists.Task>();

    }
}`