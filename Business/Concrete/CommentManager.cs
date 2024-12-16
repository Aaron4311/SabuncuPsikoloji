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
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public async Task<IResult> AddAsync(Comment comment)
        {
            await _commentDal.AddAsync(comment);
            return new SuccessResult(Messages.sliderIsAdded);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var commentToDelete = await _commentDal.GetAsync(x => x.Id == id);
            await _commentDal.DeleteAsync(commentToDelete);
            return new SuccessResult(Messages.sliderIsDeleted);
        }

        public async Task<IDataResult<List<Comment>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Comment>>(await _commentDal.GetAllAsync(), Messages.slidersAreListed);
        }

        public async Task<IDataResult<Comment>> GetAsync(int id)
        {
            return new SuccessDataResult<Comment>(await _commentDal.GetAsync(x => x.Id == id), Messages.sliderIsListed);
        }


        public async Task<IResult> UpdateAsync(Comment comment)
        {
            await _commentDal.UpdateAsync(comment);
            return new SuccessResult(Messages.sliderIsUpdated);
        }
    }
}
