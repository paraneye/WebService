using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.Auth;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.Common
{
    public class ConfigMgr
    {
        public static string GetExportFilePath()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            string iisvirtualpath = HttpContext.Current.Server.MapPath("/SigmaStorage");
            string exportfilepath = iisvirtualpath + "\\" + System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentTemplate"]
                                                   + "\\" + userinfo.CompanyName + "\\" + userinfo.CurrentProjectId + "\\exportfiles";
            return exportfilepath;
        }


        public static string GetDynamicTemplateFilePath(string templatetype)
        {
            // case of projectcostcode
            string iisvirtualpath = HttpContext.Current.Server.MapPath("/SigmaStorage");
            string templatefilepath = iisvirtualpath + "\\" + System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentTemplate"] + "\\" + templatetype;
            return templatefilepath;
        }

        public static string GetImportFilePath()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            string iisvirtualpath = HttpContext.Current.Server.MapPath("/SigmaStorage");
            return iisvirtualpath + "\\" + System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"] + "\\";

        }

        public static string GetTargetPath()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            string iisvirtualpath = HttpContext.Current.Server.MapPath("/SigmaStorage");
            return iisvirtualpath + "\\" + System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentFolderRoot"] + "\\";
            
        }
    }
}
