using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeProgressStep
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ProgressStepId;
        [DataMember]
        public int ProgressTypeId;
        [DataMember]
        public string Name;
        [DataMember]
        public string IsMultipliable;
        [DataMember]
        public int Weight;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }

}
