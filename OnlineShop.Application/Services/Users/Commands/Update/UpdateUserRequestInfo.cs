using OnlineShop.Common.Dto;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Application.Services.Users.Commands.Update
{
    public class UpdateUserRequestInfo : BaseUpdateRequestInfo
    {
        public string Phone { get; set; }
        public string UserName { get; set; }
        public UserStatus Status { get; set; }
        public string Password { get; set; }

    }
}
