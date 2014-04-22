using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeMaterial
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int MaterialId;
        [DataMember]
        public string DisciplineCode;
        [DataMember]
        public int TaskCategoryId;
        [DataMember]
        public int TaskTypeId;
        [DataMember]
        public decimal Manhours;
        [DataMember]
        public string UomCode;
        [DataMember]
        public string Vendor;
        [DataMember]
        public string PartNumber;
        [DataMember]
        public string IsConsumable;
        [DataMember]
        public string Description;
        [DataMember]
        public int CostCodeId;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;

        [DataMember]
        public List<TypeCustomField> CustomField;
    }

}

