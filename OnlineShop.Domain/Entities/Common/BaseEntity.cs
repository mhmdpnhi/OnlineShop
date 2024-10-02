namespace OnlineShop.Domain.Entities.Common
{
    public abstract class BaseEntity<TType>
    {
        public TType Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDatetime { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteDateTime { get; set; } = null;
    }

    public abstract class BaseEntity : BaseEntity<ulong>
    {
    }
}
