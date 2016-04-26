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
    class ImageTypeBL
    {
        public static ImageType ImageTypeSelect(int imageTypeId)
        {
            ImageType imageType = new ImageType();
            try
            {
                ImageTypeDAL imageTypeDal = new ImageTypeDAL();
                SqlDataReader reader = imageTypeDal.ImageTypeSelect(imageTypeId);
                while (reader.Read())
                {
                    imageType = MapDataReaderImageType(reader);
                }
            }
            catch (Exception ex)
            {

                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true") { throw ex; }
            }
            return imageType;
        }
        private static ImageType MapDataReaderImageType(SqlDataReader reader)
        {
            ImageType imageType = new ImageType();
            if (!reader.IsDBNull(reader.GetOrdinal("imageTypeId"))) imageType.imageTypeId = reader.GetInt32(reader.GetOrdinal("imageTypeId"));
            if (!reader.IsDBNull(reader.GetOrdinal("title"))) imageType.title = reader.GetString(reader.GetOrdinal("title"));
            if (!reader.IsDBNull(reader.GetOrdinal("description"))) imageType.description = reader.GetString(reader.GetOrdinal("description"));
            return imageType;
        }
    }
}
