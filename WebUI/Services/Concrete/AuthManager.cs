using Microsoft.Extensions.Options;
using WebUI.Areas.Admin.Models;
using WebUI.Models;
using WebUI.Services.Abstract;
using System.Text.Json;
using System.Net.Http.Headers;

namespace WebUI.Services.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public AuthManager(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _baseApiUrl = _baseApiUrl + "/Auth";
        }

        public async Task<AuthResult> LoginAsync(LoginViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7075/api/Auth/Login",model);
            response.EnsureSuccessStatusCode(); // Hata durumunda exception fırlatır

            // JSON içeriğini Auth modeline dönüştür
            var authResult = await JsonSerializer.DeserializeAsync<AuthResult>(
                await response.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.Token);
            return authResult; // Auth modelini döndür
        }
    }
}
