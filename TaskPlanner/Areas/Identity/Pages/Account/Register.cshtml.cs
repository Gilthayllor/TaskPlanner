using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskPlanner.Services.Interfaces;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;


        [BindProperty]
        public UserRegisterViewModel UserRegisterForm { get; set; } = new UserRegisterViewModel();

        public string ErrorMessage { get; set; } = string.Empty;

        public bool Success { get; set; }

        public RegisterModel(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _contextAccessor = httpContextAccessor;
        }

        public IActionResult OnGet()
        {
            if (_contextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false)
            {
                return Redirect("/");
            }

            Success = false;
            UserRegisterForm = new UserRegisterViewModel();
            ErrorMessage = string.Empty;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _userService.RegisterAsync(UserRegisterForm);

            if (!result.Success)
            {
                ErrorMessage = result.Errors?.FirstOrDefault() ?? "Ocorreu um erro ao fazer o registro do usuário.";
            }
            else
            {
                Success = true;
            }

            return Page();
        }
    }
}
