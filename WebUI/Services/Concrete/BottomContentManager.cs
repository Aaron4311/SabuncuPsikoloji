using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class BottomContentManager : IBottomContentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BottomContentManager(HttpClient httpClient, IOptions<ApiSettings> apiSettings, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _baseApiUrl = apiSettings.Value.BaseApiUrl + "/BottomContent";
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<BottomContentResponseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var sliders = JsonConvert.DeserializeObject<List<BottomContentResponseDto>>(responseContent);
                return sliders.ToList();
            }
            return null;
        }

        public async Task<BottomContentResponseDto> GetBottomContentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/Get/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<BottomContentResponseDto>(result);
                return json;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(BottomContentResponseDto bottomContentResponseDto)
        {
            var jsonContent = JsonConvert.SerializeObject(bottomContentResponseDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseApiUrl}/Update", content);
            return response.IsSuccessStatusCode;
        }
    }
}
