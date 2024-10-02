using OnlineShop.Common.Dto.Base;

namespace OnlineShop.Application.Services.Authentications.Command.SignUp
{
    public interface ISignUpUserService
    {
        Task<ResultDto<SignUpUserResultDto>> ExcuteAsync(SignUpUserRequestInfo req);
    }
}
