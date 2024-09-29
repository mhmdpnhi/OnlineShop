namespace OnlineShop.Domain.Entities.Common
{
    public class BaseEntityNoId
    {
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDatetime { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteDateTime { get; set; }
    }
}
