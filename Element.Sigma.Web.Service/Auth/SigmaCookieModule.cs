using System;
using System.Web;

namespace Element.Sigma.Web.Service.Auth
{
    public class SigmaCookieModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication application)
        {
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));

        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension = VirtualPathUtility.GetExtension(filePath);

            
            if (context.Request.Cookies["SigmaUser"] == null)
            {
                context.Response.Cookies["SigmaUser"].Value = "Unknown";

                //if (filePath != "/ui/index.html")
                //{
                //    //HttpContext.Current.Response.Cookies["userName"].Value = userName;
                //    context.Response.Redirect("/ui/index.html");
                //}
            }

            //if (context.Session == null) {

            //    context.Session.Add("Init", "Y");
            //    context.Response.Redirect("/ui/index.html");
            //}

            

        }

        #endregion

    }
}
