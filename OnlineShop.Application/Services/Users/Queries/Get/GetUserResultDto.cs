namespace OnlineShop.Application.Services.Users.Queries.Get
{
	public class GetUserResultDto
	{
        public IList<GetUserDto> Users { get; set; }
        public int Rows { get; set; }
    }
}
