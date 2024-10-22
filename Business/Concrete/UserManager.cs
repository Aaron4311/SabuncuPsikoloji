using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Сoncrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        //[SecuredOperation("admin")]
        public async Task<IResult> AddAsync(User user)
        {
            await _userDal.AddAsync(user);
            return new SuccessResult(Messages.userIsAdded);
        }

        public async Task<IDataResult<User>> GetByMailAsync(string mail)
        {
            return new SuccessDataResult<User>(await _userDal.GetAsync(x => x.Email == mail));
        }

        public async Task<List<OperationClaim>> GetClaimsAsync(User user)
        {
            return await _userDal.GetClaimsAsync(user);
        }
    }
}
