using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SliderContentManager : ISliderContentService
    {
        private readonly ISliderContentDal _sliderContentDal;

        public SliderContentManager(ISliderContentDal sliderContentDal)
        {
            _sliderContentDal = sliderContentDal;
        }

        public async Task<IResult> AddAsync(SliderContent sliderContent)
        {
            await _sliderContentDal.AddAsync(sliderContent);
            return new SuccessResult(Messages.sliderIsAdded);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var serviceToDelete = await _sliderContentDal.GetAsync(x => x.Id == id);
            await _sliderContentDal.DeleteAsync(serviceToDelete);
            return new SuccessResult(Messages.sliderIsDeleted);
        }

        public async Task<IDataResult<List<SliderContent>>> GetAllAsync()
        {
            return new SuccessDataResult<List<SliderContent>>(await _sliderContentDal.GetAllAsync(), Messages.slidersAreListed);
        }

        public async Task<IDataResult<SliderContent>> GetAsync(int id)
        {
            return new SuccessDataResult<SliderContent>(await _sliderContentDal.GetAsync(x => x.Id == id), Messages.sliderIsListed);
        }


        public async Task<IResult> UpdateAsync(SliderContent sliderContent)
        {
            await _sliderContentDal.UpdateAsync(sliderContent);
            return new SuccessResult(Messages.sliderIsUpdated);
        }
    }
}
