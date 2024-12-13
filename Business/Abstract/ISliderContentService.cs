using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISliderContentService
    {
        Task<IDataResult<List<SliderContent>>> GetAllAsync();
        Task<IDataResult<SliderContent>> GetAsync(int id);
        Task<IResult> AddAsync(SliderContent psychologist);
        Task<IResult> UpdateAsync(SliderContent psychologist);
        Task<IResult> DeleteAsync(int id);
    }
}
