using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Validations.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
           _blogDal = blogDal;
        }
        [ValidationAspect(typeof(BlogValidator))]
        //[SecuredOperation("admin")]
        public async Task<IResult> AddAsync(Blog blog)
        {
            await _blogDal.AddAsync(blog);
            return new SuccessResult(Messages.BlogIsAdded);
        }
        //[SecuredOperation("admin")]
        public async Task<IResult> DeleteAsync(int id)
        {
            var blogToDelete = _blogDal.GetAsync(x => x.Id == id).Result;
            await _blogDal.DeleteAsync(blogToDelete);
            return new SuccessResult(Messages.BlogIsRemoved);
        }

        public async Task<IDataResult<List<Blog>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Blog>>(await _blogDal.GetAllAsync(), Messages.BlogsAreListed);
        }

        public async Task<IDataResult<Blog>> GetAsync(int id)
        {
            return new SuccessDataResult<Blog>(await _blogDal.GetAsync(x => x.Id == id), Messages.BlogIsListed);
        }

        public async Task<IDataResult<Blog>> GetBlogByUrl(string blogUrl)
        {
            return new SuccessDataResult<Blog>(await _blogDal.GetBlogByUrl(blogUrl), Messages.BlogIsListed);
        }

        [ValidationAspect(typeof(BlogValidator))]
        //[SecuredOperation("admin")]
        public async Task<IResult> UpdateAsync(Blog blog)
        {
            await _blogDal.UpdateAsync(blog);
            return new SuccessResult(Messages.BlogIsUpdated);
        }
    }
}
