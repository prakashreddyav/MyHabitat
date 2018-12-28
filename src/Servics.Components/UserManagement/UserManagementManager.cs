using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.FT.Entities;

namespace Services.FT.Components.UserManagement
{
    public class UserManagementManager : BaseComponent, IUserManagementManager
    {
        public UserProfile GetUserProfile()
        {
            return new UserProfile() {FirstName="Venkata Prakash",LastName="Ankireddy",Email="prakash@test.com" };
        }
    }
}
