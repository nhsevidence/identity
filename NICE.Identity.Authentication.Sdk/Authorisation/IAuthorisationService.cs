﻿using System.Collections.Generic;
using System.Threading.Tasks;
using NICE.Identity.Authentication.Sdk.Domain;

namespace NICE.Identity.Authentication.Sdk.Authorisation
{
    public interface IAuthorisationService
    {
        Task<IEnumerable<Claim>> GetByUserId(string userId);

        Task CreateOrUpdate(string userId, Claim role);

        Task<bool> UserSatisfiesAtLeastOneRoleForAGivenHost(string userId, IEnumerable<string> roles, string host);
    }
}