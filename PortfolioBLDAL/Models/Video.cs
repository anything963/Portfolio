using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBLDAL.Models
{
    public class Video
    {
        public Video()
        {
            update_timestamp = DateTime.Now;
        }
        public int videoId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string path { get; set; }
        public int projectId { get; set; }
        public int videoTypeId { get; set; }
        public DateTime create_timestamp { get; set; }
        public DateTime update_timestamp { get; set; }

        public VideoType videoType { get; set; }
    }
}
