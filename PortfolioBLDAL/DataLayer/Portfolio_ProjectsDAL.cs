using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBLDAL.DataLayer
{
    class Portfolio_ProjectsDAL : DBHelper
    {
        #region Fields
        private SqlConnection _DBConn;
        #endregion

        #region Constructors
        public Portfolio_ProjectsDAL()
        {
            _DBConn = base.Connection;
        }
        #endregion

        #region Methods
        public SqlDataReader PortfolioProjectsSelect(int portfolioId)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "Portfolio_Projects";
            sqlCmd.Connection = this._DBConn;
            sqlCmd.Parameters.AddWithValue("@portfolioId", portfolioId);
            if (this._DBConn.State == ConnectionState.Closed)
            {
                this._DBConn.Open();
            }
            SqlDataReader rd = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            return rd;
        }
        #endregion
    }
}
