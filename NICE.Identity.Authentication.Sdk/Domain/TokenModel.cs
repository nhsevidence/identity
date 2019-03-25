using System;
using System.Collections.Generic;
using System.Text;

namespace NICE.Identity.Authentication.Sdk.Domain
{
	public class TokenModel
	{
		public string AccessToken { get; set; }

		public string IdToken { get; set; }

		public string RefreshToken { get; set; }
	}
}
