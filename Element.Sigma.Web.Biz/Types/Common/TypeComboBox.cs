using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.Types.Common
{
    [DataContract]
    [Serializable]
    public class TypeComboBox
    {
        [DataMember]
        public int ComboId;
        [DataMember]
        public string ComboName;
        [DataMember]
        public string ExtraValue1;

        [DataMember]
        public int ParentId;
    }
}
