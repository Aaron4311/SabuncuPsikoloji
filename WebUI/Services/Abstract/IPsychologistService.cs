using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface IPsychologistService
    {
        Task<List<PsychologistResponseDto>> GetAllAsync();
        Task<PsychologistResponseDto> GetServiceByUrlAsync(string psychologistUrl);
    }
}
