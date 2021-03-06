﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortfolioWebApi.Models;
using PortfolioBLDAL.Models;
using PortfolioWebApi.Services;
using System.Web.Http.Routing;

namespace PortfolioWebApi.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private IPortfolioIdentityService _identityService;
        const int PAGE_SIZE = 5;
        public ProjectsController(IPortfolioRepository repository, 
                                    IPortfolioIdentityService identityService) : base(repository)
        {
            _identityService = identityService;
        }

        // GET: api/portfolio/{portfolioId}/project
        public object Get(int portfolioId, bool paging = true, int page = 0)
        {
            var username = _identityService.CurrentUser;
            var baseQuery = TheRepository.GetProjects(portfolioId).OrderBy(f => f.title);
            var totalCount = baseQuery.Count();
            var totalPages = Math.Ceiling((double)totalCount / PAGE_SIZE);
            var results = baseQuery.Skip(PAGE_SIZE * page)
                                   .Take(PAGE_SIZE)
                                   .Select(p => TheModelFactory.Create(p));
            var helper = new UrlHelper(Request);
            var prevUrl = page > 0 ? helper.Link("Project",new { page = page - 1 }): "";
            var nextUrl = page < totalPages - 1 ? helper.Link("Project", new { page = page + 1 }) : "";
            return new
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                PreviousPageUrl = prevUrl,
                NextPageUrl = nextUrl,
                Results = results
            };
        }

        // GET: api/portfolio/{portfolioId}/project/{id}/
        public HttpResponseMessage Get(int portfolioId, int projectId)
        {
            var username = _identityService.CurrentUser;
            var result = TheRepository.GetProject(projectId);

            if (result.projectId == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(result));
        }

        // POST: api/portfolio/{portfolioId}/project
        public HttpResponseMessage Post(int portfolioId, [FromBody]ProjectModel projectModel)
        {
            // Project title should not be null
            if (projectModel.title == null || projectModel.title.Trim() == "")
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Project title should not be empty.");
            }
            var username = _identityService.CurrentUser;
            try
            {
                var objProject = TheModelFactory.Parse(projectModel);
                if (objProject == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not find project data in request");
                }

                Portfolio portfolio = TheRepository.GetPortfolio(_identityService.CurrentUserId, portfolioId);
                if (portfolio.portfolioId == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Portfolio not found.");
                }

                objProject.portfolioId = portfolioId;
                objProject.studentId = _identityService.CurrentUserId;
                objProject.projectId = TheRepository.CreateProject(objProject);
                if ( objProject.projectId == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Failed to create project.");
                }

                if (!TheRepository.SaveProjectTypes(objProject))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Failed to set project types.");
                }

                return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(objProject));

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        // PUT: api/portfolio/{portfolioId}/project/projectId
        [HttpPut]
        [HttpPatch]
        public HttpResponseMessage Patch(int portfolioId, int projectId, [FromBody]ProjectModel projectModel)
        {
            try
            {
                var username = _identityService.CurrentUser;
                var userId = _identityService.CurrentUserId;

                var project = TheRepository.GetProject(projectId);
                if (project.projectId == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                var patchProject = TheModelFactory.Parse(projectModel);
                if (patchProject == null || patchProject.projectId == 0 )
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not update.");
                }

                //TODO Fix student id problem
                patchProject.studentId = _identityService.CurrentUserId;
                patchProject.portfolioId = portfolioId;
                if (TheRepository.EditProject(patchProject))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/Projects/5
        public void Delete(int id)
        {
        }
    }
}
