using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Business;
using Business.Mapper.ISPIS.StrategicTree;
using Business.Repository.ISPIS;
using DAL.Common;
using Helper.Factory;
using SPIS;

/// <summary>
/// Summary description for SPIS_StrategicTreeHistory_DAL
/// </summary>
public class SPIS_StrategicTreeHistory_DAL : Common_DAL<SPIS_StrategicTreeHistory_obj>, ISPIS_StrategicTreeHistory_DAL
{
    #region Constructor

    public SPIS_StrategicTreeHistory_DAL(IStrategicTreeHistory_Mapper mapper) : base(mapper)
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion

    #region Private Properties

    private IFactory factory = new Factory();

    #endregion

    #region Override Members

    public override IList<SPIS_StrategicTreeHistory_obj> GetObjectList(string inProject, string inTop)
    {
        IList<SPIS_StrategicTreeHistory_obj> result = base.GetObjectList(inProject, inTop);

        foreach (var item in result)
        {
            if (item.Company_Id != null)
            {
                var company = factory.Company_DAL.GetObject(item.Company_Id);
                item.CompanyName = company.Name + " /" + item.TreeName;
            }
        }

        return result;
    }

    public override SPIS_StrategicTreeHistory_obj CreatNewObject()
    {
        return new SPIS_StrategicTreeHistory_obj()
        {
            Achieved = 0,
            Target = 0,
        };
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[StrategicTreeHistory] where Id ='" + Id + "' order by CreateDate Desc";
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[StrategicTreeHistory]";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM [dbo].[StrategicTreeHistory] where Id ='" + inId + "'";
    }

    public override string InsertCommand(SPIS_StrategicTreeHistory_obj inNewObject)
    {
        return "INSERT INTO [dbo].[StrategicTreeHistory] ([Id] ," +
                                                        "[TreeName] ," +
                                                        "[Company_Id] ," +
                                                        "[DataTypeId] ," +
                                                        "[StartDate] ," +
                                                        "[EndDate] ," +
                                                        "[Achieved] ," +
                                                        "[Target] ," +
                                                        "[Description] ," +
                                                        "[CreateId] ," +
                                                        "[CreateDate] ," +
                                                        "[UpdateId] ," +
                                                        "[UpdateDate] ) " +
                                          "VALUES ('" + inNewObject.Id + "' , '" +
                                                        inNewObject.TreeName + "' , '" +
                                                        inNewObject.Company_Id + "' , " +
                                                       (inNewObject.DataTypeId != null ? "'" + inNewObject.DataTypeId.ToString() + "','" : "NULL" + ", '") +
                                                        inNewObject.StartDate + "' , '" +
                                                        inNewObject.EndDate + "' , " +
                                                       (inNewObject.Achieved != null ? "" + inNewObject.Achieved.ToString() + "," : "NULL" + ", ") +
                                                       (inNewObject.Target != null ? " " + inNewObject.Target.ToString() + " , '" : "NULL" + ", '") +
                                                        inNewObject.Description + "' , '" +
                                                        inNewObject.CreateId + "' , " +
                                                        "GETDATE() ,'" +
                                                        inNewObject.UpdateId + "'," +
                                                        "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_StrategicTreeHistory_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[StrategicTreeHistory] SET [TreeName] = '" + inEditedObject.TreeName + "' " +
                                                        ",[StartDate] = '" + inEditedObject.StartDate + "' " +
                                                        ",[Company_Id] = '" + inEditedObject.Company_Id + "' " +
                                                        ",[EndDate] = '" + inEditedObject.EndDate + "' " +
                                                        ",[Achieved] = " + (inEditedObject.Achieved != null ? "'" + inEditedObject.Achieved.ToString() + "'" : " NULL" + "") +
                                                        ",[Target] = " + (inEditedObject.Target != null ? "'" + inEditedObject.Target.ToString() + "'" : " NULL" + "") +
                                                        ",[DataTypeId] = " + (inEditedObject.DataTypeId != null ? "'" + inEditedObject.DataTypeId.ToString() + "'" : " NULL" + "") +
                                                        ",[Description] = '" + inEditedObject.Description + "' " +
                                                        ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                                        ",[UpdateDate] = GETDATE()" +
                                                  " where [Id] = '" + inId + "'";
    }

