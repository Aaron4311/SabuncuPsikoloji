using WebUI.Areas.Admin.Models;

namespace WebUI.Services.Abstract
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(LoginViewModel model);
    }
}
