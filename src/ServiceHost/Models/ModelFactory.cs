using Services.Entities;
using Services.FT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace Services.FT.Host.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;

        public ModelFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }
        public RelationsModel Create(Relations relations)
        {
            return new RelationsModel()
                        {
                            Url=_urlHelper.Link("GetRelations",new {id=relations.RelationId }),
                            RelationName = relations.RelationName,
                            RelationGender = relations.RelationGenderEnum.ToString()
                        };
        }
        public UserModel Create(UserProfile userProfile)
        {
            return new UserModel()
            {
                Url = _urlHelper.Link("GetUserProfile", new {}),
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Email=userProfile.Email
            };
        }
    }
}