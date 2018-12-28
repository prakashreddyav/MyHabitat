using Services.Entities;
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
    public class MetaDataController : BaseController
    {
        private IMetaDataManager _metaDataManager;
        public MetaDataController(IMetaDataManager metaDataManager)
        {
            _metaDataManager = metaDataManager;
        }
        public IEnumerable<RelationsModel> GetRelations()
        {
            return _metaDataManager.GetRelations()
                .Select(m=>TheModelFactory.Create(m));
        }
        public RelationsModel GetRelations(int id)
        {
            return TheModelFactory.Create(_metaDataManager.GetRelations()
                .Where(m=>m.RelationId==id).FirstOrDefault());
        }
    }
}
