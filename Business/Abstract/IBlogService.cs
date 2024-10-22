using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        Task<IDataResult<List<Blog>>> GetAllAsync();
        Task<IDataResult<Blog>> GetAsync(int id);
        Task<IResult> AddAsync(Blog blog);
        Task<IResult> UpdateAsync(Blog blog);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<Blog>> GetBlogByUrl(string blogUrl);
    }
}
