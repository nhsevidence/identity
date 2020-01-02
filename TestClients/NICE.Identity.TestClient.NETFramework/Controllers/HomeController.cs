﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using NICE.Identity.Authentication.Sdk.API;

namespace NICE.Identity.TestClient.NETFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _apiIdentifier;
        private readonly string _authorisationServiceUri;
        private readonly string _authDomain;
        //private readonly IHttpClientFactory _clientFactory;
        private readonly IAPIService _apiService;

        //public HomeController(IConfiguration configuration, IHttpClientFactory clientFactory, IAPIService apiService)
        //{
        //    _clientFactory = clientFactory;
        //    _apiService = apiService;
        //    _apiIdentifier = configuration.GetSection("WebAppConfiguration").GetSection("ApiIdentifier").Value;
        //    _authorisationServiceUri = configuration.GetSection("WebAppConfiguration").GetSection("AuthorisationServiceUri").Value;
        //    _authDomain = configuration.GetSection("WebAppConfiguration").GetSection("Domain").Value;
        //}

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> UserProfile()
        {
            //ViewData["IdToken"] = await HttpContext.GetTokenAsync("id_token");
            //ViewData["AccessToken"] = await HttpContext.GetTokenAsync("access_token");
            //ViewData["AccessTokenExpires"] = await HttpContext.GetTokenAsync("expires_at");
            //ViewData["TokenType"] = await HttpContext.GetTokenAsync("token_type");
            //ViewData["RefreshToken"] = await HttpContext.GetTokenAsync("refresh_token");

            //var currentUsersNameIdentifier = User.NameIdentifier();
            //try
            //{
            //    var users = await _apiService.FindUsers(new List<string> { currentUsersNameIdentifier });
            //    var firstUser = users.First();
            //    ViewData["Users.NameIdentifier"] = firstUser.NameIdentifier;
            //    ViewData["Users.DisplayName"] = firstUser.DisplayName;
            //    ViewData["Users.EmailAddress"] = firstUser.EmailAddress;
            //}
            //catch (Exception ex)
            //{
            //    ViewData["Users.NameIdentifier"] = "error:" + ex.ToString();
            //}

            //try
            //{
            //    var roles = await _apiService.FindRoles(new List<string> { currentUsersNameIdentifier },
            //        "dev-identitytestcore.nice.org.uk");

            //    ViewData["Roles"] = JsonConvert.SerializeObject(roles);
            //}
            //catch (Exception ex)
            //{
            //    ViewData["Roles"] = "error:" + ex.ToString();
            //}

            return View();
        }

        [Authorize]
        public async Task<ActionResult> ApiData()
        {
	        return View();
	        //    var client = _clientFactory.CreateClient("HttpClient");
	        //    var accessToken = await HttpContext.GetTokenAsync("access_token");

	        //    var request = new HttpRequestMessage()
	        //    {
	        //        RequestUri = new Uri($"{_apiIdentifier}/users"), //new Uri($"{_authorisationServiceUri}/api/users") , // new Uri($"{_apiIdentifier}/users"), //, //new Uri($"{_apiIdentifier}/users"), 
	        //        Method = HttpMethod.Get,
	        //        Headers = { Authorization = new AuthenticationHeaderValue("Bearer", accessToken) }
	        //    };

	        //    var response = await client.SendAsync(request);
	        //    if (response.IsSuccessStatusCode)
	        //    {
	        //        var usersResponse = await response.Content.ReadAsStringAsync();
	        //        var users = JsonConvert.DeserializeObject<List<UserViewModel>>(usersResponse);
	        //        return View(users);
	        //    }

	        //    return View("Error");
        }

        [Authorize(Roles= "Editor")]
        public ActionResult EditorAction()
        {
            ViewData["Message"] = "This action only available to someone with the role: Editor";

            return View("Index");
        }

        //[Authorize]
        //public IActionResult UserProfileScoped()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return RedirectToAction("Index");
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}