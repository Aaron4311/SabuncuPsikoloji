using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Сoncrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
        {
            var claims = await _userService.GetClaimsAsync(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.accessTokenCreated);
        }

        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMailAsync(userForLoginDto.Email).Result;
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.userDidNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.userDidNotFound);
            }
            return new SuccessDataResult<User>(userToCheck.Data, Messages.loginSuccessful);
        }


        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public async Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            await _userService.AddAsync(user);
            return new SuccessDataResult<User>(user, Messages.userIsRegistered);
        }

        public async Task<IResult> UserExistsAsync(string email)
        {
            if (_userService.GetByMailAsync(email).Result.Data != null)
            {
                return new ErrorResult(Messages.userExists);
            }
            return new SuccessResult();
        }
    }
}
