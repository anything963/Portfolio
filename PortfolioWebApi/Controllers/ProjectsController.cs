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
    public class ProjectsController : ApiController
    {
        private PortfolioRepository _repository;

        public ProjectsController()
        {
            _repository = new PortfolioRepository();
        }
        
        // GET: api/Projects/5
        public Project Get(int id)
        {
            return _repository.GetProject(id);
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
