using System;
using System.Linq;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace SitefinityMobileAppHelpers
{
    /// <summary>
    /// Localizable strings for the SitefinityMobileAppHelpers module
    /// </summary>
    /// <remarks>
    /// You can use Sitefinity Thunder to edit this file.
    /// To do this, open the file's context menu and select Edit with Thunder.
    /// 
    /// If you wish to install this as a part of a custom module,
    /// add this to the module's Initialize method:
    /// App.WorkWith()
    ///     .Module(ModuleName)
    ///     .Initialize()
    ///         .Localization<SitefinityMobileAppHelpersResources>();
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/developers-guide/how-to/how-to-import-events-from-facebook/creating-the-resources-class"/>
    [ObjectInfo("SitefinityMobileAppHelpersResources", ResourceClassId = "SitefinityMobileAppHelpersResources", Title = "SitefinityMobileAppHelpersResourcesTitle", TitlePlural = "SitefinityMobileAppHelpersResourcesTitlePlural", Description = "SitefinityMobileAppHelpersResourcesDescription")]
    public class SitefinityMobileAppHelpersResources : Resource
    {
        #region Construction
        /// <summary>
        /// Initializes new instance of <see cref="SitefinityMobileAppHelpersResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public SitefinityMobileAppHelpersResources()
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="SitefinityMobileAppHelpersResources"/> class with the provided <see cref="ResourceDataProvider"/>.
        /// </summary>
        /// <param name="dataProvider"><see cref="ResourceDataProvider"/></param>
        public SitefinityMobileAppHelpersResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Class Description
        /// <summary>
        /// SitefinityMobileAppHelpers Resources
        /// </summary>
        [ResourceEntry("SitefinityMobileAppHelpersResourcesTitle",
            Value = "SitefinityMobileAppHelpers module labels",
            Description = "The title of this class.",
            LastModified = "2014/03/24")]
        public string SitefinityMobileAppHelpersResourcesTitle
        {
            get
            {
                return this["SitefinityMobileAppHelpersResourcesTitle"];
            }
        }

        /// <summary>
        /// SitefinityMobileAppHelpers Resources Title plural
        /// </summary>
        [ResourceEntry("SitefinityMobileAppHelpersResourcesTitlePlural",
            Value = "SitefinityMobileAppHelpers module labels",
            Description = "The title plural of this class.",
            LastModified = "2014/03/24")]
        public string SitefinityMobileAppHelpersResourcesTitlePlural
        {
            get
            {
                return this["SitefinityMobileAppHelpersResourcesTitlePlural"];
            }
        }

        /// <summary>
        /// Contains localizable resources for SitefinityMobileAppHelpers module.
        /// </summary>
        [ResourceEntry("SitefinityMobileAppHelpersResourcesDescription",
            Value = "Contains localizable resources for SitefinityMobileAppHelpers module.",
            Description = "The description of this class.",
            LastModified = "2014/03/24")]
        public string SitefinityMobileAppHelpersResourcesDescription
        {
            get
            {
                return this["SitefinityMobileAppHelpersResourcesDescription"];
            }
        }
        #endregion
    }
}