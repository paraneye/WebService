using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Element.Shared.Common
{
    public class MessageHandler
    {
        public static string GetErrorMessage(string errorCode)
        {
            string errorMessage = "TBD";
            switch (errorCode)
            {
                case "AUTH0001":
                    errorMessage = "User is not registered.";
                    break;

                case "AUTH0002":
                    errorMessage = "Password is not matched.";
                    break;

                case "AUTH0003":
                    errorMessage = "OldPasswords do not match. Do you want to try again?";
                    break;

                case "AUTH0004":
                    errorMessage = "NewPasswords do not match. Do you want to try again?";
                    break;

                case "AUTH0005":
                    errorMessage = "Email Address is not matched.";
                    break;

            }
            return errorMessage;
        }
    }
}
