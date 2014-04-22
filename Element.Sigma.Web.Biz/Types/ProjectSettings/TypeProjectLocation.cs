using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypeProjectLocation
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public string Country;
        [DataMember]
        public string County;
    }

}
