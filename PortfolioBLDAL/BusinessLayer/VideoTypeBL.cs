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
    class VideoTypeBL
    {
        public static VideoType VideoTypeSelect(int videoTypeId)
        {
            VideoType videoType = new VideoType();
            try
            {
                VideoTypeDAL videoTypeDal = new VideoTypeDAL();
                SqlDataReader reader = videoTypeDal.VideoTypeSelect(videoTypeId);
                while (reader.Read())
                {
                    videoType = MapDataReaderVideoType(reader);
                }
            }
            catch (Exception ex)
            {

                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true") { throw ex; }
            }
            return videoType;
        }
        private static VideoType MapDataReaderVideoType(SqlDataReader reader)
        {
            VideoType videoType = new VideoType();
            if (!reader.IsDBNull(reader.GetOrdinal("videoTypeId"))) videoType.videoTypeId = reader.GetInt32(reader.GetOrdinal("videoTypeId"));
            if (!reader.IsDBNull(reader.GetOrdinal("title"))) videoType.title = reader.GetString(reader.GetOrdinal("title"));
            if (!reader.IsDBNull(reader.GetOrdinal("description"))) videoType.description = reader.GetString(reader.GetOrdinal("description"));
            return videoType;
        }
    }
}
