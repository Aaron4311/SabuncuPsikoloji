using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        Task<IDataResult<List<Message>>> GetAllAsync();
        Task<IDataResult<Message>> GetAsync(int id);
        Task<IResult> AddAsync(Message message);
        Task<IResult> UpdateAsync(Message message);
        Task<IResult> DeleteAsync(int id);
    }
}
