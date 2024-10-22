using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface IBlogService
    {
        Task<List<BlogResponseDto>> GetAll();
        Task<BlogResponseDto> GetBlogByUrl(string blogUrl);

    }
}
