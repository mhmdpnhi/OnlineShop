using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Services.Users.Queries.Get;

namespace EndPoint.Shop.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly IGetUserService _getUserService;

        public UserController(IGetUserService getUserService)
        {
			_getUserService = getUserService;
        }

        public async Task<IActionResult> Index(string searchKey, int page=1)
		{
			return View(await _getUserService.ExecuteAsync(new GetUserRequestInfo
			{
				SearchKey = searchKey,
				Page = page
			}));
		}
	}
}
