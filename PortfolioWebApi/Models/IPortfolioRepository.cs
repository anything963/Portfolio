using PortfolioBLDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioWebApi.Models
{
    public interface IPortfolioRepository
    {
        //Portfolio
        Portfolio GetPortfolio(string studentId, int portfolioId);
        Portfolio GetPortfolioWithProjects(string studentId, int portfolioId);

        //Projects
        Project GetProject(int projectId);
        int CreateProject(Project project);
        bool EditProject(Project project);
        void RemoveProject(int projectId);

    }
}