using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeTaskType
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int TaskTypeId;
        [DataMember]
        public int TaskCategoryId;
        [DataMember]
        public string TaskTypeCode;
        [DataMember]
        public string TaskTypeShortName;
        [DataMember]
        public string TaskTypeName;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;

        [DataMember]
        public string DisciplineCode;
    }
}
