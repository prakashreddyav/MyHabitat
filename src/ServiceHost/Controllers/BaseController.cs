using Services.FT.Components.MetaData;
using Services.FT.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Services.FT.Host.Controllers
{
    public abstract class BaseController : ApiController
    {
        private ModelFactory _modelFactory;
        public ModelFactory TheModelFactory
        {
            get
            {
                if(_modelFactory==null)
                {
                    _modelFactory = new ModelFactory(this.Request);
                }
                return _modelFactory;
            }
        }
    }
}
