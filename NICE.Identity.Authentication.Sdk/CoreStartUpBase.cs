﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NICE.Identity.Authentication.Sdk.Extensions;
using NICE.Identity.Authentication.Sdk.Services;

namespace NICE.Identity.Authentication.Sdk
{
    public abstract class CoreStartUpBase : ICoreStartUpBase
    {
        protected readonly string clientName;
        protected readonly Func<IHostingEnvironment, IConfigurationBuilder> configurationFactory;
        protected readonly Func<IServiceCollection, IConfigurationRoot, IServiceCollection> configureVariantServices;
        protected IHostingEnvironment environment;
        protected IConfigurationRoot configuration;

        private const string AuthorisationServiceConfigurationPath = "AuthorisationServiceConfiguration";
        private const string RedisServiceConfigurationPath = "RedisServiceConfiguration";

        protected CoreStartUpBase(string clientName, 
                                  Func<IHostingEnvironment, IConfigurationBuilder> configurationFactory,
                                  Func<IServiceCollection, IConfigurationRoot, IServiceCollection> configureVariantServices)
        {
            this.clientName = clientName;
            this.configurationFactory = configurationFactory;
            this.configureVariantServices = configureVariantServices;
        }

        public IServiceProvider ServiceProvider { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var tempServiceProvider = services.BuildServiceProvider();
            environment = tempServiceProvider.GetService<IHostingEnvironment>();
            var configuration = configurationFactory(environment).Build();

            services.AddAuthenticationSdk(configuration, AuthorisationServiceConfigurationPath);
            services.AddRedisCacheSDK(configuration, RedisServiceConfigurationPath, clientName);
	        services.AddSingleton<IClientCredentialsService, ClientCredentialsService>();

            configureVariantServices(services, configuration);

            ServiceProvider = ConfigureInvariantServices(services, environment, configuration).BuildServiceProvider();

            return ServiceProvider;
        }

        /// <summary>
        /// Register dependencies that will never be mocked. Invariant services are those that will always
        /// be used, even if we are running some test flavour.
        /// </summary>
        protected abstract IServiceCollection ConfigureInvariantServices(IServiceCollection services, IHostingEnvironment env, IConfigurationRoot configuration);

        public virtual void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication()
               .UseSession();
        }
    }
}