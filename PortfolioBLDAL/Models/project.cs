using System;
using System.Collections.Generic;

namespace PortfolioBLDAL.Models
{
    public class Project
    {
        public Project()
        {
            portfolio = new Portfolio();
            dateUpdated = DateTime.Now;
            projectType = new List<ProjectType>();
        }
        public int projectId { get; set; }
        public int portfolioId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime dateAdded { get; set; }
        public DateTime dateUpdated { get; set; }
        public string otherDetails { get; set; }
        public string studentId { get; set; }
        public string sectionId { get; set; }
        public string public_status { get; set; }
        public string active_status { get; set; }

        public List<ProjectType> projectType { get; set; }

        public Portfolio portfolio { get; set; }

        
    }
}