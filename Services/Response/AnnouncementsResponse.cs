using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Security;

namespace SitefinityMobileAppHelpers.Services.Response
{
    class AnnouncementsResponse
    {
        public String Title { get; set; }

        public string AuthorThumbnailUrl { get; set; }

        public Guid Id { get; set; }

        public AnnouncementsResponse(DynamicContent item)
        {
           
            this.Title = item.GetString("Title");
            this.Id = item.Id;
           
        }
    }

    
}
