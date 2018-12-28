using Services.FT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FT.Components.UserManagement
{
    public interface IUserManagementManager
    {
        UserProfile GetUserProfile();
    }
}
