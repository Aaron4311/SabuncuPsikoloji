using Core.DataAccess;
using Core.Entities.Сoncrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        public Task<List<OperationClaim>> GetClaimsAsync(User user);

    }
}
