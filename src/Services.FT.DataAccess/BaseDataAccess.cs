using Services.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FT.DataAccess
{
    public class BaseDataAccess
    {
        public IDataManager DataManager { get; private set; }
        public BaseDataAccess(IDataManager dataManager)
        {
            DataManager = dataManager;
        }
    }
}
