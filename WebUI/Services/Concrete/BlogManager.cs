using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BlogManager(HttpClient httpClient, IOptions<ApiSettings> apiSettings, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _baseApiUrl = apiSettings.Value.BaseApiUrl + "/Blog";
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetAuthorizationHeader()
        {
            //var jwtToken = _httpContextAccessor.HttpContext.Session.GetString("JWToken");

            //if (!string.IsNullOrEmpty(jwtToken))
            //{
            //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            //}
        }

        public async Task<bool> AddBlogAsync(BlogModel blogModel)
        {
            SetAuthorizationHeader(); // Token'ı ayarla
            var jsonContent = JsonConvert.SerializeObject(blogModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseApiUrl}/Add", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBlog(int id)
        {
            SetAuthorizationHeader(); // Token'ı ayarla
            var response = await _httpClient.DeleteAsync($"{_baseApiUrl}/Delete/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<BlogResponseDto>> GetAllAsync()
        {
           /* SetAuthorizationHeader();*/ // Token'ı ayarla
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var blogs = JsonConvert.DeserializeObject<List<BlogResponseDto>>(responseContent).OrderByDescending(x => x.Id);
                return blogs.ToList();
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"API çağrısı başarısız: {response.StatusCode} - {errorContent}");
        }

        public async Task<BlogResponseDto> GetBlogByUrlAsync(string blogUrl)
        {
            SetAuthorizationHeader(); // Token'ı ayarla
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetByUrl/{blogUrl}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<BlogResponseDto>(result);
                return json;
            }
            return null;
        }

        public async Task<bool> UpdateBlogAsync(BlogModel blogModel)
        {
            SetAuthorizationHeader(); // Token'ı ayarla
            var jsonContent = JsonConvert.SerializeObject(blogModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseApiUrl}/Update", content);
            return response.IsSuccessStatusCode;
        }
    }
}
