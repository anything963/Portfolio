using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortfolioBLDAL.Models;
using System.Web.Http.Routing;
using System.Net.Http;

namespace PortfolioWebApi.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;

        public ModelFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }
        public ProjectModel Create (Project project)
        {
            return new ProjectModel()
            {
                Url = _urlHelper.Link("Project", new { portfolioId = project.portfolioId,
                                                        projectId = project.projectId}),
                projectId = project.projectId,
                title = project.title,
                description = project.description,
                startDate = project.startDate,
                endDate = project.endDate,
                dateAdded = project.dateAdded,
                dateUpdated = project.dateUpdated,
                otherDetails = project.otherDetails,
                projectType = project.projectType.Select(t => Create(t))
            };
        }

        public ProjectTypeModel Create(ProjectType projectType)
        {
            return new ProjectTypeModel()
            {
                typeId = projectType.typeId,
                title = projectType.title,
                description = projectType.description
            };
        }

        public Project Parse(ProjectModel projectModel)
        {
            try
            {
                Project objProject = new Project();
                objProject.projectId = projectModel.projectId;
                objProject.title = projectModel.title;
                objProject.description = projectModel.description;
                objProject.startDate = projectModel.startDate;
                objProject.endDate = projectModel.endDate;
                objProject.dateAdded = projectModel.dateAdded;
                objProject.dateUpdated = projectModel.dateUpdated;
                objProject.otherDetails = projectModel.otherDetails;

                if (projectModel.projectType != null)
                {
                    List<ProjectType> projectTypes = new List<ProjectType>();
                    List<ProjectTypeModel> types = projectModel.projectType.ToList();
                    foreach (var type in types)
                    {
                        ProjectType projectType = new ProjectType();
                        projectType.typeId = type.typeId;
                        projectTypes.Add(projectType);
                    }
                    objProject.projectType = projectTypes;
                }
                else
                {
                    objProject.projectType = new List<ProjectType>();
                }
                
               

                return objProject;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}