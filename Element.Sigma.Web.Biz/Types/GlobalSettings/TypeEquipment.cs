using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeEquipment
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int EquipmentId;
        [DataMember]
        public string EquipmentCodeMain;
        [DataMember]
        public string EquipmentCodeSub;
        [DataMember]
        public string ThirdLevel;
        [DataMember]
        public string Spec;
        [DataMember]
        public string EquipmentType;
        [DataMember]
        public string ModelNumber;
        [DataMember]
        public string Description;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;

        [DataMember]
        public List<TypeCustomField> CustomField;
    }
}
