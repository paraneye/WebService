using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Element.Sigma.Web.Service.Auth
{
    public partial class CookieSetter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = new HttpCookie("SigmaUser");
            // Set the cookie value.
            userCookie.Value = "admin";
            // Set the cookie expiration date.
            userCookie.Expires = DateTime.Now.AddMinutes(10);
            // Add the cookie.
            Response.Cookies.Add(userCookie);

            HttpCookie projCookie = new HttpCookie("CurrentProject");
            // Set the cookie value.
            projCookie.Value = "admin";
            // Set the cookie expiration date.
            projCookie.Expires = DateTime.Now.AddMinutes(10);
            // Add the cookie.
            Response.Cookies.Add(projCookie);


            Response.Write("<p> The cookie has been written.");
        }
    }
}