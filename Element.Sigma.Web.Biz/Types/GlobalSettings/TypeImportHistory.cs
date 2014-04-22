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
    public class TypeImportHistory
    {
        
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ImportHistoryId;
        [DataMember]
        public string ImportCategory;
        [DataMember]
        public string ImportedFileName;
        [DataMember]
        public string ImportedDate;
        [DataMember]
        public int TotalCount;
        [DataMember]
        public int SuccessCount;
        [DataMember]
        public int FailCount;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
