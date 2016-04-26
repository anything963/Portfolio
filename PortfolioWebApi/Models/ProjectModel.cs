using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortfolioBLDAL.Models;

namespace PortfolioWebApi.Models
{
    public class ProjectModel
    {
        public ProjectModel()
        {
            dateUpdated = DateTime.Now;
           //projectType = new List<ProjectType>();
        }
        public string Url { get; set; }
        public int projectId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime dateUpdated { get; set; }
        public string otherDetails { get; set; }

        public IEnumerable<ProjectTypeModel> projectType { get; set; }
        public IEnumerable<ImageModel> images { get; set; }

    }
}