using Core.Entities.Сoncrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto, string password);
        Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto);
        Task<IResult> UserExistsAsync(string email);
        Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user);
    }
}
