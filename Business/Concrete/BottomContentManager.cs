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
    public class BottomContentManager : IBottomContentService
    {
        private readonly IBottomContentDal _bottomContentDal;

        public BottomContentManager(IBottomContentDal bottomContentDal)
        {
            _bottomContentDal = bottomContentDal;
        }

        public async Task<IResult> AddAsync(BottomContent bottomContent)
        {
            await _bottomContentDal.AddAsync(bottomContent);
            return new SuccessResult(Messages.sliderIsAdded);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var commentToDelete = await _bottomContentDal.GetAsync(x => x.Id == id);
            await _bottomContentDal.DeleteAsync(commentToDelete);
            return new SuccessResult(Messages.sliderIsDeleted);
        }

        public async Task<IDataResult<List<BottomContent>>> GetAllAsync()
        {
            return new SuccessDataResult<List<BottomContent>>(await _bottomContentDal.GetAllAsync(), Messages.slidersAreListed);
        }

        public async Task<IDataResult<BottomContent>> GetAsync(int id)
        {
            return new SuccessDataResult<BottomContent>(await _bottomContentDal.GetAsync(x => x.Id == id), Messages.sliderIsListed);
        }


        public async Task<IResult> UpdateAsync(BottomContent bottomContent)
        {
            await _bottomContentDal.UpdateAsync(bottomContent);
            return new SuccessResult(Messages.sliderIsUpdated);
        }
    }
}
