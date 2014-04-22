using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeTaskCategory
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int TaskCategoryId;
        [DataMember]
        public string DisciplineCode;
        [DataMember]
        public string TaskCategoryCode;
        [DataMember]
        public string TaskCategoryName;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
