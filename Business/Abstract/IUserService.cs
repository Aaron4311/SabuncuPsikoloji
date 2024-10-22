using Core.Entities.Сoncrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<List<OperationClaim>> GetClaimsAsync(User user);
        Task<IResult> AddAsync(User user);
        Task<IDataResult<User>> GetByMailAsync(string mail);

    }
}
