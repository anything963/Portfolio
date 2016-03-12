using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioBLDAL.DataLayer;
using PortfolioBLDAL.Models;
using System.Data.SqlClient;
using System.Configuration;


namespace PortfolioBLDAL.BusinessLayer
{
    class PortfolioBL
    {

        public static Portfolio PortfolioSelect(int portfolioId, string studentId)
        {

            Portfolio objPortfolio = new Portfolio();

            PortfolioDAL portfolioDal = new PortfolioDAL();
            SqlDataReader data = portfolioDal.PortfolioSelect(portfolioId, studentId);
            while (data.Read())
            {
                objPortfolio = MapDataReaderPortfolio(data);
            }
            return objPortfolio;
        }

        private static Portfolio MapDataReaderPortfolio(SqlDataReader myReader)
        {
            Portfolio objPortfolio = new Portfolio();
            if (!myReader.IsDBNull(myReader.GetOrdinal("portfolioId"))) objPortfolio.portfolioId = myReader.GetInt32(myReader.GetOrdinal("portfolioId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("studentId"))) objPortfolio.studentId = myReader.GetString(myReader.GetOrdinal("studentId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("public_status"))) objPortfolio.public_status = myReader.GetString(myReader.GetOrdinal("public_status"));

            return objPortfolio;
        }
    }
}
