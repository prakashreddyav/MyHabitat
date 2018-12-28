using Services.FT.Components.UserManagement;
using Services.FT.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Services.FT.Host.Controllers
{
    public class UserManagementController : BaseController
    {
        private IUserManagementManager _userManagementManager;
        public UserManagementController(IUserManagementManager userManagementManager)
        {
            _userManagementManager = userManagementManager;
        }
        public UserModel GetProfile()
        {
            return TheModelFactory.Create(_userManagementManager.GetUserProfile());
        }
    }
}
