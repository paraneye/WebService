using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeCustomField
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int CustomFieldId;
        [DataMember]
        public string FieldType;
        [DataMember]
        public string FieldName;
        [DataMember]
        public string IsDisplayable;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
        [DataMember]
        public string DisciplineCode;

        [DataMember]
        public int Parentid;    //MaterialID, EquipmentID
        [DataMember]
        public string Value;

    }
}
