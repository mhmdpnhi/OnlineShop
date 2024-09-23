using OnlineShop.Application.Interfaces.Contexts;
using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Queries.GetRoles
{
    public class GetUserRolesService : IGetUserRolesService
    {
        private IDataBaseContext _context;

        public GetUserRolesService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<List<RoleDto>>> ExcuteAsync()
        {
            var roles = _context.Roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();

            return new ResultDto<List<RoleDto>>
            {
                IsSuccess = true,
                Message = null,
                Data = roles
            };
        }
    }
}
