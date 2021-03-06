﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBLDAL.Models
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Portfolio
    {
        public Portfolio()
        {
            projectList = new List<Project>();
        }
        public int portfolioId { get; set; }
        public string studentId { get; set; }
        public string public_status { get; set; }

        public IEnumerable<Project> projectList { get; set; }
    }
}
