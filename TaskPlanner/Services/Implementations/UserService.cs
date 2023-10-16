using Microsoft.AspNetCore.Identity;
using TaskPlanner.Data;
using TaskPlanner.Entities;
using TaskPlanner.Services.Interfaces;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _dataContext;

        public UserService(UserManager<ApplicationUser> userManager, DataContext dataContext)
        {
            _userManager = userManager;
            _dataContext = dataContext;
        }

        public async Task<ResultViewModel<LoginResultViewModel>> LoginAsync(LoginViewModel loginViewModel)
        {
            var user = _dataContext.ApplicationUsers.FirstOrDefault(x => (x.UserName ?? "").ToUpper() == loginViewModel.Email.ToUpper());

            var isCorrectPassword = await _userManager.CheckPasswordAsync(user ?? new ApplicationUser(), loginViewModel.Password);

            if (user == null || !isCorrectPassword)
            {
                return new ResultViewModel<LoginResultViewModel>("Usuário ou senha incorretos.");
            }

            return new ResultViewModel<LoginResultViewModel>(new LoginResultViewModel
            {
                Email = user.UserName!,
                FirstName = user.FirstName,
                LastName = user.LastName
            });
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

            var result = await _userManager.CreateAsync(applicationUser);

            return result switch
            {
                { Succeeded: true } => new ResultViewModel(),
                _ => new ResultViewModel(result.Errors.Select(x => x.Description))
            };
        }
    }
}
