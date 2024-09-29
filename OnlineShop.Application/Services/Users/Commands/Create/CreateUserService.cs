using OnlineShop.Application.Interfaces.Contexts;
using OnlineShop.Common.Dto;
using OnlineShop.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.Services.Users.Commands.Create
{
    public class CreateUserService : ICreateUserService
    {
        private IDataBaseContext _context;

        public CreateUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<CreateUserResultDto>> ExcuteAsync(CreateUserRequestInfo req)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(req.UserName))
                    throw new Exception("UserName cant be null.");
                if (String.IsNullOrWhiteSpace(req.Password))
                    throw new Exception("Password cant be null.");
                if (String.IsNullOrWhiteSpace(req.Phone))
                    throw new Exception("Phone cant be null.");
                if (String.IsNullOrWhiteSpace(req.Email))
                    throw new Exception("Email cant be null.");

                var user = new User
                {
                    UserName = req.UserName,
                    Email = req.Email,
                    Phone = req.Phone,
                    Password = req.Password
                };

                var roles = new List<UserInRole>();

                foreach (var item in req.Roles)
                {
                    var role = await _context.Roles.FindAsync(item.Id);

                    roles.Add(new UserInRole
                    {
                        Role = role,
                        RoleId = role.Id,
                        User = user,
                        UserId = user.Id
                    });
                }

                user.UserInRoles = roles;

                await _context.Users.AddAsync(user);

                await _context.SaveChangesAsync();

                return new ResultDto<CreateUserResultDto>()
                {
                    IsSuccess = true,
                    Message = "کاربر با موفقیت ایجاد شد.",
                    Data = new CreateUserResultDto
                    {
                        // The user ID will be retrieved after creation.
                        UserId = user.Id
                    }
                };
            }
            catch(Exception ex)
            {
                return new ResultDto<CreateUserResultDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = new CreateUserResultDto
                    {
                        UserId = 0
                    }
                };
            }
        }
    }
}
