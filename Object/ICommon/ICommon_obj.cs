using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ICommon_obj
/// </summary>
public interface ICommon_obj
{
    string Description { get; set; }
    DateTime CreateDate { get; set; }
    string CreateId { get; set; }
    DateTime UpdateDate { get; set; }
    string UpdateId { get; set; }
}