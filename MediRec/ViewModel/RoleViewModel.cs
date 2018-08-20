﻿using MediRec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRec.ViewModel
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public RoleViewModel()
        {

        }


        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }
    }
}