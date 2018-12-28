using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FT.DataAccess.MetaData
{
    public interface IMetaDataDataAccess
    {
        IEnumerable<Relations> GetRelations();
    }
}
