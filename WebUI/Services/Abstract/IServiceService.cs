using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface IServiceService
    {
        Task<List<ServiceResponseDto>> GetAllAsync();
        Task<ServiceResponseDto> GetServiceByUrl(string serviceUrl);
    }
}
