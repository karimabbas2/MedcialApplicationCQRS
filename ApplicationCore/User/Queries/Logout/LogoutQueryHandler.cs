using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.User.Queries.Logout
{
    public class LogoutQueryHandler(SignInManager<ApplicationDomain.User> signInManager) : IRequestHandler<LogoutQuery, ServiceResponse>
    {

        private readonly SignInManager<ApplicationDomain.User> _signInManager = signInManager;

        public async Task<ServiceResponse> Handle(LogoutQuery request, CancellationToken cancellationToken)
        {
            
            // HttpContext httpContext;
            // httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _signInManager.SignOutAsync();
            return new ServiceResponse(true, "Logout Successfully");

        }
    }
}