using OnlineShop.Application.Services.Authentications.Command.SignUp;
using OnlineShop.Common.Dto.Base;

namespace OnlineShop.Application.Services.Authentications.Query.SignIn
{
    public interface ISignInUserService
    {
        Task<ResultDto<SignInUserResultDto>> ExcuteAsync(SignInUserRequestInfo req);
    }
}
