namespace APC.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
        public BaseAuditableEntity()
        {
            Created = DateTime.Now;
        }
        public BaseAuditableEntity(string createdBy)
        {
            CreatedBy = createdBy;
            Created = DateTime.Now;
        }
        public BaseAuditableEntity(string lastModifiedBy, DateTime lastModified)
        {
            LastModifiedBy = lastModifiedBy;
            LastModified = lastModified;
        }
    }
}