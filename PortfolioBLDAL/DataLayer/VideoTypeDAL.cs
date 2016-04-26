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
    
    class VideoTypeDAL : DBHelper
    {
        private SqlConnection _DBConn;

        public VideoTypeDAL()
        {
            _DBConn = base.Connection;
        }

        public SqlDataReader VideoTypeSelect(int videoTypeId)
        {
            SqlDataReader data;
            try
            {
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandText = "VideoType_Select";
                selectCommand.Connection = this._DBConn;
                selectCommand.Parameters.AddWithValue("@videoTypeId", videoTypeId);
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

        public SqlDataReader VideoTypeListSelect()
        {
            SqlDataReader data;
            try
            {
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandText = "VideoTypeList_Select";
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
