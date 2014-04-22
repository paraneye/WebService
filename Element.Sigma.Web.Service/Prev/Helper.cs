using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Element.Sigma.Web.Service.Prev
{
    public static class Helper
    {
        public static string DatabaseName
        {
            get { return System.Web.Configuration.WebConfigurationManager.AppSettings["DatabaseInstanceName"]; }
        }

        public static string ActiveDirectoryServer
        {
            get { return System.Web.Configuration.WebConfigurationManager.AppSettings["ActiveDirectoryServer"]; }
        }

        public static string P6Login
        {
            get { return System.Web.Configuration.WebConfigurationManager.AppSettings["P6Login"]; }
        }

        public static string SPLogin
        {
            get { return System.Web.Configuration.WebConfigurationManager.AppSettings["SPLogin"]; }
        }

        public static string WebDAVLogin
        {
            get { return System.Web.Configuration.WebConfigurationManager.AppSettings["WebDAVLogin"]; }
        }

        public static string DrawingPageSize
        {
            get { return System.Web.Configuration.WebConfigurationManager.AppSettings["PageSize"]; }
        }

        public static string ProjectSPURL
        {
            get { return System.Web.Configuration.WebConfigurationManager.AppSettings["ProjectSharePointAddr"]; }
        }

        public static string[] SMTPINfo
        {
            get
            {
                string[] ret = new string[] { "", "", "" };
                string smtp = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPInfo"];

                if (!string.IsNullOrEmpty(smtp))
                    ret = smtp.Split(';');

                return ret;
            }
        }

        //public static Element.Reveal.Server.BALC.P6Manager P6Manager
        //{
        //    get { return new Element.Reveal.Server.BALC.P6Manager(); }
        //}

        //public static Element.Reveal.Server.BALC.ProjectReader ProjectReader
        //{
        //    get { return new Element.Reveal.Server.BALC.ProjectReader(); }
        //}

        //public static Element.Reveal.Server.BALC.ProjectWriter ProjectWriter
        //{
        //    get { return new Element.Reveal.Server.BALC.ProjectWriter(); }
        //}

        public static bool isUsingMpp
        {
            get
            {
                string isUsingMppStr = System.Web.Configuration.WebConfigurationManager.AppSettings["IsUsingMpp"] != null ? System.Web.Configuration.WebConfigurationManager.AppSettings["IsUsingMpp"] : "false";
                if (isUsingMppStr.ToLower() == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string GetImageLocationURL()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ImageLocationURL"];
        }

        public static string GetWebrootUrl()
        {
            string str = HttpContext.Current.Request.Url.Host;
            if (str.Substring(0, 7).ToLower() != "http://")
                str = "http://" + str;

            return str;
        }

        public static string GetImagePhysicalPath()
        {

            string path = System.Configuration.ConfigurationManager.AppSettings["PhysicalImagePath"];

            if (System.ServiceModel.OperationContext.Current != null && (string.IsNullOrEmpty(path)))
            {
                string[] a_ifc_url = null;
                string ifc_url = System.Configuration.ConfigurationManager.AppSettings["ImageLocationURL"].ToString();

                if (!string.IsNullOrEmpty(ifc_url))
                {
                    ifc_url = ifc_url.ToLower().Replace(@"http://", ""); //for splitting, remove "http://" header
                    a_ifc_url = ifc_url.Split('/');
                }

                var current = System.ServiceModel.OperationContext.Current;

                int index = current.IncomingMessageHeaders.To.AbsoluteUri.IndexOf(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);

                if (index > 0 && (current.IncomingMessageHeaders.To.AbsoluteUri.Substring(0, index) == @"http://" + a_ifc_url[0])) //if it is same server
                {
                    string url = current.IncomingMessageHeaders.To.AbsoluteUri.Substring(0, index);

                    for (int i = 1; i < a_ifc_url.Length; i++)
                        url += @"/" + a_ifc_url[i];

                    path = Cookies.GetMapPath(url);
                }
            }

            return path;

        }

        public static List<int> GetIntParameter(string Ids)
        {
            List<int> list_ids = new List<int>();

            string[] pattern = { "{", "}", "\"" };
            Ids = Element.Shared.Common.Utilities.ToGetStringRemoved(Ids, pattern);

            if (!string.IsNullOrEmpty(Ids))
            {
                string[] parts = Ids.Split(',');

                if (parts != null && parts.Length > 0)
                {
                    foreach (string part in parts)
                        list_ids.Add(Int32.Parse(part));
                }
            }
            return list_ids;

        }

        public static string RemoveJsonParameterWrapper(string value)
        {
            string[] pattern = { "{", "}" };
            value = Element.Shared.Common.Utilities.ToGetStringRemoved(value, pattern);
            return value;
        }

        public static string ConvertStringToDateTimeString(string value)
        {
            string newDate;
            if (value.Length == 14)
                newDate = value.Substring(0, 4) + "-" + value.Substring(4, 2) + "-" + value.Substring(6, 2) + " " + value.Substring(8, 2) + ":" + value.Substring(10, 2) + ":" + value.Substring(12, 2);
            else if (value.Length == 8)
                newDate = value.Substring(0, 4) + "-" + value.Substring(4, 2) + "-" + value.Substring(6, 2);
            else
                newDate = value;

            return newDate;
        }
    }

    public class Cookies
    {
        public static void SetP6Connection(System.Net.CookieContainer P6Login)
        {
            HttpContext.Current.Session.Add("P6Connection", P6Login);
        }

        public static System.Net.CookieContainer GetP6Connection()
        {
            return ((System.Net.CookieContainer)HttpContext.Current.Session["P6Connection"]);
        }

        public static string GetMapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }

        public static string GetImageURL()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ImageLocationURL"];
        }

        public static string[] GetSPCredential()
        {
            string[] rtn = new string[2];
            string login = System.Web.Configuration.WebConfigurationManager.AppSettings["SPLogin"];

            if (!string.IsNullOrEmpty(login))
            {
                rtn = login.Split(';');
                if (rtn.Length > 1)
                {
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.Session["SPUserID"] = rtn[0];
                        HttpContext.Current.Session["SPPassword"] = rtn[1];
                    }
                }
            }

            return rtn;
        }

    }

}