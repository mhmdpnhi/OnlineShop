﻿using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Commands.Update
{
    public interface IUpdateUserService
    {
        Task<ResultDto> ExcuteAsync(UpdateUserRequestInfo req);
    }
}
