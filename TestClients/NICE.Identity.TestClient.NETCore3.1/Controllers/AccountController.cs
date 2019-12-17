﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NICE.Identity.Authentication.Sdk.Authentication;
using System.Threading.Tasks;

namespace NICE.Identity.TestClient.NetCore.Controllers
{
	public class AccountController : Controller
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IAuthenticationService _niceAuthenticationService;

		public AccountController(IHttpContextAccessor httpContextAccessor, IAuthenticationService niceAuthenticationService)
		{
			_httpContextAccessor = httpContextAccessor;
			_niceAuthenticationService = niceAuthenticationService;
		}

		public async Task Login(string returnUrl = "/", bool goToRegisterPage = false)
		{
			await _niceAuthenticationService.Login(_httpContextAccessor.HttpContext, returnUrl, goToRegisterPage);
		}

		[Authorize]
		public async Task Logout(string returnUrl = "/")
		{
			await _niceAuthenticationService.Logout(_httpContextAccessor.HttpContext, returnUrl);
		}
	}
}