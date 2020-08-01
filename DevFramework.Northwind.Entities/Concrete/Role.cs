﻿using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class Role:IEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
