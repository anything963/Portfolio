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
    public class PortfolioController : ApiController
    {
        private PortfolioRepository _repository;
        public PortfolioController()
        {
            _repository = new PortfolioRepository();
        }
        // GET: api/Portfolio/5
        public Portfolio Get(int id)
        {
            return _repository.GetPortfolioWithProjects("1", id);
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
