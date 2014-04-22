using System;
using System.Runtime.Serialization;


namespace Element.Sigma.Web.Biz.Types.ProjectData
{
    [DataContract]
    [Serializable]
    public class TypeDrawing
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public string DrawingId;
        [DataMember]
        public string CWP;
        [DataMember]
        public string Name;
        [DataMember]
        public string FileName;
        [DataMember]
        public string FilePath;
        [DataMember]
        public string Revision;
        [DataMember]
        public string Title;
        [DataMember]
        public string DrawingType;
        [DataMember]
        public string Description;
        [DataMember]
        public string ReferenceDrawings;
        [DataMember]
        public string DetailedDrawings;
        [DataMember]
        public string IsBinded;
        [DataMember]
        public string UploadedFileInfoId;
        [DataMember]
        public string ImportedSourceFileInfoID;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
        [DataMember]
        public string FileStoreId;
    }
}
