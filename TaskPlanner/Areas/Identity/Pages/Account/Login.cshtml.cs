using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TaskPlanner.Data;
using TaskPlanner.Entities;
using TaskPlanner.Services.Interfaces;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly DataContext _dataContext;

        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; } = new LoginViewModel();
        public string ErrorMessage { get; set; } = string.Empty;

        public LoginModel(IUserService userService, IHttpContextAccessor contextAccessor, SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            if (_contextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false)
            {
                return Redirect("/");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _userService.LoginAsync(LoginViewModel);
            if (result.Success)
            {
                var user = result.Data!;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "user")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                if (_contextAccessor.HttpContext != null)
                {
                    var userFound = await _signInManager.UserManager.FindByIdAsync(user.Id);

                    var r = await _signInManager.PasswordSignInAsync(userFound, LoginViewModel.Password, false, false);

                    var a = _contextAccessor.HttpContext?.User?.Identity?.IsAuthenticated;

                    if (r.Succeeded)
                    return Redirect("/");
                }
                else
                {
                    ErrorMessage = "Ocorreu um erro ao fazer login.";
                }
            }
            else
            {
                ErrorMessage = result.Errors.FirstOrDefault() ?? "Ocorreu um erro ao fazer login.";
            }

            return Page();
        }
    }
}
