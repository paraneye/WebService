using System;
using System.Web;

namespace Element.Sigma.Web.Service.Auth
{
    public class AuthCookieHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string user = HttpContext.Current.Request.Cookies["SigmaUser"].Value;
            if (user == null)
            {
                context.Server.Transfer("/index.html");
            }

            //context.Response.ContentType = "text/plain";

            //if (context.Request.RawUrl.Contains(".cspx"))
            //{
            //    string newUrl = context.Request.RawUrl.Replace(".cspx", ".aspx");
            //    context.Server.Transfer(newUrl);
            //}


        }

        #endregion
    }
}
