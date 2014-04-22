using System;
using System.Runtime.Serialization;


namespace Element.Sigma.Web.Biz.Types.MTO
{
    /// <summary>
    ///  Get MTO(Civil) Info
    ///  ref: [usp_GetCivilByFileName]
    /// </summary>
    [DataContract]
    [Serializable]
    public class TypeMTO
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int DrawingId;
        [DataMember]
        public int ComponentId;
        [DataMember]
        public string ComponentName;
        [DataMember]
        public int MaterialId;
        [DataMember]
        public string MaterialName;
        [DataMember]
        public int TaskCategoryId;
        [DataMember]
        public string TaskCategoryName;
        [DataMember]
        public int TaskTypeId;
        [DataMember]
        public string TaskTypeName;
        [DataMember]
        public string Value;//CustomfieldName = 'STRUCTURE'
        [DataMember]
        public int Qty;
        [DataMember]
        public string UOM;
        [DataMember]
        public string PartNumber;
        [DataMember]
        public string Vendor;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }

}
