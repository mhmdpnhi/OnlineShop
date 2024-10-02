using OnlineShop.Common.Dto.Base;

namespace OnlineShop.Application.Services.Users.Commands.Delete
{
    public interface IDeleteUserService
    {
        Task<ResultDto> ExcuteAsync(ulong userId);
    }
}
