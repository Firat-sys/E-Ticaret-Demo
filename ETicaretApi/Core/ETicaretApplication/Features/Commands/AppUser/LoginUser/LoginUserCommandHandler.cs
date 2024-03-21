using ETicaretApplication.Abstraction.Token;
using ETicaretApplication.DTOS;
using ETicaretApplication.Expections;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApplication.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<ETicaretApi_Domain.Entitys.Identity.AppUser> _userManager;

        readonly SignInManager<ETicaretApi_Domain.Entitys.Identity.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<ETicaretApi_Domain.Entitys.Identity.AppUser> userManager, SignInManager<ETicaretApi_Domain.Entitys.Identity.AppUser> signInManager,
            ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            ETicaretApi_Domain.Entitys.Identity.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
            {
                throw new NotFoundUserExpection();
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(200);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token,
                };
            }

            return new LoginUserErrorCommandResponse()
            {
                Message = "Kullanıcı adı veya şifre hatalı !"
            };
        }
    }
}

