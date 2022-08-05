using System;
using System.Collections.Generic;
using System.Linq;
using Business.Mapper.ISPIS.Base;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;

/// <summary>
/// Summary description for SPIS_Prespective_DAL
/// </summary>
public class SPIS_Prespective_DAL : Common_DAL<SPIS_Prespective_obj>, ISPIS_Prespective_DAL
{
    #region Constructor

    public SPIS_Prespective_DAL(IPrespective_Mapper mapper) : base(mapper)
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion

    #region Override Members

    public override SPIS_Prespective_obj CreatNewObject()
    {
        return new SPIS_Prespective_obj();
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[Prespective] ";
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[Prespective] where Id ='" + Id + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[Prespective] where Id ='" + inId + "'";
    }

    public override string InsertCommand(SPIS_Prespective_obj inNewObject)
    {
        return "INSERT INTO [dbo].[Prespective] ([Id] ," +
                                                "[Title] ," +
                                                "[Weight] ," +
                                                "[Description] ," +
                                                "[CreateId] ," +
                                                "[CreateDate] ," +
                                                "[UpdateId] ," +
                                                "[UpdateDate] ) " +
                                    "VALUES ('" + Guid.NewGuid() + "' , '" +
                                                inNewObject.Title + "', " +
                                                inNewObject.Weight + ", '" +
                                                inNewObject.Description + "' , '" +
                                                inNewObject.CreateId + "' , " +
                                                "GETDATE() ,'" +
                                                inNewObject.UpdateId + "'," +
                                                "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_Prespective_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[Prespective] SET [Title] = '" + inEditedObject.Title + "'" +
                                               ",[Description] = '" + inEditedObject.Description + "' " +
                                               ",[Weight] = " + inEditedObject.Weight + " " +
                                               ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                               ",[UpdateDate] = GETDATE()" +
                                               " where [Id] = '" + inId + "'";
    }

    public override IList<SPIS_Prespective_obj> GetObjectList(string inProject, string inTop)
    {
        var result = base.GetObjectList(inProject, inTop);
        decimal sumUp = 0;
        decimal sum = result.Sum(x => x.Weight);

        foreach (var item in result)
        {
            item.Prespective_Calculation = factory.StrategicTree_Service.RollUpByPrespective(item.Id, (inProject != null ? new Guid(inProject) : Guid.Empty));
            sumUp = (item.Prespective_Calculation * item.Weight) + sumUp;
        }
        foreach (var item in result)
        {
            item.Prespective_Total = sumUp / sum;
        }

        return result;
    }

    #endregion

    #region Public Methods

    public IList<SPIS_Prespective_obj> GetObjectList(string inProject, string inTop, Guid PreHistoryId)
    {
        var result = GetObjectList(inProject, inTop);

        decimal sumUp = 0;
        decimal sum = result.Sum(x => x.Weight);

        if (PreHistoryId != Guid.Empty)
        {
            foreach (var item in result)
            {
                item.Pre_Prespective_Calculation = factory.StrategicTree_Service.RollUpByPrespective(item.Id, PreHistoryId);
                sumUp = (item.Pre_Prespective_Calculation * item.Weight) + sumUp;
            }
            foreach (var item in result)
            {
                item.Pre_Prespective_Total = sumUp / sum;
            }
        }

        return result;
    }

    #endregion
}