using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortfolioBLDAL.BusinessLayer;
using PortfolioBLDAL.Models;

namespace PortfolioWebApi.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public Portfolio Get()
        {

            Portfolio objPortfolio = PortfolioBL.PortfolioSelect(1, "1");
            return objPortfolio;
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
