using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Element.Sigma.Web.Biz.Types.MTO;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeMaterialInfo
    {
        [DataMember]
        public TypeMaterial Material;
        [DataMember]
        public List<TypeCustomField> CustomField;
    }
}
