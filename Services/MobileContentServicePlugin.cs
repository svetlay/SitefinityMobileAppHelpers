using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitefinityMobileAppHelpers.Services
{
    class MobileContentServicePlugin : IPlugin
    {

        public void Register(IAppHost appHost)
        {
            appHost.RegisterService(typeof(MobileContentService));
        }
    }
}
