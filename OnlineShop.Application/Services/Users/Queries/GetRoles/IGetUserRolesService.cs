using Microsoft.EntityFrameworkCore;
using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Queries.GetRoles
{
    public interface IGetUserRolesService
    {
        Task<ResultDto<List<RoleDto>>> ExcuteAsync();
    }
}
