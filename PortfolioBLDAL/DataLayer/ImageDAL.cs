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
    class ImageDAL:DBHelper
    {
        private SqlConnection _DBConn;

        public ImageDAL()
        {
            _DBConn = base.Connection;
        }

        public SqlDataReader ImageListSelect(int projectId)
        {
            SqlDataReader data;
            try
            {
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandText = "ImageList_Select";
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

        public int ImageInsert(Image image)
        {
            int imageId = 0;
            try
            {
                var sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "Image_Insert";
                sqlCmd.Connection = this._DBConn;
                sqlCmd.Parameters.AddWithValue("@title", image.title);
                sqlCmd.Parameters.AddWithValue("@description", (object)image.description ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@path", (object)image.path ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@projectId", image.projectId);
                sqlCmd.Parameters.AddWithValue("@imageTypeId", image.imageTypeId);
                sqlCmd.Parameters.AddWithValue("@create_timestamp", (object)image.create_timestamp ?? DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@update_timestamp", (object)image.update_timestamp ?? DateTime.Now);
                sqlCmd.Parameters.Add("@imageId", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (this._DBConn.State == ConnectionState.Closed)
                {
                    this._DBConn.Open();
                }
                sqlCmd.ExecuteNonQuery();
                imageId = Convert.ToInt32(sqlCmd.Parameters["@imageId"].Value);
                this._DBConn.Close();
            }
            catch (Exception ex)
            {

                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true")
                {
                    throw ex;
                }
            }

            return imageId;
        }

        //public bool ImageUpdate(Image image)
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
