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
    public class TypeUploadedFileInfo
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int UploadedFileInfoId;
        [DataMember]
        public int FileStoreId;
        [DataMember]
        public string Name;
        [DataMember]
        public int Size;
        [DataMember]
        public string Path;
        [DataMember]
        public string UploadedBy;
        [DataMember]
        public string UploadedDate;
        [DataMember]
        public string FileExtension;
        [DataMember]
        public string Revision;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
