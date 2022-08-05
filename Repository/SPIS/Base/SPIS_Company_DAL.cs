using System;
using Business.Mapper.ICommon;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;


public class SPIS_Company_DAL : Common_DAL<SPIS_Company_obj> , ISPIS_Company_DAL
{
    #region Constructor

    public SPIS_Company_DAL(ICompany_Mapper mapper) : base(mapper)
    {
    }

    #endregion

    #region Override Members

    public override SPIS_Company_obj CreatNewObject()
    {
        return new SPIS_Company_obj();
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[Company] where Id ='" + Id + "' order by CreateDate Desc";
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[Company]";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM [dbo].[Company] where Id ='" + inId + "'";
    }

    public override string InsertCommand(SPIS_Company_obj inNewObject)
    {
        return "INSERT INTO [dbo].[Company] ([Id] ," +
                                            "[Name] ," +
                                            "[Type] ," +
                                            "[Description] ," +
                                            "[CreateId] ," +
                                            "[CreateDate] ," +
                                            "[UpdateId] ," +
                                            "[UpdateDate] ) " +
                                "VALUES ('" + inNewObject.Id + "' , '" +
                                            inNewObject.Name + "' , '" +
                                            inNewObject.Type + "' , '" +
                                            inNewObject.Description + "' , '" +
                                            inNewObject.CreateId + "' , " +
                                            "GETDATE() ,'" +
                                            inNewObject.UpdateId + "'," +
                                            "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_Company_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[Company] SET [Name] = '" + inEditedObject.Name + "' " +
                                            ",[Type] = '" + inEditedObject.Type + "' " +
                                            ",[Description] = '" + inEditedObject.Description + "' " +
                                            ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                            ",[UpdateDate] = GETDATE()" +
                                      " where [Id] = '" + inId + "'";
    }

    #endregion
}

