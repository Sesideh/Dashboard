using System;
using System.Data;

namespace AMS
{
    #region Comments
    /// <summary>
    /// AMS_Folders Class.
    /// </summary>
    /// <remarks>
    /// <h3>Changes</h3>
    /// <list type="table">
    /// 	<listheader>
    /// 		<th>Author</th>
    /// 		<th>Date</th>
    /// 		<th>Details</th>
    /// 	</listheader>
    /// 	<item>
    /// 		<term>Reza Sadeghi Jafari</term>
    /// 		<description>2/10/2014</description>
    /// 		<description>Created</description>
    /// 	</item>
    /// </list>
    /// </remarks>
    #endregion

    [Serializable]
    public class AMS_MenuContent
    {
        #region Construction
        /// <summary>
        /// Initializes a new (no-args) instance of the AMS_Folders class.
        /// </summary>
        public AMS_MenuContent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AMS_Folders class.
        /// </summary>
        public AMS_MenuContent(String Folder_Name, Int32 Folder_order, String Folder_Name_fa, String Mdl_Title, String Mdl_Title_Fa, String Mdl_URL, Boolean IsdeultProject, String ProjectId)
        {

            this.Folder_Name = Folder_Name;
            this.Folder_order = Folder_order;
            this.Folder_Name_fa = Folder_Name_fa;
            this.Mdl_Title = Mdl_Title;
            this.Mdl_Title_Fa = Mdl_Title_Fa;
            this.Mdl_URL = Mdl_URL;
            this.IsdeultProject = IsdeultProject;
            this.ProjectId = ProjectId;
        }

        public AMS_MenuContent(String ProjectId, String ProjectTitle)
        {
            this.ProjectId = ProjectId;
            this.ProjectTitle = ProjectTitle;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Folder_Name value.
        /// </summary>
        public virtual String Folder_Name { get; set; }

        /// <summary>
        /// Gets or sets the Folder_order value.
        /// </summary>
        public virtual Int32 Folder_order { get; set; }

        /// <summary>
        /// Gets or sets the Folder_Name_fa value.
        /// </summary>
        public virtual String Folder_Name_fa { get; set; }

        /// <summary>
        /// Gets or sets the Mdl_Title value.
        /// </summary>
        public virtual String Mdl_Title { get; set; }

        /// <summary>
        /// Gets or sets the Mdl_Title_Fa value.
        /// </summary>
        public virtual String Mdl_Title_Fa { get; set; }
        /// <summary>
        /// Gets or sets the IsdeultProject value.
        /// </summary>
        public virtual Boolean IsdeultProject { get; set; }

        /// <summary>
        /// Gets or sets the Mdl_URL value.
        /// </summary>
        public virtual String Mdl_URL { get; set; }

        /// <summary>
        /// Gets or sets the ProjectId value.
        /// </summary>
        public virtual String ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the ProjectId value.
        /// </summary>
        public virtual String ProjectTitle { get; set; }
        #endregion
    }
}