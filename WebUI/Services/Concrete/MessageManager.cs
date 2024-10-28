using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public MessageManager(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _baseApiUrl = apiSettings.Value.BaseApiUrl + "/Message";
        }

        public async Task<bool> AddMessageAsync(MessageModel message)
        {
            var jsonContent = JsonConvert.SerializeObject(message);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseApiUrl}/Add", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<MessageResponseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<MessageResponseDto>>(result);
                return json;
            }
            return null;
        }
        public async Task<MessageResponseDto> GetMessageAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/Get/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<MessageResponseDto>(result);
                return json;
            }
            return null;
        }
    }
}
