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
    public class TopContentManager : ITopContentService
    {
        private readonly ITopContentDal _topContentDal;

        public TopContentManager(ITopContentDal topContentDal)
        {
            _topContentDal = topContentDal;
        }

        public async Task<IResult> AddAsync(TopContent topContent)
        {
            await _topContentDal.AddAsync(topContent);
            return new SuccessResult(Messages.sliderIsAdded);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var commentToDelete = await _topContentDal.GetAsync(x => x.Id == id);
            await _topContentDal.DeleteAsync(commentToDelete);
            return new SuccessResult(Messages.sliderIsDeleted);
        }

        public async Task<IDataResult<List<TopContent>>> GetAllAsync()
        {
            return new SuccessDataResult<List<TopContent>>(await _topContentDal.GetAllAsync(), Messages.slidersAreListed);
        }

        public async Task<IDataResult<TopContent>> GetAsync(int id)
        {
            return new SuccessDataResult<TopContent>(await _topContentDal.GetAsync(x => x.Id == id), Messages.sliderIsListed);
        }


        public async Task<IResult> UpdateAsync(TopContent topContent)
        {
            await _topContentDal.UpdateAsync(topContent);
            return new SuccessResult(Messages.sliderIsUpdated);
        }
    }
}
