using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class SliderContentManager : ISliderContentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SliderContentManager(HttpClient httpClient, IOptions<ApiSettings> apiSettings, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _baseApiUrl = apiSettings.Value.BaseApiUrl + "/SliderContent";
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<SliderContentResponseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var sliders = JsonConvert.DeserializeObject<List<SliderContentResponseDto>>(responseContent);
                return sliders.ToList();
            }
            return null;
        }

        public async Task<SliderContentResponseDto> GetSliderContentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/Get/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<SliderContentResponseDto>(result);
                return json;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(SliderContentResponseDto sliderContentResponseDto)
        {
            var jsonContent = JsonConvert.SerializeObject(sliderContentResponseDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseApiUrl}/Update", content);
            return response.IsSuccessStatusCode;
        }
    }
}
