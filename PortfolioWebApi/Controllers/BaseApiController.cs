using PortfolioWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PortfolioWebApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private IPortfolioRepository _repository;
        private ModelFactory _modelFactory;

        public BaseApiController()
        {
            _repository = new PortfolioRepository();
            _modelFactory = new ModelFactory(this.Request);
        }

        public BaseApiController(IPortfolioRepository repository)
        {
            _repository = repository;
        }

        protected IPortfolioRepository TheRepository
        {
            get
            {
                return _repository;
            }
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request);
                }
                return _modelFactory;
            }
        }
    }
}