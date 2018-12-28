using Services.FT.Host.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Services.FT.Host.Controllers
{
    public class FamiliesController : BaseController
    {
        private IFamilyTreeIdentityService _identityService;
        public FamiliesController(IFamilyTreeIdentityService identityService) :base()
        {
            _identityService = identityService;
        }

        public object Get()
        {
            var userName = _identityService.UserName;
        }
    }
}
