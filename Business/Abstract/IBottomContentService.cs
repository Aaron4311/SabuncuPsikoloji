using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBottomContentService
    {
        Task<IDataResult<List<BottomContent>>> GetAllAsync();
        Task<IDataResult<BottomContent>> GetAsync(int id);
        Task<IResult> AddAsync(BottomContent bottomContent);
        Task<IResult> UpdateAsync(BottomContent bottomContent);
        Task<IResult> DeleteAsync(int id);
    }
}
