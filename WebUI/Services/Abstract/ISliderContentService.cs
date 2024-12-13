using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface ISliderContentService
    {
        Task<List<SliderContentResponseDto>> GetAllAsync();
        Task<SliderContentResponseDto> GetSliderContentByIdAsync(int id);
        Task<bool> UpdateAsync(SliderContentResponseDto sliderContentResponseDto);
    }
}
