﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using NICE.Identity.Authentication.Sdk.Domain;

namespace NICE.Identity.Authentication.Sdk.Authentication
{
	public class AuthenticationService : IAuthenticationService
    {

        public async Task Login(HttpContext context, string returnUrl = "/", bool goToRegisterPage = false)
        {
	        await context.ChallengeAsync(AuthenticationConstants.AuthenticationScheme,
		        new AuthenticationProperties
		        {
			        RedirectUri = returnUrl,
			        Items = {new KeyValuePair<string, string>(nameof(goToRegisterPage), goToRegisterPage.ToString().ToLower())}
		        });
        }

        public async Task Logout(HttpContext context, string returnUrl = "/")
        {
            await context.SignOutAsync(AuthenticationConstants.AuthenticationScheme, new AuthenticationProperties
            {
                // Indicate here where Auth0 should redirect the user after a logout.
                // Note that the resulting absolute Uri must be whitelisted in the 
                // **Allowed Logout URLs** settings for the client.
                RedirectUri = returnUrl
            });

            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}