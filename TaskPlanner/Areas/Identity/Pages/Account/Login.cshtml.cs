using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskPlanner.Services.Interfaces;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;

        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; } = new LoginViewModel();
        public string ErrorMessage { get; set; } = string.Empty;

        public LoginModel(IUserService userService, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
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
                return Redirect("/");
            }
            else
            {
                ErrorMessage = result.Errors.FirstOrDefault() ?? "Ocorreu um erro ao fazer login.";
            }

            return Page();
        }
    }
}
