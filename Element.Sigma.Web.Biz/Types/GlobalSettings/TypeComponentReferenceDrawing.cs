using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeComponentReferenceDrawing
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ComponentReferenceDrawingId;
        [DataMember]
        public int ComponentId;
        [DataMember]
        public int DrawingId;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
