using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioWebApi.Services
{
    public class PortfolioIdentityService : IPortfolioIdentityService
    {
        public string CurrentUser
        {
            get
            {
                return "john";
            }
        }

        public string CurrentUserId
        {
            get
            {
                return "1";
            }
        }
    }
}