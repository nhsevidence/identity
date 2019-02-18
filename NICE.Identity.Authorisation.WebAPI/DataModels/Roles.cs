﻿using System;
using System.Collections.Generic;

namespace NICE.Identity.Authorisation.WebAPI.DataModels
{
    public partial class Roles
    {

        public Roles()
        {
            UserRoles = new HashSet<UserRoles>();
        }

		public Roles(int roleId, int websiteId, string name)
		{
			RoleId = roleId;
			WebsiteId = websiteId;
			Name = name;
			UserRoles = new HashSet<UserRoles>(); ;
		}

		public int RoleId { get; set; }
        public int WebsiteId { get; set; }
        public string Name { get; set; }

        public Websites Website { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}