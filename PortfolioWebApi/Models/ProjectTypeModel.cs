using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortfolioBLDAL.Models;

namespace PortfolioWebApi.Models
{
    public class ProjectTypeModel
    {
        public int typeId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}