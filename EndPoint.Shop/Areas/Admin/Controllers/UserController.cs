using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Application.Services.Users.Commands.ChangeStatus;
using OnlineShop.Application.Services.Users.Commands.Create;
using OnlineShop.Application.Services.Users.Commands.Delete;
using OnlineShop.Application.Services.Users.Commands.Update;
using OnlineShop.Application.Services.Users.Queries.Get;
using OnlineShop.Application.Services.Users.Queries.GetRoles;
using OnlineShop.Domain.Entities.Users;

namespace EndPoint.Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IGetUserService _getUserService;
        private readonly IGetUserRolesService _getUserRolesService;
        private readonly ICreateUserService _createUserService;
        private readonly IDeleteUserService _deleteUserService;
        private readonly IChangeUserStatusService _changeUserStatusService;
        private readonly IUpdateUserService _updateUserService;

        public UserController(IGetUserService get,
            IGetUserRolesService getUserR,
            ICreateUserService create,
            IDeleteUserService delete,
            IChangeUserStatusService change,
            IUpdateUserService update)
        {
            _getUserService = get;
            _getUserRolesService = getUserR;
            _createUserService = create;
            _deleteUserService = delete;
            _changeUserStatusService = change;
            _updateUserService = update;
        }

        public async Task<IActionResult> Index([FromQuery]string searchKey, int page = 1)
        {
            ViewBag.Statuses = new SelectList(Enum.GetValues(typeof(UserStatus)).Cast<UserStatus>().ToList());

            return View(await _getUserService.ExecuteAsync(new GetUserRequestInfo
            {
                SearchKey = searchKey,
                Page = page
            }));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = new SelectList((await _getUserRolesService.ExcuteAsync()).Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string userName, string email, string phoneNumber, ulong roleId, string password)
        {
            var result = await _createUserService.ExcuteAsync(new CreateUserRequestInfo
            {
                UserName = userName,
                Email = email,
                Phone = phoneNumber,
                Password = password,
                Roles = new List<RolesInCreateUserRequestInfo>
                {
                    new RolesInCreateUserRequestInfo
                    {
                        Id = roleId
                    }
                }
            });

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ulong userId)
        {
            return Json(await _deleteUserService.ExcuteAsync(userId));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(ulong userId, UserStatus status)
        {
            return Json(await _changeUserStatusService.ExcuteAsync(userId, status));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ulong userId, string userName, string phone, string password, UserStatus status)
        {
            return Json(await _updateUserService.ExcuteAsync(new UpdateUserRequestInfo
            {
                Id = userId,
                UserName = userName,
                Phone = phone,
                Password = password,
                Status = status
            }));
        }
    }
}
