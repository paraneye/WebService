using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.Common
{
    class MTOImportHelper
    {

        #region Import Equipment Libarary Data(Excel)
        /// <summary>
        /// Import Equipment Libarary Data(Excel)
        /// </summary>
        /// <param name="dt">Excel File DataTable</param>
        /// <returns></returns>
        public static DataLoaderEquipmentLib GetDataLoaderEquipmentLib(DataTable dt)
        {
            DataLoaderEquipmentLib loader = new DataLoaderEquipmentLib();

            foreach (DataColumn column in dt.Columns)
            {
                string mycol = column.ColumnName.Trim().ToUpper().Replace("*", "").Replace(" ", "").Replace("-", "").Replace("_", "");

                switch (mycol)
                {
                    //case "CATEGORY 1":
                    case "CATEGORY1":
                        loader.Ord_EquipCodeMain = column.Ordinal;
                        break;
                    //case "CATEGORY 2":
                    case "CATEGORY2":
                        loader.Ord_EquipCodeSub = column.Ordinal;
                        break;
                    //case "CATEGORY 3":
                    case "CATEGORY3":
                        loader.Ord_ThirdLevel = column.Ordinal;
                        break;
                    case "SPEC":
                        loader.Ord_Spec = column.Ordinal;
                        break;
                    case "TYPE":
                        loader.Ord_EquipmentType = column.Ordinal;
                        break;
                    case "MODELNUMBER":
                        loader.Ord_ModelNumber = column.Ordinal;
                        break;
                    case "DESCRIPTION":
                        loader.Ord_Description = column.Ordinal;
                        break;
                }
            }

            return loader;
        }

        #endregion 

        #region Import Material Libarary Data(Excel)
        /// <summary>
        /// Import Material Libarary Data(Excel)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataLoaderMaterialLib GetDataLoaderMaterialLib(DataTable dt)
        {
            DataLoaderMaterialLib loader = new DataLoaderMaterialLib();

            foreach (DataColumn column in dt.Columns)
            {
                string mycol = column.ColumnName.Trim().ToUpper().Replace("*", "").Replace(" ","").Replace("-","").Replace("_","");

                switch (mycol)
                { 
                    case "DISCIPLINE":
                        loader.Ord_Disicipline = column.Ordinal;
                        break;
                    case "TASKCATEGORY":
                        loader.Ord_TaskCategory = column.Ordinal;
                        break;
                    case "TASKTYPE":
                        loader.Ord_TaskType = column.Ordinal;
                        break;
                    case "MATERIALDESCRIPTION":
                    case "DESCRIPTION":
                        loader.Ord_MaterialDescription = column.Ordinal;
                        break;
                    case "VENDOR":
                        loader.Ord_Vendor = column.Ordinal;
                        break;
                    case "PARTNUMBER":
                        loader.Ord_PartNumber = column.Ordinal;
                        break;
                    case "UOM":
                        loader.Ord_UOM = column.Ordinal;
                        break;
                    case "MANHOUR":
                        loader.Ord_ManHour = column.Ordinal;
                        break;
                    case "COSTCODE":
                        loader.Ord_CostCode = column.Ordinal;
                        break;

                }
            }

             return loader;
        }
        #endregion 

        #region Import Consumable Libarary Data(Excel)
        /// <summary>
        /// Import Consumable Libarary Data(Excel)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataLoaderConsumableLib GetDataLoaderConsumableLib(DataTable dt)
        {
            DataLoaderConsumableLib loader = new DataLoaderConsumableLib();

            foreach (DataColumn column in dt.Columns)
            {
                string mycol = column.ColumnName.Trim().ToUpper().Replace("*", "").Replace(" ", "").Replace("-", "").Replace("_", ""); 

                switch (mycol)
                {
                    case "VENDOR":
                        loader.Ord_Vendor = column.Ordinal;
                        break;
                    case "DESCRIPTION":
                        loader.Ord_Description = column.Ordinal;
                        break;
                    case "PARTNUMBER":
                        loader.Ord_PartNumber = column.Ordinal;
                        break;
                    case "UOM":
                        loader.Ord_UOM = column.Ordinal;
                        break;
                }
            }

            return loader;
        }
        #endregion 

        #region Import Drawing Type Data(Excel)
        /// <summary>
        /// Import Drawing Type Data(Excel)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataLoaderDrawingType GetDataLoaderDrawingType(DataTable dt)
        {
            DataLoaderDrawingType loader = new DataLoaderDrawingType();

            foreach (DataColumn column in dt.Columns)
            {
                string mycol = column.ColumnName.Trim().ToUpper().Replace("*", "").Replace(" ", "").Replace("-", "").Replace("_", ""); 

                switch (mycol)
                {
                    case "DRAWINGTYPE":
                        loader.Ord_DrawingType = column.Ordinal;
                        break;
                    case "DRAWINGDESCRIPTION":
                        loader.Ord_Description = column.Ordinal;
                        break;
                }
            }

            return loader;
        }
        #endregion 

        #region convert Data from Civil excel File Data
        /// <summary>
        /// convert Data from Civil excel File Data
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataLoaderCivil GetDataLoaderCivilOrdinal(DataTable dt)
        {
            DataLoaderCivil loader = new DataLoaderCivil();

            foreach (DataColumn column in dt.Columns)
            {
                string mycol = column.ColumnName.Trim().ToUpper().Replace("*", "").Replace(" ", "").Replace("-", "").Replace("_", "");
                string temp = "";
                #region  Validation Header 

                switch (mycol)
                {
                    case "CWP":
                        loader.Ord_CWP = column.Ordinal;
                        break;
                    case "TASKCATEGORY":
                        loader.Ord_TaskCategory = column.Ordinal;
                        break;
                    case "TASKTYPE":
                        loader.Ord_TaskType = column.Ordinal;
                        break;
                    case "MATERIALDESCRIPTION":
                        loader.Ord_MaterialDescription = column.Ordinal;
                        break;
                    case "COSTCODE":
                        loader.Ord_CostCode = column.Ordinal;
                        break;
                    case "DRAWINGNUMBER":
                        loader.Ord_Drawing = column.Ordinal;
                        break;
                    case "DESCRIPTION":
                        loader.Ord_Desc = column.Ordinal;
                        break;
                    case "UDDESCRIPTION":
                        loader.Ord_UDDescription = column.Ordinal;
                        break;
                    case "MANHOURS":
                        loader.Ord_Manhours = column.Ordinal;
                        break;
                    case "UOM":
                        loader.Ord_UOM = column.Ordinal;
                        break;
                    case "QUANTITY":
                    case "QTY":
                        loader.Ord_Qty = column.Ordinal;
                        break;
                    case "STRUCTURENUMBER":
                        loader.Ord_StructureNumber = column.Ordinal;
                        break;
                    case "COMMENT":
                        loader.Ord_Comment = column.Ordinal;
                        break;
                    case "REVISION":
                    case "DRAWINGREVISION":
                        loader.Ord_Revision = column.Ordinal;
                        break;
                    case "ENGINEEREDTAGNUMBER":
                        loader.Ord_EngTagNumber = column.Ordinal;
                        break;
                    case "TAGNUMBER":
                        loader.Ord_TagNumber = column.Ordinal;
                        break;
                    case "ASSOCIATEDCOMPOSITEMATERIALDESCRIPTION":
                        loader.Ord_AssoCompoMaterial = column.Ordinal;
                        break;
                    default :
                        temp = mycol;
                        break;
                }
                #endregion 
            }

            return loader;

        }
        #endregion 


        /// <summary>
        /// reateTagNumber
        /// </summary>
        /// <param name="TmGroupDt"></param>
        /// <param name="Drawing"></param>
        /// <param name="Composite">Composite?</param>
        /// <returns></returns>
        public static string GetCreateTagNumber(DataTable TmGroupDt,  string Drawing, string Composite)
        {
            string tag = string.Empty;
            string tagNumber = string.Empty;

            var q = from TageNumber in TmGroupDt.AsEnumerable()
                    where TageNumber.Field<string>("Tag_Number") == Drawing
                    select TageNumber;


            if (q.ToList().Count > 0)
            {
                int iNo = int.Parse(q.ToList()[0]["no"].ToString());

                if (iNo == 0)
                {
                    tag = Drawing;
                    q.ToList()[0]["no"] = 1;
                }
                else
                {
                    int ino = int.Parse(q.ToList()[0]["no"].ToString());
                    q.ToList()[0]["no"] = ino + 1;

                    if (Composite == string.Empty)
                    {
                        tagNumber = string.Format("{0}-T{1}", Drawing, (int.Parse(q.ToList()[0]["no"].ToString()) - 1));
                    }
                    else 
                    {
                        tagNumber = string.Format("{0}-{1}-T{2}", Composite, Drawing, (int.Parse(q.ToList()[0]["no"].ToString()) - 1));//CO앞에 붙여서 Composite구분하게
                    }
                    tag = tagNumber;
                }
            }


            return tag;
        }
    }
}
