using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface IBottomContentService
    {
        Task<List<BottomContentResponseDto>> GetAllAsync();
        Task<BottomContentResponseDto> GetBottomContentByIdAsync(int id);
        Task<bool> UpdateAsync(BottomContentResponseDto bottomContentResponseDto);
    }
}
