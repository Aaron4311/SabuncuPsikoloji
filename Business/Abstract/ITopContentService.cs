using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITopContentService
    {
        Task<IDataResult<List<TopContent>>> GetAllAsync();
        Task<IDataResult<TopContent>> GetAsync(int id);
        Task<IResult> AddAsync(TopContent topContent);
        Task<IResult> UpdateAsync(TopContent topContent);
        Task<IResult> DeleteAsync(int id);
    }
}
