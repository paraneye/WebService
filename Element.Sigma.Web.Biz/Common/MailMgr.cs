using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Element.Shared.Common;
using System.Net.Mail;
using System.Text;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.GlobalSettings;
using System;

namespace Element.Sigma.Web.Biz.Common
{
    public class MailMgr
    {
        public SigmaResultType ForgotPassword(string userId, string email)
        {
            SigmaResultType result = new SigmaResultType();
            SigmaUserMgr sigmauserMgr = new SigmaUserMgr();
            TypeSigmaUser objSigmaUser = GetSigmaUser(userId);

            if (objSigmaUser == null)
            {
                result.JsonDataSet = "[]";
                result.AffectedRow = 0;
                result.IsSuccessful = false;
                result.ErrorCode = "AUTH0001";
                result.ErrorMessage = MessageHandler.GetErrorMessage("AUTH0001");
                return result;
            }
            else
            {
                if (!string.IsNullOrEmpty(objSigmaUser.Email) && !objSigmaUser.Email.Equals(email))
                {
                    result.JsonDataSet = "[]";
                    result.AffectedRow = 0;
                    result.IsSuccessful = false;
                    result.ErrorCode = "AUTH0005";
                    result.ErrorMessage = MessageHandler.GetErrorMessage("AUTH0005");
                    return result;
                }
            }

            //init password
            SigmaResultType inipwd = sigmauserMgr.InitPassword(objSigmaUser);
            objSigmaUser.Password = inipwd.StringValue;

            result = SendMail(objSigmaUser);

            result.IsSuccessful = true;
            return result;
        }
        public SigmaResultType SendMail(TypeSigmaUser objSigmaUser)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("support@elementindustrial.com", "Administrator", System.Text.Encoding.UTF8);
                mail.To.Add(objSigmaUser.Email);
                mail.IsBodyHtml = true;
                mail.Subject = "Element Sigma Login confirmation";

                mail.Body = GetMailMessage(objSigmaUser);
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                //SmtpClient scClient = new SmtpClient("127.0.0.1", 587);
                SmtpClient scClient = new SmtpClient("127.0.0.1", 25);
                //scClient.EnableSsl = true;
                scClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //scClient.Credentials = new System.Net.NetworkCredential("elementmailsender@gmail.com", "P@ssw0rd!1");

                scClient.Send(mail);
                mail.Dispose();
            }
            catch
            {
                //throw new Exception("Invalid Email Address");
            }

            return result;
        }

        private TypeSigmaUser GetSigmaUser(string sigmaUserId)
        {
            TypeSigmaUser result = new TypeSigmaUser();
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@sigmaUserId", sigmaUserId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaUser", parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow r = ds.Tables[0].Rows[0];
                result.SigmaUserId = r["SigmaUserId"].ToString();
                result.FirstName = r["FirstName"].ToString();
                result.LastName = r["LastName"].ToString();
                result.Email = r["Email"].ToString();

                return result;
            }
         
            // return
            return null;
        }

        private string GetMailMessage(TypeSigmaUser objSigmaUser)
        {
            StringBuilder txtBody = new StringBuilder();
            string body = string.Empty;
            string username = objSigmaUser.FirstName + " " + objSigmaUser.LastName;
            string loginid = objSigmaUser.SigmaUserId;
            string password = objSigmaUser.Password;
            txtBody.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.1//EN' 'http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd'>");
            txtBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            txtBody.Append("<head>");
            txtBody.Append("<style type=\"text/css\">");
            txtBody.Append(".tbl {");
            txtBody.Append("border:2px solid;");
            txtBody.Append("border-collapse:collapse;");
            txtBody.Append("padding:10px;");
            txtBody.Append("font-family:\"calibri\";font-size:15pt;} ");
            txtBody.Append("</style>");
            txtBody.Append("<title>mail</title>");
            txtBody.Append("<meta http-equiv='Content-Type' content='text/html; charset=euc-kr'>");
            txtBody.Append("</head>");
            txtBody.Append("<body>");
            txtBody.Append("<table class=\"tbl\"><tr><td>");
            txtBody.Append("<b><font size=\"20\">Subject : Element Sigma login confirmation</font></b></br></br>");
            txtBody.Append("From : <a href=\"support@elementindustrial.com\">support@elementindustrial.com</a></br></br>");
            txtBody.Append("Dear " + username + ",</br></br>");
            txtBody.Append("Welcome to Element Sigma</br></br>");
            txtBody.Append("Please note that your login name and temporary password are granted:</br></br>");
            txtBody.Append("User Login id : " + loginid  + "</br>");
            txtBody.Append("Temporary password : <b>" + password + "</b></br>");
            txtBody.Append("You'll be asked to set a new password when you log in.</br></br>");
            txtBody.Append("To log in now, click <a href=\"http://web.elementindustrial.com\">http://web.elementindustrial.com</a></br></br>");
            txtBody.Append("Regards,</br></br>");
            txtBody.Append("Element team</br>");
            txtBody.Append("</td></tr></table>");
            txtBody.Append("</body>");
            txtBody.Append("</html>");
            body = txtBody.ToString();

            return body;
        }
    }
}
