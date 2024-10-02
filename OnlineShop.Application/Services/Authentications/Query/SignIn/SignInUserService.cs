using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces.Contexts;
using OnlineShop.Common;
using OnlineShop.Common.Dto.Base;
using OnlineShop.Common.Dto.User;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Application.Services.Authentications.Query.SignIn
{
    public class SignInUserService : ISignInUserService
    {
        private readonly IDataBaseContext _context;

        public SignInUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<SignInUserResultDto>> ExcuteAsync(SignInUserRequestInfo req)
        {
            if (string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Password))
                return new ResultDto<SignInUserResultDto>
                {
                    IsSuccess = false,
                    Message = "نام کاربری یا رمز عبور وارد نگردیده است.",
                    Data = null
                };

            var user = await _context.Users.Include(u => u.UserInRoles)
                .ThenInclude(uin => uin.Role)
                .FirstOrDefaultAsync(
                    u => u.Email.Equals(req.Email) &&
                    u.Status.Equals(UserStatus.Active)
                );

            if (user is null)
                return new ResultDto<SignInUserResultDto>
                {
                    IsSuccess = false,
                    Message = "ایمیل به درستی وارد نشده است.",
                    Data = null
                };

            var passHasher = new PasswordHasher();

            if (passHasher.VerifyPassword(user.Password, req.Password) is false)
                return new ResultDto<SignInUserResultDto>
                {
                    IsSuccess = false,
                    Message = "رمز عبور اشتباه است.",
                    Data = null
                };

            return new ResultDto<SignInUserResultDto>
            {
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد",
                Data = new SignInUserResultDto
                {
                    Id = user.Id,
                    Phone = user.Phone,
                    UserName = user.UserName,
                    Roles = user.UserInRoles.Select(x => new RoleDto
                    {
                        Id = x.Role.Id,
                        Name = x.Role.Name
                    }).ToList()
                }
            };
        }
    }
}
