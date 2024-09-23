namespace OnlineShop.Application.Services.Users.Queries.Get
{
	public interface IGetUserService
    {
        Task<GetUserResultDto> ExecuteAsync(GetUserRequestInfo request);
    }
}
