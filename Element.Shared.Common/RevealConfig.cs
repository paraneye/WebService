using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Element.Shared.Common
{
    /// <summary>
    /// Summary description for Config
    /// </summary>
    public class RevealConfig
    {
    }
   

    public static class UploadPath
    {
        public static String Root { get { return HttpContext.Current.Server.MapPath("~/") + "\\"; } }
        public static String Temp { get { return Root + "Temp\\"; } }
        public static String CompanyLogo { get { return Root + "images\\logo\\"; } }
    }

}
