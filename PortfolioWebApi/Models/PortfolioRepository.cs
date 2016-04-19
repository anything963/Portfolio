﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortfolioBLDAL.Models;
using PortfolioBLDAL.BusinessLayer;

namespace PortfolioWebApi.Models
{
    public class PortfolioRepository : IPortfolioRepository
    {
        
        public Portfolio GetPortfolio(string studentId, int portfolioId)
        {
            return PortfolioBL.PortfolioSelect(portfolioId, studentId);
        }

        public Portfolio GetPortfolioWithProjects(string studentId, int portfolioId)
        {
            return PortfolioBL.PortfolioWithProjectsSelect(portfolioId, studentId);
        }

        //Projects
        public Project GetProject(int projectId)
        {
            return ProjectBL.ProjectSelect(projectId);
        }

        public IEnumerable<Project> GetProjects(int portfolioId)
        {
            return ProjectBL.PortfolioProjectsSelect(portfolioId);
        }

        public bool EditProject(Project project)
        {
            return ProjectBL.ProjectUpdate(project);
        }

        public void RemoveProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public int CreateProject(Project project)
        {
            return ProjectBL.ProjectInsert(project);
        }

        
    }
}