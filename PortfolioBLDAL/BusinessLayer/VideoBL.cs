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
    class VideoBL
    {
        public static IEnumerable<Video> ProjectVideosSelect(int projectId)
        {
            List<Video> videos = new List<Video>();
            try
            {
                VideoDAL videoDal = new VideoDAL();
                SqlDataReader data = videoDal.VideoListSelect(projectId);
                while (data.Read())
                {
                    Video video = new Video();
                    video = MapDataReaderVideo(data);
                    video.videoType = VideoTypeBL.VideoTypeSelect(video.videoTypeId);
                    videos.Add(video);
                }
            }
            catch (Exception ex)
            {

                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true") { throw ex; }
                return new List<Video>();
            }
            return videos;
        }

        private static Video MapDataReaderVideo(SqlDataReader reader)
        {
            Video video = new Video();
            if (!reader.IsDBNull(reader.GetOrdinal("videoId"))) video.videoId = reader.GetInt32(reader.GetOrdinal("videoId"));
            if (!reader.IsDBNull(reader.GetOrdinal("title"))) video.title = reader.GetString(reader.GetOrdinal("title"));
            if (!reader.IsDBNull(reader.GetOrdinal("description"))) video.description = reader.GetString(reader.GetOrdinal("description"));
            if (!reader.IsDBNull(reader.GetOrdinal("path"))) video.path = reader.GetString(reader.GetOrdinal("path"));
            if (!reader.IsDBNull(reader.GetOrdinal("projectId"))) video.projectId = reader.GetInt32(reader.GetOrdinal("projectId"));
            if (!reader.IsDBNull(reader.GetOrdinal("videoTypeId"))) video.videoTypeId = reader.GetInt32(reader.GetOrdinal("videoTypeId"));
            if (!reader.IsDBNull(reader.GetOrdinal("create_timestamp"))) video.create_timestamp = reader.GetDateTime(reader.GetOrdinal("create_timestamp"));
            if (!reader.IsDBNull(reader.GetOrdinal("update_timestamp"))) video.update_timestamp = reader.GetDateTime(reader.GetOrdinal("update_timestamp"));

            return video;
        }
    }
}
