using System;
using Business.Mapper.ISPIS.StrategicTree;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;

/// <summary>
/// Summary description for SPIS_StrategicTreeProgress_DAL
/// </summary>
public class SPIS_StrategicTreeProgress_DAL : Common_DAL<SPIS_StrategicTreeProgress_obj> , ISPIS_StrategicTreeProgress_DAL
{
    #region Constructor

    public SPIS_StrategicTreeProgress_DAL(IStrategicTreeProgress_Mapper mapper) : base(mapper)
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion

    #region Override Members

    public override SPIS_StrategicTreeProgress_obj CreatNewObject()
    {
        return new SPIS_StrategicTreeProgress_obj();
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[StrategicTreeProgress] where Id ='" + Id + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[StrategicTreeProgress] where Id ='" + inId + "'";
    }

    public override string InsertCommand(SPIS_StrategicTreeProgress_obj inNewObject)
    {
        return "INSERT INTO [dbo].[StrategicTreeProgress] ([Id] ," +
                                                        "[StrategicTree_Id] ," +
                                                        "[ActualValue] ," +
                                                        "[TargectValue] ," +
                                                        "[Description] ," +
                                                        "[CreateId] ," +
                                                        "[CreateDate] ," +
                                                        "[UpdateId] ," +
                                                        "[UpdateDate] ) " +
                                            "VALUES ('" + Guid.NewGuid() + "' , '" +
                                                        inNewObject.StrategicTree_Id + "', " +
                                                        inNewObject.ActualValue + " , " +
                                                        inNewObject.TargectValue + " , '" +
                                                        inNewObject.Description + "' , '" +
                                                        inNewObject.CreateId + "' , " +
                                                        "GETDATE() ,'" +
                                                        inNewObject.UpdateId + "'," +
                                                        "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_StrategicTreeProgress_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[StrategicTreeProgress] SET [StrategicTree_Id] = '" + inEditedObject.StrategicTree_Id + "'" +
                                                        ",[TargectValue] = " + inEditedObject.TargectValue + " " +
                                                        ",[ActualValue] = " + inEditedObject.ActualValue + " " +
                                                        ",[Description] = '" + inEditedObject.Description + "' " +
                                                        ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                                        ",[UpdateDate] = GETDATE()" +
                                                  " where [Id] = '" + inId + "'";
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        throw new NotImplementedException();
    }

    #endregion
}