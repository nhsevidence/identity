﻿using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NICE.Identity.Authorisation.WebAPI.DataModels
{
    public class Job
    {
        public Job()
        {

        }

        public Job(int jobId, int userId, int organisationId, bool isLead)
        {
            JobId = jobId;
            UserId = userId;
            OrganisationId = organisationId;
            IsLead = isLead;
        }

        public int JobId { get; set; }
        public int UserId { get; set; }
        public int OrganisationId { get; set; }
        public bool IsLead { get; set; }

        public User User { get; set; }
        public Organisation Organisation { get; set; }
    }
}
