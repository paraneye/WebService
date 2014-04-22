using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeProgressTypeMap
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ProgressTypeMapId;
        [DataMember]
        public string DisciplineCode;
        [DataMember]
        public int TaskCategoryId;
        [DataMember]
        public int TaskTypeId;
        [DataMember]
        public int ProgressTypeId;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
