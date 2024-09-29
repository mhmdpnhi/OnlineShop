using OnlineShop.Application.Interfaces.Contexts;
using OnlineShop.Common;

namespace OnlineShop.Application.Services.Users.Queries.Get
{
	public class GetUserService : IGetUserService
    {
        private IDataBaseContext _context { get; set; }

        public GetUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<GetUserResultDto> ExecuteAsync(GetUserRequestInfo request)
        {
            var users = _context.Users.AsQueryable();

            if (String.IsNullOrWhiteSpace(request.SearchKey) is false)
            {
                users = users.Where(u => u.UserName.Contains(request.SearchKey) || u.Email.Contains(request.SearchKey));
            }

            int rowsCount = 0;
            var resault = users.ToPaged(request.Page, 20, out rowsCount).Select(u => new GetUserDto
            {
                Id = u.Id, 
                UserName = u.UserName,
                Email = u.Email,
                Phone = u.Phone,
                Status = u.Status,
                Password = u.Password
            }).ToList();

            return new GetUserResultDto
            {
                Rows = rowsCount,
                Users = resault
            };
        }
    }
}
