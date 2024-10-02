using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces.Contexts;
using OnlineShop.Common;
using OnlineShop.Common.Consts.Regex;
using OnlineShop.Common.Consts.User;
using OnlineShop.Common.Dto.Base;
using OnlineShop.Common.Dto.User;
using OnlineShop.Domain.Entities.Users;
using System.Text.RegularExpressions;

namespace OnlineShop.Application.Services.Authentications.Command.SignUp
{
    public class SignUpUserService : ISignUpUserService
    {
        private readonly IDataBaseContext _context;

        public SignUpUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<SignUpUserResultDto>> ExcuteAsync(SignUpUserRequestInfo req)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(req.Email))
                    throw new Exception("Email cant be null.");
                if (string.IsNullOrWhiteSpace(req.Password))
                    throw new Exception("Password cant be null.");
                if (string.IsNullOrWhiteSpace(req.UserName))
                    throw new Exception("UserName cant be null.");
                if (string.IsNullOrWhiteSpace(req.Phone))
                    throw new Exception("Phone cant be null.");

                if (Regex.Match(req.Email, RegexValidations.Email, RegexOptions.IgnoreCase).Success is false)
                    throw new FormatException("ایمیل معتبر نیست.");

                

                var passHasher = new PasswordHasher();

                var user = new User
                {
                    Email = req.Email,
                    Password = passHasher.HashPassword(req.Password),
                    UserName = req.UserName,
                    Phone = req.Phone
                };

                var role = await _context.Roles.FirstAsync(r => r.Name == UserRoles.Customer);

                user.UserInRoles = new List<UserInRole>
                {
                    new UserInRole
                    {
                        Role = role,
                        RoleId = role.Id,
                        User = user,
                        UserId = user.Id
                    }
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return new ResultDto<SignUpUserResultDto>
                {
                    IsSuccess = true,
                    Message = "کاربر با موفقیت ایجاد شد.",
                    Data = new SignUpUserResultDto
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Phone = user.Phone,
                        Roles = new List<RoleDto>
                        {
                            new RoleDto
                            {
                                Id = role.Id,
                                Name =  role.Name
                            }
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<SignUpUserResultDto>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }
    }
}
