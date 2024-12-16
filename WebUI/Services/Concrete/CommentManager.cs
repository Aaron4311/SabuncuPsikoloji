using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentManager(HttpClient httpClient, IOptions<ApiSettings> apiSettings, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _baseApiUrl = apiSettings.Value.BaseApiUrl + "/Comment";
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<CommentResponseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<CommentResponseDto>>(responseContent);
                return comments.ToList();
            }
            return null;
        }

        public async Task<CommentResponseDto> GetCommentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/Get/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<CommentResponseDto>(result);
                return json;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(CommentResponseDto commentResponseDto)
        {
            var jsonContent = JsonConvert.SerializeObject(commentResponseDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseApiUrl}/Update", content);
            return response.IsSuccessStatusCode;
        }
    }
}
