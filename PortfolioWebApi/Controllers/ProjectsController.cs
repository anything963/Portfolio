using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortfolioWebApi.Models;
using PortfolioBLDAL.Models;
using PortfolioWebApi.Services;

namespace PortfolioWebApi.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private IPortfolioIdentityService _identityService;

        public ProjectsController(IPortfolioRepository repository, 
                                    IPortfolioIdentityService identityService) : base(repository)
        {
            _identityService = identityService;
        }

        // GET: api/portfolio/{portfolioId}/project
        public IEnumerable<ProjectModel> Get(int portfolioId)
        {
            var username = _identityService.CurrentUser;
            var results = TheRepository.GetProjects(portfolioId)
                                       .OrderBy(f => f.title)
                                       .Take(5)
                                       .Select(p => TheModelFactory.Create(p));
                                       //{
                                       //    projectId = p.projectId,
                                       //    title = p.title
                                       //});

            return results;
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
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/Projects/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Projects/5
        public void Delete(int id)
        {
        }
    }
}
