﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRec.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
            :base()
        {

        }

        public ApplicationRole(string roleName)
            :base(roleName)
        {

        }
    }
}