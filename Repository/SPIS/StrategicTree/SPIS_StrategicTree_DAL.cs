using DAL.Common;
using SPIS;
using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Drawing;
using Business.Repository.ISPIS;
using Business;
using Helper.Factory;
using Business.Mapper.ISPIS.StrategicTree;

/// <summary>
/// Summary description for SPIS_StrategicTree_DAL
/// </summary>
public class SPIS_StrategicTree_DAL : Common_DAL<SPIS_StrategicTree_obj> , ISPIS_StrategicTree_DAL
{

    #region Constructor

    public SPIS_StrategicTree_DAL(IStrategicTree_Mapper mapper) : base(mapper)
    {

    }

    #endregion

    #region Override Members

    public override IList<SPIS_StrategicTree_obj> GetObjectList(string inProject, string inTop)
    {
        var treeList = base.GetObjectList(inProject, inTop);

        foreach (var item in treeList)
        {
            if (item.ParentId == null)
                item.IsParent = true;
            else
                item.IsParent = false;
        }

        return treeList;
    }

    public override SPIS_StrategicTree_obj CreatNewObject()
    {
        return new SPIS_StrategicTree_obj();
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT All * FROM [dbo].[StrategicTree] " + (inProject != null ? "Where History_Id = '" + inProject + "'" : "Where History_Id is NULL");
        //return "SELECT " + inTop + " * FROM [dbo].[StrategicTree] Where History_Id = '" + inProject + "'" ;

    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[StrategicTree] where Id ='" + Id + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[StrategicTree] where Id ='" + inId + "'";
    }

    public override string InsertCommand(SPIS_StrategicTree_obj inNewObject)
    {
        return "INSERT INTO [dbo].[StrategicTree] ([Id] ," +
                                                "[ParentId] ," +
                                                "[History_Id] ," +
                                                "[PrespectiveId] ," +
                                                "[Title] ," +
                                                "[WeightFactor] ," +
                                                "[Target] ," +
                                                "[Actual] ," +
                                                "[ChildrenWeightFactorEffect] ," +
                                                "[KPIWeightFactorEffect] ," +
                                                "[Description] ," +
                                                "[CreateId] ," +
                                                "[CreateDate] ," +
                                                "[UpdateId] ," +
                                                "[UpdateDate] ) " +
                                    "VALUES ('" + inNewObject.Id + "' , " +
                                               (inNewObject.ParentId != null ? "'" + inNewObject.ParentId + "'" : "NULL") + ", " +
                                               (inNewObject.History_Id != null ? "'" + inNewObject.History_Id + "'" : "NULL") + ", " +
                                               (inNewObject.PrespectiveId != null ? "'" + inNewObject.PrespectiveId + "'" : "NULL") + ", '" +
                                                inNewObject.Title + "' , " +
                                                inNewObject.WeightFactor + " , " +
                                                inNewObject.Target + " , " +
                                                inNewObject.Actual + " , " +
                                                inNewObject.ChildrenWeightFactorEffect + " , " +
                                                inNewObject.KPIWeightFactorEffect + " , '" +
                                                inNewObject.Description + "' , '" +
                                                inNewObject.CreateId + "' , " +
                                                "GETDATE() ,'" +
                                                inNewObject.UpdateId + "'," +
                                                "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_StrategicTree_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[StrategicTree] SET [PrespectiveId] = '" + inEditedObject.PrespectiveId + "'" +
                                                ",[Title] = '" + inEditedObject.Title + "' " +
                                                ",[WeightFactor] = " + inEditedObject.WeightFactor + " " +
                                                ",[Target] = " + inEditedObject.Target + " " +
                                                ",[Actual] = " + inEditedObject.Actual + " " +
                                                ",[ChildrenWeightFactorEffect] = " + inEditedObject.ChildrenWeightFactorEffect + " " +
                                                ",[KPIWeightFactorEffect] = " + inEditedObject.KPIWeightFactorEffect + " " +
                                                //  ",[ObjectViewCalculation] = " + inEditedObject.ObjectViewCalculation + " " +
                                                //  ",[TreeViewCalculation] = " + inEditedObject.TreeViewCalculation + " " +
                                                ",[Description] = '" + inEditedObject.Description + "' " +
                                                ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                                ",[UpdateDate] = GETDATE()" +
                                          " where [Id] = '" + inId + "'";
    }

    #endregion

    #region Public Methods

    public IList<SPIS_StrategicTree_obj> GetObjectList(string inProject, string inTop, Guid PreHistoryId)
    {
        var treeList = GetObjectList(inProject, inTop);

        if (PreHistoryId != Guid.Empty)
            foreach (var item in treeList)
            {
                var node = GetObject(item.Title, PreHistoryId.ToString());
                if (node.Title != null)
                    item.Pre_Actual = node.Actual != null ? node.Actual.Value : 0;
            }

        return treeList;
    }

    public IList<SPIS_StrategicTree_obj> GetObjectList(Guid inPrespectiveId, Guid inHitoryId)
    {
        var cmd = new SqlCommand();
        cmd.CommandText = "SELECT  All * FROM [dbo].[StrategicTree] where PrespectiveId ='" + inPrespectiveId + "'" + (inHitoryId != Guid.Empty ? "and History_Id = '" + inHitoryId + "'" : string.Empty);
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            var SDR = cmd.ExecuteReader();
            var ObjectiveList = new List<SPIS_StrategicTree_obj>();
            while (SDR.Read())
            {
                var objective = new SPIS_StrategicTree_obj();
                _Mapper.SetDataToObject(objective, SDR);
                ObjectiveList.Add(objective);
            }
            return ObjectiveList;
        }
        catch (SqlException err)
        {
            throw new ApplicationException("Link Error: " + err.Message);
        }
        finally
        {
            SC.Close();
        }
    }

    public Color GetRowColor(decimal Actual)
    {
        Color result = Color.White;

        if (Convert.ToDecimal(Actual) < 60)
            result = Color.Red;
        else if (Convert.ToDecimal(Actual) >= 60 && Convert.ToDecimal(Actual) < 85)
            result = GetBudgetColor(Convert.ToDecimal(Actual));
        else if (Convert.ToDecimal(Actual) >= 85)
            result = Color.FromArgb(211, 235, 183);

        return result;
    }

    public SPIS_StrategicTree_obj GetObject(string inTitle, string inHitoryId)
    {
        var cmd = new SqlCommand();
        cmd.CommandText = "SELECT  All * FROM [dbo].[StrategicTree] where Title ='" + inTitle + "'" + (inHitoryId != string.Empty ? "and History_Id = '" + inHitoryId + "'" : string.Empty);
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            var SDR = cmd.ExecuteReader();
            var objective = new SPIS_StrategicTree_obj();
            while (SDR.Read())
            {
                _Mapper.SetDataToObject(objective, SDR);
            }
            return objective;
        }
        catch (SqlException err)
        {
            throw new ApplicationException("Link Error: " + err.Message);
        }
        finally
        {
            SC.Close();
        }
    }

    #endregion

    #region Private Methods

    private Color GetBudgetColor(decimal value)
    {
        decimal coeff = value / 100 - 22;
        int a = (int)(0.2M * coeff);
        int b = (int)(0.6M * coeff);
        return Color.FromArgb(255, 235 - a, 177 - b);
    }

    #endregion
}