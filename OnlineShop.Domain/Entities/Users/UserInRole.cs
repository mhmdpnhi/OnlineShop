using OnlineShop.Domain.Entities.Common;

namespace OnlineShop.Domain.Entities.Users
{
    public class UserInRole : BaseEntity
    {
        public virtual User User { get; set; } = new User();
        public ulong UserId { get; set; }
        public virtual Role Role { get; set; } = new Role();
        public ulong RoleId { get; set; }
    }
}
