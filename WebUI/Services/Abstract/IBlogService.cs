using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface IBlogService
    {
        Task<List<BlogResponseDto>> GetAllAsync();
        Task<BlogResponseDto> GetBlogByUrlAsync(string blogUrl);
        Task<bool> AddBlogAsync(BlogModel blogModel);
        Task<bool> UpdateBlogAsync(BlogModel blogModel);
        Task<bool> DeleteBlog(int id);

    }
}
