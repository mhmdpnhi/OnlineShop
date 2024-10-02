using OnlineShop.Common.Dto.Base;

namespace OnlineShop.Application.Services.Users.Commands.Create
{
    public interface ICreateUserService
    {
        Task<ResultDto<CreateUserResultDto>> ExcuteAsync(CreateUserRequestInfo req);
    }
}
