using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Entities;
using Services.FT.DataAccess.MetaData;

namespace Services.FT.Components.MetaData
{
    public class MetaDataManager :  BaseComponent,IMetaDataManager
    {
        public IMetaDataDataAccess MetaDataDataAccess { get; private set; }
        public MetaDataManager(IMetaDataDataAccess metaDataDataAccess)
        {
            MetaDataDataAccess = metaDataDataAccess;
        }
        public IEnumerable<Relations> GetRelations()
        {
            return MetaDataDataAccess.GetRelations();
        }
    }
}
