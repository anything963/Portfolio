using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioWebApi.Models
{
    public class ImageModel
    {
        public int imageId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string path { get; set; }
        public ImageTypeModel imageType { get; set; }
    }
}