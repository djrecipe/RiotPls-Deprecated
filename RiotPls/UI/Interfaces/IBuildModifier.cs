using System.Collections.Generic;
using System.Windows.Forms;
using RiotPls.API.Builder;

namespace RiotPls.UI.Interfaces
{
    /// <summary>
    /// View models which interact with a build or build collection
    /// </summary>       
    /// <seealso cref="ITemplateViewModel"/>
    public interface IBuildModifier : ITemplateViewModel
    {
        #region Instance Properties
        /// <summary>
        /// Collection of builds to reference or modify
        /// </summary>
        BuildCollection Builds { get; set; }
        /// <summary>
        /// Currently selected champion/item/etc.
        /// </summary>
        string SelectedItem { get; set; }
        #endregion
        #region Instance Methods
        /// <summary>
        /// Retrieve a list of menu items representing the current build state(s)
        /// </summary>
        /// <returns>List of menu items pertaining to build contents</returns>
        List<ToolStripMenuItem> GetBuildMenuItems();
        #endregion
    }
}
