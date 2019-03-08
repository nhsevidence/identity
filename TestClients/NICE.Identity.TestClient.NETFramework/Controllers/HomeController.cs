﻿using NICE.Identity.NETFramework.Nuget;
using System.Web.Mvc;

namespace NICE.Identity.TestClient.NETFramework.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[Authorise]
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[Authorise(Roles = "Administrator")]
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}