﻿using Newtonsoft.Json;
using NICE.Identity.Authentication.Sdk.Configuration;
using NICE.Identity.Authentication.Sdk.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Claim = NICE.Identity.Authentication.Sdk.Domain.Claim;

namespace NICE.Identity.Authentication.Sdk.Authorisation
{
	internal static class ClaimsHelper
	{
		internal static async Task<IList<System.Security.Claims.Claim>> AddClaimsToUser(IAuthConfiguration authConfiguration, string userId, string accessToken, IEnumerable<string> hosts, HttpClient client)
		{
			var uri = new Uri($"{authConfiguration.WebSettings.AuthorisationServiceUri}{Constants.AuthorisationURLs.GetClaims}{WebUtility.UrlEncode(userId)}");
			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri)
			{
				Headers = { Authorization = new AuthenticationHeaderValue(AuthenticationConstants.JWTAuthenticationScheme, accessToken) }
			};
			var responseMessage = await client.SendAsync(httpRequestMessage); //call the api to get all the claims for the current user
			if (responseMessage.IsSuccessStatusCode)
			{
				var allClaims = JsonConvert.DeserializeObject<Claim[]>(await responseMessage.Content.ReadAsStringAsync());
				//add in all the claims from retrieved from the api, excluding roles where the host doesn't match the current.
				var claimsToAdd = allClaims.Where(claim => (!claim.Type.Equals(ClaimType.Role)) ||
				                                           (claim.Type.Equals(ClaimType.Role) &&
				                                            hosts.Contains(claim.Issuer, StringComparer.OrdinalIgnoreCase)))
					.Select(claim => new System.Security.Claims.Claim(claim.Type, claim.Value, null, claim.Issuer)).ToList();

				return claimsToAdd;
			}
			else
			{
				throw new Exception($"Error {(int)responseMessage.StatusCode} trying to set claims when signing in to uri: {uri} using access token: {accessToken}"); //TODO: remove access token from error message.
			}
		}

		internal class RefreshTokenResponse
		{
			public bool Valid => (!string.IsNullOrEmpty(AccessToken) || (ExpiresInSeconds > 0));

			[JsonProperty(AuthenticationConstants.Tokens.AccessToken)]
			public string AccessToken { get; set; }

			[JsonProperty(AuthenticationConstants.Tokens.ExpiresIn)]
			public int ExpiresInSeconds { get; set; }
		}


		internal static async Task<RefreshTokenResponse> UpdateAccessToken(IAuthConfiguration authConfiguration, string refreshToken, HttpClient client)
		{
			var uri = new Uri($"https://{authConfiguration.TenantDomain}/oauth/token");

			var request = new HttpRequestMessage(HttpMethod.Post, uri)
			{
				Content = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string, string>("grant_type", AuthenticationConstants.Tokens.RefreshToken),
					new KeyValuePair<string, string>("client_id", authConfiguration.WebSettings.ClientId),
					new KeyValuePair<string, string>("client_secret", authConfiguration.WebSettings.ClientSecret),
					new KeyValuePair<string, string>(AuthenticationConstants.Tokens.RefreshToken, refreshToken)
				})
			};
			var responseMessage = await client.SendAsync(request);
			if (responseMessage.IsSuccessStatusCode)
			{
				var responseBody = await responseMessage.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<RefreshTokenResponse>(responseBody);
			}
			else if (responseMessage.StatusCode.Equals(HttpStatusCode.Forbidden)) //refresh code was revoked at auth0.
			{
				return new RefreshTokenResponse();  //this returns an empty response message, with Valid set to false.
			}
			throw new Exception($"Error {(int)responseMessage.StatusCode} trying to use refresh token: {refreshToken}");
		}
	}
}
