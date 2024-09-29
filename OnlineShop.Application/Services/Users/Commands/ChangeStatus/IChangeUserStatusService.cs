using OnlineShop.Common.Dto;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Application.Services.Users.Commands.ChangeStatus
{
    public interface IChangeUserStatusService
    {
        Task<ResultDto> ExcuteAsync(ulong userId, UserStatus status);
    }
}
