using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Element.Sigma.Web.Biz.Common
{

    /// <summary>
    /// Set Equipment Lib Excel File Data
    /// </summary>
    public class DataLoaderEquipmentLib
    {
        public int Ord_EquipCodeMain;
        public int Ord_EquipCodeSub;
        public int Ord_ThirdLevel;
        public int Ord_Spec;
        public int Ord_EquipmentType;
        public int Ord_ModelNumber;
        public int Ord_Description;
    }

    /// <summary>
    /// Set Material Lib Excel File Data
    /// </summary>
    public class DataLoaderMaterialLib
    {
        public int Ord_Disicipline;
        public int Ord_TaskCategory;
        public int Ord_TaskType;
        public int Ord_MaterialDescription;
        public int Ord_Vendor;
        public int Ord_PartNumber;
        public int Ord_UOM;
        public int Ord_ManHour;
        public int Ord_CostCode;

    }

    /// <summary>
    /// Set Material Lib Excel File Data
    /// </summary>
    public class DataLoaderConsumableLib
    {
        public int Ord_Vendor;
        public int Ord_Description;
        public int Ord_PartNumber;
        public int Ord_UOM;
    }

    /// <summary>
    /// Set Material Lib Excel File Data
    /// </summary>
    public class DataLoaderDrawingType
    {
        public int Ord_DrawingType;
        public int Ord_Description;
    }

    /// <summary>
    /// Set Civil Excel File Data
    /// </summary>
    public class DataLoaderCivil
    {
        public int Ord_CostCode;
        public int Ord_Sched;
        public int Ord_Qty;
        public int Ord_UOM;
        public int Ord_Desc;
        public int Ord_CWP;
        public int Ord_TaskCategory;
        public int Ord_TaskType;
        public int Ord_Drawing;
        public int Ord_MaterialDescription;
        public int Ord_EngTagNumber;
        public int Ord_UDDescription;
        public int Ord_PileNum;
        public int Ord_StructureNumber;
        public int Ord_EquipTag;
        public int Ord_Manhours;
        public int Ord_Comment;
        public int Ord_Revision;
        public int Ord_TagNumber;
        public int Ord_AssoCompoMaterial;

        // Constructor
        public DataLoaderCivil()
        {
        }
    }
}