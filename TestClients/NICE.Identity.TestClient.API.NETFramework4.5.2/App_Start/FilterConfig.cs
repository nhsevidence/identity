﻿using System.Web;
using System.Web.Mvc;

namespace NICE.Identity.TestClient.API.NETFramework4._5._2
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
