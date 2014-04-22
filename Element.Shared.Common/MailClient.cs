using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
namespace Element.Shared.Common
{
    public class MailClient : IDisposable
    {
        private SmtpClient _smtpClient;
        private MailMessage _msg;

        public MailAddress From
        {
            get { return _msg.From; }
            set { _msg.From = value; }
        }
        public MailAddressCollection To
        {
            get { return _msg.To; }
            set
            {
                foreach (MailAddress add in value)
                {
                    _msg.To.Add(add);
                }
            }
        }
        public MailAddressCollection CC
        {
            get { return _msg.CC; }
            set
            {
                foreach (MailAddress add in value)
                {
                    _msg.CC.Add(add);
                }
            }
        }
        public MailAddressCollection BCC
        {
            get { return _msg.Bcc; }
            set
            {
                foreach (MailAddress add in value)
                {
                    _msg.Bcc.Add(add);
                }
            }
        }

        public MailClient()
        {
            //_smtpClient = new SmtpClient("smtp.bluedomino.com", 587);
            //_smtpClient.Credentials = new System.Net.NetworkCredential("dan@elementindustrial.com", "element1");
            //_smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //_smtpClient.UseDefaultCredentials = false;
            _smtpClient = new SmtpClient();
            _smtpClient.EnableSsl = false;

            _msg = new MailMessage();
            _msg.Priority = MailPriority.Normal;
            _msg.IsBodyHtml = false;
        }

        public void Send(string subject, string body)
        {
            _msg.Subject = subject;
            _msg.Body = body;

            try
            {
                _smtpClient.Send(_msg);
            }
            catch (SmtpException ex)
            {
                throw ex.InnerException != null ? ex.InnerException : new Exception(ex.Message);
            }
            finally
            {
                _msg.To.Clear();
                _msg.CC.Clear();
                _msg.Bcc.Clear();
            }
        }


        public void Send(string subject, string body, bool isBodyHtml)
        {
            _msg.IsBodyHtml = isBodyHtml;
            Send(subject, body);
        }

        public void Send(string subject, string body, MailPriority priority)
        {
            _msg.Priority = priority;
            Send(subject, body);
        }

        public void Send(string subject, string body, bool isBodyHtml, MailPriority priority)
        {
            _msg.IsBodyHtml = isBodyHtml;
            _msg.Priority = priority;
            Send(subject, body);
        }

        public void Dispose()
        {
            _msg.Dispose();
            GC.SuppressFinalize(this);
        }

        #region "Static Functions"

        public static MailAddress StringToMailAddress(string address, string name)
        {
            return new MailAddress(address, name);
        }

        public static MailAddressCollection StringToMailAdressCollection(string address)
        {
            MailAddressCollection addCollection = new MailAddressCollection();
            string[] addresses = address.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string ss in addresses)
            {
                addCollection.Add(new MailAddress(ss));
            }

            return addCollection;
        }

        #endregion
    }
}