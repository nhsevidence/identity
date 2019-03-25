using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NICE.Identity.Authentication.Sdk.Authorisation;
using NICE.Identity.Authentication.Sdk.Domain;
using NICE.Identity.Authentication.Sdk.Services;
using NICE.Identity.TestClient.NetCore.Models;

namespace NICE.Identity.TestClient.NetCore.Controllers
{
	public class HomeController : Controller
	{
		private readonly IClientCredentialsService _clientCredentialsService;

		public HomeController(IClientCredentialsService clientCredentialsService)
		{
			_clientCredentialsService = clientCredentialsService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		[Authorize(Policy = PolicyTypes.Editor)]
		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		//[Authorize(Roles = "Administrator,EditorSpecial")]
		//[Authorize(Policy = PolicyTypes.Administrator)]
		public IActionResult Privacy()
		{

			var token = _clientCredentialsService.GetToken(new ClientCredentialsTokenRequest()
			{
				ClientId = "",
				ClientSecret = "",
				Audience = "",
				GrantType = "client_credentials"
			});

			


			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[ApiExplorerSettings(IgnoreApi = true)]
        [Route("/signin-auth0")]
		public IActionResult CallBack()
		{
			return RedirectToAction("Index");
		}
    }
}