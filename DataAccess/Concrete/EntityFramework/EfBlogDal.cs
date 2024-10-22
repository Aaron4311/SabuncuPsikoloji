using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityBaseRepository<Blog, SabuncuPsikolojiDbContext>, IBlogDal
    {
        public async Task<Blog> GetBlogByUrl(string blogUrl)
        {
            using (var context = new SabuncuPsikolojiDbContext())
            {
                var result = await context.Blogs.FirstOrDefaultAsync(x => x.BlogUrl == blogUrl);
                return result;
            }
        }
    }
}
