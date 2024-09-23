using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities.Users
{
    public class Role
    {
        [Key]
        public ulong Id { get; set; }
        public string Name { get; set; }
        //public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
