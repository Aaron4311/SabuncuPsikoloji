using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class TopContentManager : ITopContentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TopContentManager(HttpClient httpClient, IOptions<ApiSettings> apiSettings, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _baseApiUrl = apiSettings.Value.BaseApiUrl + "/TopContent";
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<TopContentResponseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var sliders = JsonConvert.DeserializeObject<List<TopContentResponseDto>>(responseContent);
                return sliders.ToList();
            }
            return null;
        }

        public async Task<TopContentResponseDto> GetTopContentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/Get/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<TopContentResponseDto>(result);
                return json;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(TopContentResponseDto topContentResponseDto)
        {
            var jsonContent = JsonConvert.SerializeObject(topContentResponseDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseApiUrl}/Update", content);
            return response.IsSuccessStatusCode;
        }
    }
}
