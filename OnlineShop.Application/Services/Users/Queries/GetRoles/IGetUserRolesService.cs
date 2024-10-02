using OnlineShop.Common.Dto.Base;
using OnlineShop.Common.Dto.User;

namespace OnlineShop.Application.Services.Users.Queries.GetRoles
{
    public interface IGetUserRolesService
    {
        Task<ResultDto<List<RoleDto>>> ExcuteAsync();
    }
}
