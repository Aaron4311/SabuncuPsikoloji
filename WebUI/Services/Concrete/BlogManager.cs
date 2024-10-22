using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public BlogManager(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _baseApiUrl = apiSettings.Value.BaseApiUrl + "/Blog";
        }

        public async Task<List<BlogResponseDto>> GetAll()
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<BlogResponseDto>>(result);
                return json;
            }
            return null;
        }

        public async Task<BlogResponseDto> GetBlogByUrl(string blogUrl)
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetByUrl/{blogUrl}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<BlogResponseDto>(result);
                return json;
            }
            return null;
        }

    }
}
