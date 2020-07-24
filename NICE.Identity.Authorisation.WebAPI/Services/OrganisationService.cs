﻿using Microsoft.Extensions.Logging;
using NICE.Identity.Authorisation.WebAPI.APIModels;
using NICE.Identity.Authorisation.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NICE.Identity.Authorisation.WebAPI.Services
{
    public interface IOrganisationService
    {
        List<Organisation> GetOrganisations();
        Organisation CreateOrganisation(Organisation organisation);
        Organisation UpdateOrganisation(int organisationId, Organisation organisation);
        int DeleteOrganisation(int organisationId);
    }

    public class OrganisationService : IOrganisationService
    {
        private readonly IdentityContext _context;
        private readonly ILogger<OrganisationService> _logger;

        public OrganisationService(IdentityContext context, ILogger<OrganisationService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Organisation CreateOrganisation(Organisation organisation)
        {
            try
            {
                var organisationToCreate = new DataModels.Organisation();
                organisationToCreate.UpdateFromApiModel(organisation);
                var createdOrganisation = _context.Organisations.Add(organisationToCreate);
                _context.SaveChanges();
                return new Organisation(createdOrganisation.Entity);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to create organisation {organisation.Name} - exception: {e.Message}");
                throw new Exception($"Failed to create organisation {organisation.Name} - exception: {e.Message}");
            }
        }

        public List<Organisation> GetOrganisations()
        {
            return _context.Organisations.Select(organisation => new Organisation(organisation)).ToList();
        }

        public Organisation GetOrganisation(int organisationId)
        {
            var organisation = _context.Organisations.Where(organisation => organisation.OrganisationId == organisationId).FirstOrDefault();
            return organisation != null ? new Organisation(organisation) : null;
        }

        public Organisation UpdateOrganisation(int organisationId, Organisation organisation)
        {
            try
            {
                var organisationToUpdate = _context.Organisations.Find(organisationId);
                if (organisationToUpdate == null)
                    throw new Exception($"Organisation not found {organisationId.ToString()}");

                organisationToUpdate.UpdateFromApiModel(organisation);
                _context.SaveChanges();
                return new Organisation(organisationToUpdate);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to update role {organisationId.ToString()} - exception: {e.Message}");
                throw new Exception($"Failed to update role {organisationId.ToString()} - exception: {e.Message}");
            }
        }

        public int DeleteOrganisation(int organisationId)
        {
            try
            {
                var organisationToDelete = _context.Organisations.Find(organisationId);
                if (organisationToDelete == null)
                    return 0;
                _context.Organisations.RemoveRange(organisationToDelete);
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to delete organisation {organisationId.ToString()} - exception: {e.Message}");
                throw new Exception($"Failed to delete organisation {organisationId.ToString()} - exception: {e.Message}");
            }
        }
    }
}