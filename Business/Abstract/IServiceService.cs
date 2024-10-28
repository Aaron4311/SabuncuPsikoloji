using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceService
    {
        Task<IDataResult<List<Service>>> GetAllAsync();
        Task<IDataResult<Service>> GetAsync(int id);
        Task<IResult> AddAsync(Service service);
        Task<IResult> UpdateAsync(Service service);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<Service>> GetServiceByUrl(string serviceUrl);
    }
}
