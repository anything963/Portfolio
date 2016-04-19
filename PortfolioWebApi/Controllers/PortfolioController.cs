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
    public class PortfolioController : BaseApiController
    {
        public PortfolioController(IPortfolioRepository repository): base(repository)
        {
            
        }
        // GET: api/Portfolio/5
        public Portfolio Get(string studentId, int portfolioId)
        {
            return TheRepository.GetPortfolioWithProjects(studentId, portfolioId);
        }

        // POST: api/Portfolio
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Portfolio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Portfolio/5
        public void Delete(int id)
        {
        }
    }
}
