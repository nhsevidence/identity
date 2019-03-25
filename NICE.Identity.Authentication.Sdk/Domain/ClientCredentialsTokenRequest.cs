using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NICE.Identity.Authentication.Sdk.Domain
{
	public class ClientCredentialsTokenRequest
	{
		[JsonProperty("audience")]
		public string Audience { get; set; }

		[JsonProperty("grant_type")]
		public string GrantType { get; set; }

		[JsonProperty("client_id")]
		public string ClientId { get; set; }

		[JsonProperty("client_secret")]
		public string ClientSecret { get; set; }
	}
}