    public override int InsertNewObject(SPIS_StrategicTreeHistory_obj inNewObject)
    {
        var result = base.InsertNewObject(inNewObject);
        IList<SPIS_KPI_obj> newKPIs = new List<SPIS_KPI_obj>();

        if (inNewObject.ImportFrom != null)
        {
            ///Import KPI
            var previousKPI = factory.KPI_DAL.GetObjectList(inNewObject.ImportFrom.ToString(), "All");

            foreach (var kpi in previousKPI)
            {
                var newKPI = new SPIS_KPI_obj();
                newKPI.Id = Guid.NewGuid();
                newKPI.Actual = kpi.Actual;
                newKPI.CreateDate = DateTime.Now;
                newKPI.CreateId = inNewObject.CreateId;
                newKPI.DataTypeId = kpi.DataTypeId;
                newKPI.DataTypeName = kpi.DataTypeName;
                newKPI.DepartmentWeightFactor = kpi.DepartmentWeightFactor;
                newKPI.Description = kpi.Description;
                newKPI.History_Id = inNewObject.Id;
                newKPI.KPIType = kpi.KPIType;
                newKPI.Name = kpi.Name;
                newKPI.OwnerId = kpi.OwnerId;
                newKPI.ProjectId = kpi.ProjectId;
                newKPI.Target = kpi.Target;
                newKPI.Trending = kpi.Trending;

                factory.KPI_DAL.InsertNewObject(newKPI);
                newKPIs.Add(newKPI);
            }

            ///Import TreeView

            var previouseTree = factory.StrategicTree_DAL.GetObjectList(inNewObject.ImportFrom.ToString(), "All");

            foreach (var tree in previouseTree)
            {
                var newTree = new SPIS_StrategicTree_obj();
                newTree.Id = Guid.NewGuid();
                newTree.Actual = tree.Actual;
                newTree.ChildrenWeightFactorEffect = tree.ChildrenWeightFactorEffect;
                newTree.CreateDate = DateTime.Now;
                newTree.CreateId = inNewObject.CreateId;
                newTree.Description = tree.Description;
                newTree.History_Id = inNewObject.Id;
                newTree.IsParent = tree.IsParent;
                newTree.KPIWeightFactorEffect = tree.KPIWeightFactorEffect;
                newTree.ObjectViewCalculation = tree.ObjectViewCalculation;
                newTree.ParentId = tree.ParentId;
                newTree.PrespectiveId = tree.PrespectiveId;
                newTree.Pre_Actual = tree.Pre_Actual;
                newTree.ProjectId = tree.ProjectId;
                newTree.Target = tree.Target;
                newTree.Title = tree.Title;
                newTree.TreeViewCalculation = tree.TreeViewCalculation;
                newTree.WeightFactor = tree.WeightFactor;

                var pre_KPI_Trees = factory.StrategicTree_KPI_DAL.GetObjectList(tree.Id, null, null, "All");

                foreach (var pre_kpi_tree in pre_KPI_Trees)
                {
                    var newkpi = newKPIs.FirstOrDefault(x => x.Name == pre_kpi_tree.KPI_Name);

                    var new_KPI_Tree = new SPIS_StrategicTree_KPI_obj();
                    new_KPI_Tree.KPI_Id = newkpi.Id;
                    new_KPI_Tree.CreateDate = DateTime.Now;
                    new_KPI_Tree.CreateId = inNewObject.CreateId;
                    new_KPI_Tree.DepartmentWeightFactor = pre_kpi_tree.DepartmentWeightFactor;
                    new_KPI_Tree.Description = pre_kpi_tree.Description;
                    new_KPI_Tree.History_Id = inNewObject.Id;
                    new_KPI_Tree.KPI_Actual = pre_kpi_tree.KPI_Actual;
                    new_KPI_Tree.KPI_Id = newkpi.Id;
                    new_KPI_Tree.KPI_Name = newkpi.Name;
                    new_KPI_Tree.KPI_Precentage = pre_kpi_tree.KPI_Precentage;
                    new_KPI_Tree.KPI_Target = pre_kpi_tree.KPI_Target;
                    new_KPI_Tree.KPI_Type = newkpi.KPIType;
                    new_KPI_Tree.ProjectId = newkpi.ProjectId;
                    new_KPI_Tree.KPI_Type = pre_kpi_tree.KPI_Type;
                    new_KPI_Tree.StrategicTree_Id = newTree.Id;
                    new_KPI_Tree.WeightFactor = pre_kpi_tree.WeightFactor;

                    factory.StrategicTree_KPI_DAL.InsertNewObject(new_KPI_Tree);
                }

                factory.StrategicTree_DAL.InsertNewObject(newTree);
            }

            ///Import KPI_TreeView
        }

        return result;
    }

    public override bool DeleteObject(Guid inId)
    {
        var result = base.DeleteObject(inId);

        var kpis = factory.KPI_DAL.GetObjectList(inId.ToString(), null);
        var trees = factory.StrategicTree_DAL.GetObjectList(inId.ToString(), null);
        var kpi_tree = factory.StrategicTree_KPI_DAL.GetObjectList(inId.ToString(), null);

        foreach (var item in kpis)
        {
            factory.KPI_DAL.DeleteObject(item.Id);
        }
        foreach (var item in trees)
        {
            factory.StrategicTree_DAL.DeleteObject(item.Id);
        }
        foreach (var item in kpi_tree)
        {
            factory.StrategicTree_KPI_DAL.DeleteObject(item.StrategicTree_Id.ToString(), item.KPI_Id.ToString());
        }

        return result;
    }

    #endregion
}