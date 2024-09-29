using OnlineShop.Application.Interfaces.Contexts;
using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Commands.Update
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly IDataBaseContext _context;

        public UpdateUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> ExcuteAsync(UpdateUserRequestInfo req)
        {
            var user = await _context.Users.FindAsync(req.Id);

            if (user is null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            else 
            {
                user.Password = req.Password;
                user.Phone = req.Phone;
                user.UserName = req.UserName;
                user.UpdatedDatetime = DateTime.Now;
                user.Status = req.Status;

                await _context.SaveChangesAsync();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "کاربر با موفقیت بروزرسانی شد"
                };
            }
        }
    }
}
