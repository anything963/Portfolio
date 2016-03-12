using System;
using System.Configuration;
using System.Data.SqlClient;

namespace PortfolioBLDAL.DataLayer
{
    public class DBHelper
    {
        public SqlConnection Connection = null;

        public DBHelper()
        {
            try
            {
                this.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortfolioConnection"].ConnectionString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
