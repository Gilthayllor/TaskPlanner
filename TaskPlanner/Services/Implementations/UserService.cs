using Microsoft.AspNetCore.Identity;
using TaskPlanner.Entities;
using TaskPlanner.Services.Interfaces;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ResultViewModel> LoginAsync(LoginViewModel loginViewModel)
        {
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            var result = await _signInManager.PasswordSignInAsync(user ?? new ApplicationUser(), loginViewModel.Password, loginViewModel.Remember, false);

            if (!result.Succeeded)
            {
                return new ResultViewModel<LoginResultViewModel>("Usuário ou senha incorretos.");
            }

            return result.Succeeded ? new ResultViewModel() : new ResultViewModel("Usuário ou senha incorretos.");
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ResultViewModel> RegisterAsync(UserRegisterViewModel userRegisterViewModel)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = userRegisterViewModel.FirstName,
                LastName = userRegisterViewModel.LastName,
                UserName = userRegisterViewModel.Email,
                Email = userRegisterViewModel.Email,
                NormalizedEmail = (userRegisterViewModel.Email ?? "").ToUpper(),
            };

            var result = await _userManager.CreateAsync(applicationUser, userRegisterViewModel.Password);

            return result switch
            {
                { Succeeded: true } => new ResultViewModel(),
                _ => new ResultViewModel(result.Errors.Select(x => x.Description))
            };
        }
    }
}
