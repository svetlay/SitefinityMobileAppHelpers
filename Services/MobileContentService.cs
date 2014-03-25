using ServiceStack.ServiceInterface;
using SitefinityMobileAppHelpers.Services.Request;
using SitefinityMobileAppHelpers.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityMobileAppHelpers.Services
{
    class MobileContentService : Service
    {
        public List<AnnouncementsResponse> Any(AnnouncementsRequest request)
        {
            DynamicModuleManager manager = DynamicModuleManager.GetManager();
            Type announcementsType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Stores.Announcements");

            var announcements = manager.GetDataItems(announcementsType).Where(item => item.Status == ContentLifecycleStatus.Live)
                .Select(item => new AnnouncementsResponse(item));
           

               return announcements.ToList();
        
                
        }
    }
}
