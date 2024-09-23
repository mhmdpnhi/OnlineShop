using OnlineShop.Application.Interfaces.Contexts;
using OnlineShop.Common.Dto;
using OnlineShop.Domain.Entities.Users;

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
            var user = new User
            {
                UserName = req.UserName,
                Email = req.Email,
                Phone = req.phone
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
                Message = "ثبت نام کاربر موفقیت آمیز بود.",
                Data = new CreateUserResultDto
                {
                    // The user ID will be retrieved after creation.
                    UserId = user.Id
                }
            };
        }
    }
}
