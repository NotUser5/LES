using LES.Domain.ViewModels;

namespace LES.Domain.Core.Data
{
    public interface IAuthService
    {
        Task<AuthServiceResponse> SeedRolesAsync();
        Task<AuthServiceResponse> RegisterAsync(RegisterViewModel registerViewModel);
        Task<AuthServiceResponse> LoginAsync(LoginViewModel loginViewModel);
        Task<AuthServiceResponse> MakeAdminAsync(UpdatePermission updatePermission);
        Task<AuthServiceResponse> MakeOwnerAsync(UpdatePermission updatePermission);
    }
}
