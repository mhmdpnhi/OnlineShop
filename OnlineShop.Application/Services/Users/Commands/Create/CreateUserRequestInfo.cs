namespace OnlineShop.Application.Services.Users.Commands.Create
{
    public class CreateUserRequestInfo
    {
        public string UserName { get;  set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public List<RolesInCreateUserRequestInfo> Roles { get; set; }
    }
}
