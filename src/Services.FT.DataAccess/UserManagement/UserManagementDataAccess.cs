using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Core.DataAccess;
using Services.FT.Entities;
using System.Data;

namespace Services.FT.DataAccess.UserManagement
{
    public class UserManagementDataAccess : BaseDataAccess, IUserManagementDataAccess
    {
        public UserManagementDataAccess(IDataManager dataManager) : base(dataManager)
        {
        }

        public UserProfile GetUser(string userName)
        {
            var command = DataManager.GetCommand(UserManagementDataAccessConstants.SP_GetUserDetails);
            DataManager.AddParameter(command, "@userName", userName, DbType.String);
            DataManager.AddPoErrorCodeParameter(command);
            var resultSet = DataManager.ExecuteDataSet(command);
            var errorCode = DataManager.GetOuputParameter<string>(command, DataAccessConstants.PoVarErrorCode);

            if (errorCode == UserManagementDataAccessConstants.DBErrorCode_None)
            {
                return resultSet.Tables[0].ToList<UserProfile>().FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
