using PortfolioBLDAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBLDAL.DataLayer
{
    class VideoDAL: DBHelper
    {
        private SqlConnection _DBConn;

        public VideoDAL()
        {
            _DBConn = base.Connection;
        }

        public SqlDataReader VideoListSelect(int projectId)
        {
            SqlDataReader data;
            try
            {
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandText = "VideoList_Select";
                selectCommand.Connection = this._DBConn;
                selectCommand.Parameters.AddWithValue("@projectId", projectId);
                if (this._DBConn.State == ConnectionState.Closed)
                {
                    this._DBConn.Open();
                }
                data = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {

                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true")
                {
                    throw ex;
                }
                data = null;
            }
            return data;
        }

        public int VdieoInsert(Video video)
        {
            int videoId = 0;
            try
            {
                var sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "Video_Insert";
                sqlCmd.Connection = this._DBConn;
                sqlCmd.Parameters.AddWithValue("@title", video.title);
                sqlCmd.Parameters.AddWithValue("@description", (object)video.description ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@path", (object)video.path ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@projectId", video.projectId);
                sqlCmd.Parameters.AddWithValue("@videoTypeId", video.videoTypeId);
                sqlCmd.Parameters.AddWithValue("@create_timestamp", (object)video.create_timestamp ?? DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@update_timestamp", (object)video.update_timestamp ?? DateTime.Now);
                sqlCmd.Parameters.Add("@videoId", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (this._DBConn.State == ConnectionState.Closed)
                {
                    this._DBConn.Open();
                }
                sqlCmd.ExecuteNonQuery();
                videoId = Convert.ToInt32(sqlCmd.Parameters["@videoId"].Value);
                this._DBConn.Close();
            }
            catch (Exception ex)
            {

                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true")
                {
                    throw ex;
                }
            }

            return videoId;
        }

        //public bool VideoUpdate(Video video)
        //{
        //    bool status = false;
        //    try
        //    {
        //        SqlCommand sqlCmd = new SqlCommand();
        //        sqlCmd.CommandType = CommandType.StoredProcedure;
        //        sqlCmd.CommandText = "Projects_Update";
        //        sqlCmd.Connection = this._DBConn;
        //        sqlCmd.Parameters.AddWithValue("@projectId", project.projectId);

        //        if (this._DBConn.State == ConnectionState.Closed)
        //        {
        //            this._DBConn.Open();
        //        }
        //        int numberOfRecordsAffected = sqlCmd.ExecuteNonQuery();
        //        if (numberOfRecordsAffected > 0)
        //        {
        //            status = true;
        //        }
        //        this._DBConn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ConfigurationManager.AppSettings["RethrowErrors"] == "true") { throw ex; }
        //        status = false;
        //    }
        //    finally
        //    {
        //        //this._DBConn.Close();
        //    }
        //    return status;
        //}
    }
}
