namespace APC.Domain.Entities.Users
{
    public class User : BaseAuditableEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        #region Navigation Properties
        public virtual ICollection<TodoLists.Todo> Todos { get; set; }
        #endregion
        public User() : base()
        {
        }
        public User(string userName, string email, string password, string salt)
        {
            UserName = userName;
            Email = email;
            PasswordHash = password;
            PasswordSalt = salt;

        }
    }
}