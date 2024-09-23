namespace OnlineShop.Application.Services.Users.Queries.Get
{
	public class GetUserDto
    {
        public ulong Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
