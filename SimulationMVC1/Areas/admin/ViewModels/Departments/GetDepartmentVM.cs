﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulationMVC1.Areas.admin.ViewModels
{
    public class GetDepartmentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeCount { get; set; }
    }
}
