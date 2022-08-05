using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Share_HelpFile
/// </summary>
public class Share_HelpFile_obj
{
    public Share_HelpFile_obj()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Initializes a new instance of the History_Cost class.
    /// </summary>
    public Share_HelpFile_obj(string ModuleTitle ,string HelpFile)
    {
        this.ModuleTitle = ModuleTitle;
        this.HelpFile = HelpFile;

    }
    /// <summary>
    /// Gets or sets the ProjectNO value.
    /// </summary>
    public virtual string ModuleTitle { get; set; }

    /// <summary>
    /// Gets or sets the EventID value.
    /// </summary>
    public virtual string HelpFile { get; set; }
}