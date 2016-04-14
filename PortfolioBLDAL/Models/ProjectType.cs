using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBLDAL.Models
{
    public class ProjectType
    {
        public int projectId { get; set; }
        public int typeId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
