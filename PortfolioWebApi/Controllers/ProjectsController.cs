using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortfolioWebApi.Models;
using PortfolioBLDAL.Models;


namespace PortfolioWebApi.Controllers
{
    public class ProjectsController : BaseApiController
    {
        public ProjectsController(IPortfolioRepository repository) : base(repository)
        {

        }

        // GET: api/portfolio/{portfolioId}/project
        public IEnumerable<ProjectModel> Get(int portfolioId)
        {
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
        public Project Get(int portfolioId, int projectId)
        {
            return TheRepository.GetProject(projectId);
        }

        // POST: api/Projects
        public void Post([FromBody]string value)
        {
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
