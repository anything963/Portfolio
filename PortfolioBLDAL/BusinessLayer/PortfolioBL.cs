﻿using System;
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
    public class PortfolioBL
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

        public static Portfolio PortfolioWithProjectsSelect(int portfolioId, string studentId)
        {
            Portfolio objPortfolio = PortfolioBL.PortfolioSelect(portfolioId, studentId);
            objPortfolio.projectList = ProjectBL.PortfolioProjectsSelect(portfolioId);
            foreach (Project item in objPortfolio.projectList)
            {
                //Add additional information for project here
                item.projectType = ProjectTypeBL.ProjectTypeSelect(item.projectId);
            }

            return objPortfolio;
        }

        /// <summary>
        /// Inserts new portfolio.
        /// </summary>
        /// <param name="portfolio"></param>
        /// <returns>portfolio Id</returns>
        public static int PortfolioInsert(Portfolio portfolio)
        {
            PortfolioDAL objInsert = new PortfolioDAL();
            return objInsert.PortfolioInsert(portfolio);
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
