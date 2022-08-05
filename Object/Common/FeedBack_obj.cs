using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FeedBack_obj
/// </summary>
public class FeedBack_obj
{
    public FeedBack_obj()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public FeedBack_obj(string LoginName,string PageUrl,string IPAdress,string BrowserName,string Comment, string Subject, string FeedBackType, DateTime CreateDate)
    {
        this.LoginName = LoginName;
        this.PageUrl = PageUrl;
        this.IPAdress = IPAdress;
        this.BrowserName = BrowserName;
        this.Subject = Subject;
        this.FeedBackType = FeedBackType;
        this.Comment = Comment;
        this.CreateDate = CreateDate;
    }

    public string LoginName { get; set; }
    public string PageUrl { get; set; }
    public string IPAdress { get; set; }
    public string BrowserName { get; set; }
    public string Subject { get; set; }
    public string FeedBackType { get; set; }
    public string Comment { get; set; }
    public DateTime CreateDate { get; set; }
}