using OnlineShop.Common.Dto.User;

namespace OnlineShop.Application.Services.Authentications.Query.SignIn
{
    public class SignInUserResultDto
    {
        public ulong Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public ICollection<RoleDto> Roles { get; set; }
    }
}
