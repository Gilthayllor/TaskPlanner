using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskPlanner.Services.Interfaces;

namespace TaskPlanner.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IUserService _userService;
        public LogoutModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGet()
        {
            await _userService.LogoutAsync();
            return Redirect("Login");
        }
    }

}
