﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NICE.Identity.NETFramework.Nuget.External
{
    public interface IHttpClientDecorator
    {
        Task<string> GetStringAsync(Uri requestUri);

        Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content);
    }
}