using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class PsychologistManager : IPsychologistService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public PsychologistManager(HttpClient httpClient, IOptions<ApiSettings> baseApiUrl)
        {
            _httpClient = httpClient;
            _baseApiUrl = baseApiUrl.Value.BaseApiUrl + "/Psychologist";
        }

        public async Task<List<PsychologistResponseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<PsychologistResponseDto>>(result);
                return json;
            }
            return null;
        }

        public async Task<PsychologistResponseDto> GetServiceByUrlAsync(string psychologistUrl)
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetByUrl/{psychologistUrl}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<PsychologistResponseDto>(result);
                return json;
            }
            return null;
        }
    }
}
