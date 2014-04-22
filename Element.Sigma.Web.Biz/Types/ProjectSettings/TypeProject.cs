using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypeProject
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ProjectId;
        [DataMember]
        public string ProjectName;
        [DataMember]
        public string ProjectNumber;
        [DataMember]
        public string ProjectDescription;
        [DataMember]
        public int CompanyId;
        [DataMember]
        public string CountryName;
        [DataMember]
        public string CountyName;
        [DataMember]
        public string CityName;
        [DataMember]
        public string LogoFilePath;
        [DataMember]
        public int ClientCompanyId;
        [DataMember]
        public string ClientProjectId;
        [DataMember]
        public string ClientProjectName;
        [DataMember]
        public string IsActive;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;

        [DataMember]
        public string ProjectManagerId; 
        [DataMember]
        public List<TypeProjectDiscipline> ProjectDiscipline;
        [DataMember]
        public List<TypeProjectSubcontractor> ProjectSubcontractor;

    }

}
