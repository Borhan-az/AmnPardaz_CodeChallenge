namespace APC.Domain.Entities.Users
{
    public class User : BaseAuditableEntity
    {
        public required string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}