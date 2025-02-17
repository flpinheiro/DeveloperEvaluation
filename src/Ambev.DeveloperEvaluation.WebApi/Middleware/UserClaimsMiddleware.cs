using Ambev.DeveloperEvaluation.Domain.Services;
using System.Security.Claims;

namespace Ambev.DeveloperEvaluation.WebApi.Middleware;
public class UserClaimsMiddleware
{
    private readonly RequestDelegate _next;

    public UserClaimsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserService userClaimsService)
    {
        var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim != null)
        {
            userClaimsService.UserId = userIdClaim.Value is not null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;
        }
        var userNameClain = context.User.FindFirst(ClaimTypes.Name);
        if (userNameClain != null)
        {
            userClaimsService.UserName = userNameClain.Value;
        }
        var userRoleClaim = context.User.FindFirst(ClaimTypes.Role);
        if (userRoleClaim != null)
        {
            userClaimsService.Role = userRoleClaim.Value;
        }

        await _next(context);
    }
}

