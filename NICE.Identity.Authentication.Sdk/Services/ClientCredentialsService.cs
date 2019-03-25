using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NICE.Identity.Authentication.Sdk.Abstractions;
using NICE.Identity.Authentication.Sdk.Domain;
using NICE.Identity.Authentication.Sdk.External;

namespace NICE.Identity.Authentication.Sdk.Services
{
	public interface IClientCredentialsService
	{
		Task<JwtToken> GetToken(ClientCredentialsTokenRequest clientCredentialsTokenRequest);
	}

	public class ClientCredentialsService : IClientCredentialsService
	{
		private readonly IHttpClientDecorator _httpClient;

		public ClientCredentialsService(IHttpClientDecorator httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<JwtToken> GetToken(ClientCredentialsTokenRequest clientCredentialsTokenRequest)
		{
			var httpResponseMessageresponse = await _httpClient.PostAsync("oauth/token", new StringContent(JsonConvert.SerializeObject(clientCredentialsTokenRequest), Encoding.UTF8, "application/json"));
			if (httpResponseMessageresponse.StatusCode != HttpStatusCode.OK)
			{
				throw new HttpRequestException("An Error Occured");
			}

			var token = await httpResponseMessageresponse.Content.ReadAsAsync<JwtToken>();

			return token;
		}
	}
}
