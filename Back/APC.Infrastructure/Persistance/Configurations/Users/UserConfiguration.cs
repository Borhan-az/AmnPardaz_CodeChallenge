namespace APC.Infrastructure.Persistance.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
            builder.HasMany(s => s.Todos)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId).IsRequired(false);
            builder.Property(entity=>entity.Email).IsRequired(false);
        }
    }
}