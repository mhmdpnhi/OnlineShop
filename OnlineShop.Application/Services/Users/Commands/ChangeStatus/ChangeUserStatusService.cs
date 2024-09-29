using OnlineShop.Application.Interfaces.Contexts;
using OnlineShop.Common.Dto;
using OnlineShop.Common.Extensions;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Application.Services.Users.Commands.ChangeStatus
{
    public class ChangeUserStatusService : IChangeUserStatusService
    {
        private readonly IDataBaseContext _context;

        public ChangeUserStatusService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> ExcuteAsync(ulong userId, UserStatus status)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user is null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر پیدا نشد."
                };
            }
            else
            {
                user.Status = status;
                await _context.SaveChangesAsync();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = $"وضعیت کاربر با موفقیت به {status.GetDescription()} بروزرسانی شد."
                };
            }
        }
    }
}
