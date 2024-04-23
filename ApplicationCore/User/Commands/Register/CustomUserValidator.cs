using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApplicationDomain;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.User.Commands.Register
{
    public partial class CustomUserValidator<TUser> : IUserValidator<TUser> where TUser : class
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {
            var errors = new List<IdentityError>();

            if (user is ApplicationDomain.User user1 && !IsValidUserName(user1.UserName))
            {
                errors.Add(new IdentityError
                {
                    Code = "InvalidUserName",
                    Description = "Username can only contain letters, digits, and spaces."
                });
            }
            return Task.FromResult(errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed([.. errors]));
        }

        private bool IsValidUserName(string userName)
        {
            return MyRegex().IsMatch(userName);

        }

        [GeneratedRegex(@"^[a-zA-Z0-9\s]+$")]
        private static partial Regex MyRegex();
    }

}