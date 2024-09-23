using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Application.Services.Users.Queries.Get;
using OnlineShop.Application.Services.Users.Queries.GetRoles;

namespace EndPoint.Shop.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly IGetUserService _getUserService;
		private readonly IGetUserRolesService _getUserRolesService;

        public UserController(IGetUserService getUserService,
			IGetUserRolesService getUserRolesService)
        {
			_getUserService = getUserService;
			_getUserRolesService = getUserRolesService;
        }

        public async Task<IActionResult> Index(string searchKey, int page=1)
		{
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
	}
}
