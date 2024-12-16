using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface ITopContentService
    {
        Task<List<TopContentResponseDto>> GetAllAsync();
        Task<TopContentResponseDto> GetTopContentByIdAsync(int id);
        Task<bool> UpdateAsync(TopContentResponseDto topContentResponseDto);
    }
}
