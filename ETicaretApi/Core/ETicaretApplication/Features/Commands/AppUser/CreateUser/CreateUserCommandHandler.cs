using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApplication.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<ETicaretApi_Domain.Entitys.Identity.AppUser> _userManager ;
        public CreateUserCommandHandler(UserManager<ETicaretApi_Domain.Entitys.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
           

            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = request.Email,
                NameSurName = request.NameSurname,
                UserName = request.Username
            }, request.Password);

            CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}<br>";

            return response;
        }

        //public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        //{
        //    IdentityResult result = await _userManager.CreateAsync(new()
        //    {
        //        //Id = Guid.NewGuid().ToString(),
        //        Email = request.Email,
        //        NameSurName = request.NameSurname,
        //        //Password = request.Password,
        //        //PasswordConfirm = request.PasswordConfirm,
        //        UserName = request.Username,
        //    },request.Password);

        //    //return new()
        //    //{
        //    //    Message = "Kullanıcı oluşturuldu.",
        //    //    Succeeded = response.Succeeded,
        //    //};

        //    CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };

        //    if (result.Succeeded)
        //        response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
        //    else
        //        foreach (var error in result.Errors)
        //            response.Message += $"{error.Code} - {error.Description}<br>";

        //    return response;

        //    //throw new UserCreateFailedException();
        //}
    }

}
