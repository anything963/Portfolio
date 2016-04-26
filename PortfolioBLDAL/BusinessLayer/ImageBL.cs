using PortfolioBLDAL.DataLayer;
using PortfolioBLDAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBLDAL.BusinessLayer
{
    class ImageBL
    {
        public static IEnumerable<Image> ProjectImagesSelect(int projectId)
        {
            List<Image> images = new List<Image>();
            try
            {
                ImageDAL imageDal = new ImageDAL();
                SqlDataReader data = imageDal.ImageListSelect(projectId);
                while (data.Read())
                {
                    Image image = new Image();
                    image = MapDataReaderImage(data);
                    image.imageType = ImageTypeBL.ImageTypeSelect(image.imageTypeId);
                    images.Add(image);
                }
            }
            catch (Exception ex)
            {

                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true") { throw ex; }
                return new List<Image>();
            }
            return images;
        }

        private static Image MapDataReaderImage(SqlDataReader reader)
        {
            Image image = new Image();
            if (!reader.IsDBNull(reader.GetOrdinal("imageId"))) image.imageId = reader.GetInt32(reader.GetOrdinal("imageId"));
            if (!reader.IsDBNull(reader.GetOrdinal("title"))) image.title = reader.GetString(reader.GetOrdinal("title"));
            if (!reader.IsDBNull(reader.GetOrdinal("description"))) image.description = reader.GetString(reader.GetOrdinal("description"));
            if (!reader.IsDBNull(reader.GetOrdinal("path"))) image.path = reader.GetString(reader.GetOrdinal("path"));
            if (!reader.IsDBNull(reader.GetOrdinal("projectId"))) image.projectId = reader.GetInt32(reader.GetOrdinal("projectId"));
            if (!reader.IsDBNull(reader.GetOrdinal("imageTypeId"))) image.imageTypeId = reader.GetInt32(reader.GetOrdinal("imageTypeId"));
            if (!reader.IsDBNull(reader.GetOrdinal("create_timestamp"))) image.create_timestamp = reader.GetDateTime(reader.GetOrdinal("create_timestamp"));
            if (!reader.IsDBNull(reader.GetOrdinal("update_timestamp"))) image.update_timestamp = reader.GetDateTime(reader.GetOrdinal("update_timestamp"));

            return image;
        } 
    }
}
