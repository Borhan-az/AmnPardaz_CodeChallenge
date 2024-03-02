namespace APC.Domain.Entities.TodoLists
{
    public  class Todo : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; } = false;
        public Guid UserId { get; set; }
        #region Navigation Properties

        public virtual User User { get; set; }

        #endregion
        public Todo():base()
        {
            
        }
    }
}
