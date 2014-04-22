using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Element.Shared.Common
{
    [DataContract]
    [Serializable]
    public abstract class DTOBase 
    {
        [DataMember] 
        public int DTOStatus { get; set; }
        [DataMember] 
        public string ExceptionMessage { get; set; }

        // Xml Serialization Infrastructure
    }
}
