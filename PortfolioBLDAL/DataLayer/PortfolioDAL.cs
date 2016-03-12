using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            #endregion
        }
    }
