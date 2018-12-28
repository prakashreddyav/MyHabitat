using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FT.Components.MetaData
{
    public interface IMetaDataManager
    {
        IEnumerable<Relations> GetRelations();
    }
}
