using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<List<Comment>>> GetAllAsync();
        Task<IDataResult<Comment>> GetAsync(int id);
        Task<IResult> AddAsync(Comment comment);
        Task<IResult> UpdateAsync(Comment comment);
        Task<IResult> DeleteAsync(int id);
    }
}
