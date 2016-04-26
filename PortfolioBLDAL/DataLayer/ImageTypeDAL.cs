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
    class ImageTypeDAL : DBHelper
    {
        private SqlConnection _DBConn;

        public ImageTypeDAL()
        {
            _DBConn = base.Connection;
        }

        public SqlDataReader ImageTypeSelect(int imageTypeId)
        {
            SqlDataReader data;
            try
            {
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandText = "ImageType_Select";
                selectCommand.Connection = this._DBConn;
                selectCommand.Parameters.AddWithValue("@imageTypeId", imageTypeId);
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

        public SqlDataReader ImageTypeListSelect()
        {
            SqlDataReader data;
            try
            {
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandText = "ImageTypeList_Select";
                selectCommand.Connection = this._DBConn;
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
    }
}
