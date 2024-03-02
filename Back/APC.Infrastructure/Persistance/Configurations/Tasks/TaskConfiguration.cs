namespace APC.Infrastructure.Persistance.Configurations.Tasks
{
    public class TaskConfiguration : IEntityTypeConfiguration<Domain.Entities.TodoLists.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.TodoLists.Task> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).ValueGeneratedOnAdd();

        }
    }
}