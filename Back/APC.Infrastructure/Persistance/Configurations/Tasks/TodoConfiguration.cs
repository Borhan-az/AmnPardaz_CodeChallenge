namespace APC.Infrastructure.Persistance.Configurations.Tasks
{
    public class TodoConfiguration : IEntityTypeConfiguration<Domain.Entities.TodoLists.Todo>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.TodoLists.Todo> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
            builder.HasOne(entity => entity.User)
                .WithMany(en => en.Todos)
                .HasForeignKey(en => en.UserId)
                .IsRequired(false);
            builder.Property(entity => entity.Description).IsRequired(false);
        }
    }
}