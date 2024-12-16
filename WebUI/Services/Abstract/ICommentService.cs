using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface ICommentService
    {
        Task<List<CommentResponseDto>> GetAllAsync();
        Task<CommentResponseDto> GetCommentByIdAsync(int id);
        Task<bool> UpdateAsync(CommentResponseDto commentResponseDto);
    }
}
