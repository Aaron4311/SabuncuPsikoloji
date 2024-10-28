using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface IMessageService
    {
        Task<List<MessageResponseDto>> GetAllAsync();
        Task<MessageResponseDto> GetMessageAsync(int id);
        Task<bool> AddMessageAsync(MessageModel message);

    }
}
