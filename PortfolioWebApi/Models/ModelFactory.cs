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
                    projectId = project.projectId }),
                projectId = project.projectId,
                title = project.title,
                description = project.description,
                startDate = project.startDate,
                endDate = project.endDate,
                dateAdded = project.dateAdded,
                dateUpdated = project.dateUpdated,
                otherDetails = project.otherDetails,
                projectType = project.projectType.Select(t => Create(t)),
                images = project.images.Select(i => Create(i))
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

        public ImageModel Create(Image image)
        {
            return new ImageModel()
            {
                imageId = image.imageId,
                title = image.title,
                description = image.description,
                path = image.path,
                imageType = Create(image.imageType)
            };
        }

        public ImageTypeModel Create(ImageType imageType)
        {
            return new ImageTypeModel()
            {
                imageTypeId = imageType.imageTypeId,
                title = imageType.title,
                description = imageType.description
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

                //Parse Project Types
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

                //Parse Images
                if (projectModel.images != null)
                {
                    List<Image> images = new List<Image>();
                    List<ImageModel> imageModels = projectModel.images.ToList();
                    foreach (var image in imageModels)
                    {
                        Image img = new Image();
                        img.imageId = image.imageId;
                        img.title = image.title;
                        img.path = image.path;
                        img.description = image.description;
                        img.imageType = new ImageType {
                                            imageTypeId = image.imageType.imageTypeId,
                                            description = image.imageType.description,
                                            title = image.imageType.title
                                        };
                        images.Add(img);
                    }
                    objProject.images = images;
                }
                else
                {
                    objProject.images = new List<Image>();
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