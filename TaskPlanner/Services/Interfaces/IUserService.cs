using TaskPlanner.ViewModels;

namespace TaskPlanner.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultViewModel> RegisterAsync(UserRegisterViewModel userRegisterViewModel);

        Task<ResultViewModel> LoginAsync(LoginViewModel loginViewModel);

        Task LogoutAsync();
    }
}
