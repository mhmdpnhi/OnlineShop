using OnlineShop.Domain.Entities.Common;

namespace OnlineShop.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
