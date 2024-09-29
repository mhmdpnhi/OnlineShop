using OnlineShop.Application.Interfaces.Contexts;
using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Commands.Delete
{
    public class DeleteUserService : IDeleteUserService
    {
        private IDataBaseContext _context;

        public DeleteUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> ExcuteAsync(ulong userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            else
            {
                user.IsDeleted = true;
                user.DeleteDateTime = DateTime.Now;

                await _context.SaveChangesAsync();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "کاربر با موفقیت حذف شد"
                };
            }
        }
    }
}
