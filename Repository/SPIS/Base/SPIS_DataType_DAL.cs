using System;
using Business.Mapper.ISPIS.Base;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;


public class SPIS_DataType_DAL : Common_DAL<SPIS_DataType_obj>, ISPIS_DataType_DAL
{
    #region Constructor

    public SPIS_DataType_DAL(IDataType_Mapper mapper) : base(mapper)
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion

    #region Override Members

    public override SPIS_DataType_obj CreatNewObject()
    {
        return new SPIS_DataType_obj();
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[DataType]";
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[DataType] where Id ='" + Id + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[DataType] where Id ='" + inId + "'";
    }

    public override string InsertCommand(SPIS_DataType_obj inNewObject)
    {
        return "INSERT INTO [dbo].[DataType] ([Id] ," +
                                            "[Title] ," +
                                            "[Description] ," +
                                            "[CreateId] ," +
                                            "[CreateDate] ," +
                                            "[UpdateId] ," +
                                            "[UpdateDate] ) " +
                                "VALUES ('" + Guid.NewGuid() + "' , '" +
                                            inNewObject.Title + "' , '" +
                                            inNewObject.Description + "' , '" +
                                            inNewObject.CreateId + "' , " +
                                            "GETDATE() ,'" +
                                            inNewObject.UpdateId + "'," +
                                            "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_DataType_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[DataType] SET [Title] = '" + inEditedObject.Title + "' " +
                                            ",[Description] = '" + inEditedObject.Description + "' " +
                                            ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                            ",[UpdateDate] = GETDATE()" +
                                      " where [Id] = '" + inId + "'";
    }

    #endregion
}
