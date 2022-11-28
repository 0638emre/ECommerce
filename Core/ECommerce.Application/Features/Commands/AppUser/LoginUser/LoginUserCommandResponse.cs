﻿using ECommerce.Application.DTOs;

namespace ECommerce.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
        
    }
    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }
    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
        public string Message { get; set; } 

    }
}
