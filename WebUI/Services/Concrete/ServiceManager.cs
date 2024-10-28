using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public ServiceManager(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _baseApiUrl = apiSettings.Value.BaseApiUrl + "/Service";
        }

        public async Task<List<ServiceResponseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<ServiceResponseDto>>(result);
                return json;
            }
            return null;
        }

        public async Task<ServiceResponseDto> GetServiceByUrl(string blogUrl)
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetByUrl/{blogUrl}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<ServiceResponseDto>(result);
                return json;
            }
            return null;
        }
    }
}
