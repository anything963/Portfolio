using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PortfolioBLDAL.DataLayer
{
    class ProjectDAL : DBHelper
    {
        private SqlConnection _DBConn;

        public ProjectDAL()
        {
            _DBConn = base.Connection;
        }

        #region Methods

        public SqlDataReader ProjectSelect(int projectId)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "Project_Select";
            selectCommand.Connection = this._DBConn;
            selectCommand.Parameters.AddWithValue("@projectId", projectId);
            if (this._DBConn.State == ConnectionState.Closed)
            {
                this._DBConn.Open();
            }
            SqlDataReader data = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return data;
        }

        #endregion
    }
}

