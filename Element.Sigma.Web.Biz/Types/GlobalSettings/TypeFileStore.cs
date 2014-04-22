using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeFileStore
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ProjectId;
        [DataMember]
        public int FileStoreId;
        [DataMember]
        public string FileTitle;
        [DataMember]
        public string FileDescription;
        [DataMember]
        public string FileCategory;
        [DataMember]
        public string FileTypeCode;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
        [DataMember]
        public TypeUploadedFileInfo UploadedFileInfo;
    }
}
