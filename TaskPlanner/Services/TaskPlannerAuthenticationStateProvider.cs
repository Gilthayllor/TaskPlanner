using Microsoft.AspNetCore.Components.Authorization;

namespace TaskPlanner.Services
{
    public class TaskPlannerAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(new System.Security.Claims.ClaimsPrincipal()));
        }
    }
}
