using NorthwindBackend.Core.Entities.Concrete;
using NorthwindBackend.Core.Utilities.Results;
using NorthwindBackend.Core.Utilities.Security.Jwt;
using NorthwindBackend.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegister, string password);
        IDataResult<User> Register(UserForRegisterDto userForRegister);
        IDataResult<User> Login(UserForLoginDto userForLogin);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
