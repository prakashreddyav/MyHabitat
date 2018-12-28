using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Entities;
using Services.Core.DataAccess;
using System.Data;
using System.Reflection;

namespace Services.FT.DataAccess.MetaData
{
    public class MetaDataDataAccess : BaseDataAccess, IMetaDataDataAccess
    {
        public MetaDataDataAccess(IDataManager dataManager):base(dataManager)
        {
        }
        public IEnumerable<Relations> GetRelations()
        {
            var command = DataManager.GetCommand(MetaDataDataAccessConstants.SP_GetRelations);

            DataManager.AddPoErrorCodeParameter(command);
            var resultSet = DataManager.ExecuteDataSet(command);
            var errorCode = DataManager.GetOuputParameter<string>(command, DataAccessConstants.PoVarErrorCode);
            
            if (errorCode == MetaDataDataAccessConstants.DBErrorCode_None)
            {
                return resultSet.Tables[0].ToList<Relations>();
            }
            else
            { 
                return null;
            }
        }
    }
}
