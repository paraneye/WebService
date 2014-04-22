using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.Types.Auth
{
    public class TypeUserInfo
    {
        public string SigmaUserId;
        public int CompanyId;
        public string CompanyName;
        public int ClientCompanyId;
		public int CurrentProjectId;
        public string CurrentProjectName;
        public int CurrentSigmaRoleId;
        public string CurrentSigmaRoleName;
    }
}
