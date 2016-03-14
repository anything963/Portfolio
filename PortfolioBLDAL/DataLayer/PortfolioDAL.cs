using System;
using System.Data.SqlClient;
using System.Data;
using PortfolioBLDAL.Models;
using System.Configuration;

namespace PortfolioBLDAL.DataLayer
{
    class PortfolioDAL : DBHelper
    {
        private SqlConnection _DBConn;

        public PortfolioDAL()
        {
            _DBConn = base.Connection;
        }

        #region Methods

        public SqlDataReader PortfolioSelect(int portfolioId, string studentId)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = "Portfolio_Select";
            selectCommand.Connection = this._DBConn;
            selectCommand.Parameters.AddWithValue("@portfolioId", portfolioId);
            selectCommand.Parameters.AddWithValue("@StudentID", studentId);
            if (this._DBConn.State == ConnectionState.Closed)
            {
                this._DBConn.Open();
            }
            SqlDataReader data = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return data;
        }

        public int PortfolioInsert(Portfolio portfolio)
        {
            int portfolioId = 0;

            try
            {
                var sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "Portfolio_Insert";
                sqlCmd.Connection = this._DBConn;
                sqlCmd.Parameters.AddWithValue("@studentId", portfolio.studentId);
                sqlCmd.Parameters.AddWithValue("@publicStatus", (( portfolio.public_status != null )? (object)portfolio.public_status : DBNull.Value));
                sqlCmd.Parameters.Add("@portfolioId", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (this._DBConn.State == ConnectionState.Closed)
                {
                    this._DBConn.Open();
                }

                sqlCmd.ExecuteNonQuery();
                portfolioId = Convert.ToInt32(sqlCmd.Parameters["@portfolioId"].Value);
                this._DBConn.Close();
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true")
                {
                    throw ex;
                }
                
            }

            return portfolioId;
        }

        #endregion
    }
}
