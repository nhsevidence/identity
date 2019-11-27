using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using NICE.Identity.Authorisation.WebAPI.ApiModels;
using NICE.Identity.Authorisation.WebAPI.Repositories;

namespace NICE.Identity.Authorisation.WebAPI.Services
{
    public interface IWebsitesService
    {
        Website CreateWebsite(Website website);
        Website GetWebsite(int websiteId);
        List<Website> GetWebsites();
        Website UpdateWebsite(int websiteId, Website website);
        int DeleteWebsite(int websiteId);
    }

    public class WebsitesService: IWebsitesService
    {
        private IdentityContext _context;
        private ILogger<WebsitesService> _logger;
        public WebsitesService(IdentityContext context, ILogger<WebsitesService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public Website CreateWebsite(Website website)
        {
            try
            {
                var websiteToCreate = new DataModels.Website();
                websiteToCreate.UpdateFromApiModel(website);
                var createdWebsite = _context.Websites.Add(websiteToCreate);
                _context.SaveChanges();
                return new Website(createdWebsite.Entity);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to create website. Exception: {e.Message}");
                throw new Exception($"Failed to create website. Exception: {e.Message}");
            }
        }

        public List<Website> GetWebsites()
        {
            return _context.Websites.Select(website => new Website(website)).ToList();
        }

        public Website GetWebsite(int websiteId)
        {
            var website = _context.Websites.Where((w => w.WebsiteId == websiteId)).FirstOrDefault();
            return website != null ? new Website(website) : null;
        }

        public Website UpdateWebsite(int websiteId, Website website)
        {
            try
            {
                var websiteToUpdate = _context.Websites.Find(websiteId);
                if (websiteToUpdate == null)
                    throw new Exception($"Website not found {websiteId.ToString()}");

                Console.Write(websiteToUpdate.WebsiteId);
                websiteToUpdate.UpdateFromApiModel(website);
                _context.SaveChanges();
                return new Website(websiteToUpdate);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to update website {websiteId.ToString()} - exception: {e.InnerException.Message}");
                throw new Exception($"Failed to update website {websiteId.ToString()} - exception: {e.InnerException.Message}");
            }
        }

        public int DeleteWebsite(int websiteId)
        {
            throw new System.NotImplementedException();
        }
    }
}