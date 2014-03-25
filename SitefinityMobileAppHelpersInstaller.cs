using System;
using System.Linq;
using System.Reflection;
using Telerik.Everlive.Sdk.Core;
using Telerik.Everlive.Sdk.Core.Model.System.Push;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Events;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityMobileAppHelpers
{
    /// <summary>
    /// Module installer class
    /// </summary>
    /// <remarks>
    /// This installer is registered in the /Properties/AssemblyInfo.cs file
    /// The purpose of it is to register the module in Sitefinity automatically.
    /// The User will have to enable the module from Administration -> Modules & Services
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/blogs/peter-marinovs-blog/2013/03/20/creating-self-installing-widgets-and-modules-in-sitefinity"/>
    public static class SitefinityMobileAppHelpersInstaller
    {
        #region Public methods
        /// <summary>
        /// Called before the application start.
        /// </summary>
        public static void PreApplicationStart()
        {
            Bootstrapper.Initialized += SitefinityMobileAppHelpersInstaller.OnBootstrapperInitialized;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Called when the Bootstrapper is initialized.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Telerik.Sitefinity.Data.ExecutedEventArgs" /> instance containing the event data.</param>
        private static void OnBootstrapperInitialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "RegisterRoutes")
            {
                // We have to register the module at a very early stage when sitefinity is initializing
                SitefinityMobileAppHelpersInstaller.RegisterModule();
                SitefinityMobileAppHelpersInstaller.RegisterPublishingListeners();
                SystemManager.RegisterServiceStackPlugin(new Services.MobileContentServicePlugin());
            }
        }

        /// <summary>
        /// Registers the SitefinityMobileAppHelpers module.
        /// </summary>
        private static void RegisterModule()
        {
            var configManager = ConfigManager.GetManager();
            var modulesConfig = configManager.GetSection<SystemConfig>().ApplicationModules;
            if (!modulesConfig.Elements.Any(el => el.GetKey().Equals(SitefinityMobileAppHelpersModule.ModuleName)))
            {
                modulesConfig.Add(SitefinityMobileAppHelpersModule.ModuleName, new AppModuleSettings(modulesConfig)
                {
                    Name = SitefinityMobileAppHelpersModule.ModuleName,
                    Title = SitefinityMobileAppHelpersModule.ModuleTitle,
                    Description = SitefinityMobileAppHelpersModule.ModuleDescription,
                    Type = typeof(SitefinityMobileAppHelpersModule).AssemblyQualifiedName,
                    // Change to StartupType.OnApplicationStart if you wish to have the module automatically installed.
                    StartupType = StartupType.Disabled
                });

                configManager.SaveSection(modulesConfig.Section);

                // Uncomment if you change the StartupType to OnApplicationStart
                //SystemManager.RestartApplication(false);
            }
        }

#endregion

        #region Push Notification Event Handlers

        private static void RegisterPublishingListeners()
        {
            EventHub.Subscribe<IDynamicContentCreatedEvent>(evt => ContentCreatedHandler(evt));
            
        }

        private static void ContentCreatedHandler(IDynamicContentCreatedEvent eventInfo)
        {
            var dynamicContentItem = eventInfo.Item;

            if (dynamicContentItem.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live)
            {
                SendNotification(dynamicContentItem);
            }
        }
  
        private async static void SendNotification(DynamicContent dynamicContentItem)
        {
            EverliveApp app = new EverliveApp("your id here");
            
          
            var notification = new PushNotification(dynamicContentItem.GetValue("Title").ToString());
            await app.WorkWith().Push().Notifications().Create(notification).ExecuteAsync();
        }


        #endregion
    }
}
