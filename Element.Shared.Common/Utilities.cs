using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace Element.Shared.Common
{
    public class Utilities
    {
        public static DateTime DateTimeMinValue
        {
            get
            {
                return new DateTime(1753, 1, 1);
            }
        }

        /// <summary>
        /// Get all constant field from classs or structure
        /// </summary>
        /// <param name="type">Type of Class or Structure which includes constant field. It can be taken by typeof</param>        
        /// <returns></returns>
        public static List<System.Reflection.FieldInfo> GetAllConstant(System.Type type)
        {
            List<System.Reflection.FieldInfo> fields = new List<System.Reflection.FieldInfo>();
            System.Reflection.FieldInfo[] fieldInfos = type.GetFields(
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static |
                System.Reflection.BindingFlags.FlattenHierarchy);

            try
            {
                foreach (System.Reflection.FieldInfo fi in fieldInfos)
                    if (fi.IsLiteral && !fi.IsInitOnly)
                        fields.Add(fi);
            }
            catch { }

            return fields.ToList();
        }

        /// <summary>
        /// Get specific constant field from classs or structure
        /// </summary>
        /// <param name="type">Type of Class or Structure which includes constant field. It can be taken by typeof</param>
        /// <param name="value">Value of the constant field you want to find</param>
        /// <returns></returns>
        public static System.Reflection.FieldInfo GetConstantByValue(System.Type type, int value)
        {
            System.Reflection.FieldInfo field = null;
            System.Reflection.FieldInfo[] fieldInfos = type.GetFields(
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static |
                System.Reflection.BindingFlags.FlattenHierarchy);

            try
            {
                foreach (System.Reflection.FieldInfo fi in fieldInfos)

                    if (fi.IsLiteral && !fi.IsInitOnly && Convert.ToInt32(fi.GetRawConstantValue()) == value)
                        field = fi;
            }
            catch { }

            return field;
        }

        public static System.Reflection.FieldInfo GetConstantByValue(System.Type type, object value)
        {
            System.Reflection.FieldInfo field = null;

            if (value != null)
            {
                System.Reflection.FieldInfo[] fieldInfos = type.GetFields(
                    System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static |
                    System.Reflection.BindingFlags.FlattenHierarchy);

                try
                {
                    foreach (System.Reflection.FieldInfo fi in fieldInfos)

                        if (fi.IsLiteral && !fi.IsInitOnly && fi.GetRawConstantValue().ToString() == value.ToString())
                            field = fi;
                }
                catch { }
            }

            return field;
        }

        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                //throw new ArgumentException("The type must be serializable.", "source");
                return default(T);
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            System.IO.Stream stream = new System.IO.MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static byte[] GetMD5Encrypted(string password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(md5.ComputeHash(encoder.GetBytes(password)));
            byte[] hashedBytes = ms.ToArray();

            return hashedBytes;
        }

        public static string GetSHA1Hash(string password)
        {

            System.Security.Cryptography.SHA1CryptoServiceProvider oSHA1Hasher =
                       new System.Security.Cryptography.SHA1CryptoServiceProvider();
            Byte[] hashedBytes = null;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();

            hashedBytes = oSHA1Hasher.ComputeHash(encoder.GetBytes(password));

            return System.Text.UTF8Encoding.Default.GetString(hashedBytes);
        }

        public static void ChangeTheme(System.Web.UI.Page page)
        {
            if (page.IsPostBack)
            {
                string themeValue = page.Request["ThemeValue"];
                if (themeValue == null)
                {
                    if (Cookies.GetSessionValue("ThemeValue") != null)
                    {
                        page.Theme = Convert.ToString(Cookies.GetSessionValue("ThemeValue"));
                    }
                    else
                    {
                        page.Theme = "Office2007";
                        Cookies.SetSessionValue("ThemeValue", page.Theme);
                    }
                }
                else
                {
                    page.Theme = page.Request[themeValue];
                    Cookies.SetSessionValue("ThemeValue", page.Theme);
                }
            }
            else if (Cookies.GetSessionValue("ThemeValue") != null)
            {
                page.Theme = Convert.ToString(Cookies.GetSessionValue("ThemeValue"));
            }
            else
            {
                page.Theme = "Office2007";
                Cookies.SetSessionValue("ThemeValue", page.Theme);
            }
        }

        public static void sendEmail(string emailTo, string subject, string body)
        {
            MailClient mc = new MailClient();
            mc.To = MailClient.StringToMailAdressCollection(emailTo);
        }

        public static string BuildIDArrayXMLParametr(int[] Ids) 
        {
            System.Text.StringBuilder strXml = null;

            try
            {
                if (Ids != null && Ids.Length > 0)
                {
                    strXml = new System.Text.StringBuilder();
                    strXml.Append("<ids>");

                    foreach (int id in Ids)
                    {
                        strXml.Append("<id id1=" + (char)34 + id.ToString() + (char)34 + "/>");
                    }

                    strXml.Append("</ids>");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Not able to create xmlParameter.", ex);
            }

            return strXml == null ? null : strXml.ToString();
        }

        public static string BuildIDArrayXMLParametr(string[] Ids) 
        {
            System.Text.StringBuilder strXml = null;

            try
            {
                if (Ids.Length > 0)
                {
                    strXml = new System.Text.StringBuilder();
                    strXml.Append("<ids>");
                    foreach (string id in Ids)
                    {
                        strXml.Append("<id id1=" + (char)34 + id + (char)34 + "/>");
                    }
                    strXml.Append("</ids>");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Not able to create xmlParameter.", ex);
            }

            return strXml == null ? null : strXml.ToString();
        }

        public static bool ColumnExists(IDataReader reader, string columnName)
        {
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName= '" + columnName + "'";
            return (reader.GetSchemaTable().DefaultView.Count > 0);
        }

        public static int ToInt32(string value)
        {
            int retValue = 0;

            try
            {
                retValue = Convert.ToInt32(value);
            }
            catch { }

            return retValue;
        }

        public static double ToDouble(string value)
        {
            double retValue = 0;

            try
            {
                retValue = Convert.ToDouble(value);
            }
            catch { }

            return retValue;
        }

        public static decimal ToDecimal(string value)
        {
            decimal retValue = 0;

            try
            {
                retValue = Convert.ToDecimal(value);
            }
            catch { }
            return retValue;
        }

        public static DateTime ToDateTime(string value)
        {
            DateTime retValue = DateTime.MinValue;

            try
            {
                retValue = Convert.ToDateTime(value);
            }
            catch { }

            return retValue;
        }

        public static string ToGetStringRemoved(string input, string[] pattern)
        {
            foreach (string key in pattern)
                input = input.Replace(key, string.Empty);

            return input;
        }

        //public static List<byte[]> ConvertPdfToJpg(byte[] fileData, int iDPI)
        //{
        //    List<byte[]> listImage = new List<byte[]>();
        //    try
        //    {
        //        SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
        //        f.OpenPdf(fileData);

        //        for (int i = 1; i < f.PageCount + 1; i++)
        //        {
        //            //set image properties
        //            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
        //            f.ImageOptions.Dpi = iDPI;

        //            //Let's convert 1st page from PDF document
        //            byte[] image = f.ToImage(i);
        //            listImage.Add(image);
        //        }
        //    }
        //    catch { }

        //    return listImage;
        //}

        //public static List<byte[]> ConvertPdfToJpg(string filePath, int iDPI)
        //{
        //    List<byte[]> listImage = new List<byte[]>();
        //    try
        //    {
        //        SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
        //        f.OpenPdf(filePath);

        //        for (int i = 1; i < f.PageCount + 1; i++)
        //        {
        //            //set image properties
        //            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
        //            f.ImageOptions.Dpi = iDPI;

        //            //Let's convert 1st page from PDF document
        //            byte[] image = f.ToImage(i);
        //            listImage.Add(image);
        //        }
        //    }
        //    catch { }

        //    return listImage;
        //}

        public static string Encrypt(string ToEncrypt, bool useHasing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(ToEncrypt);

            //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            string Key = Encription.keyValue;
            
            if (useHasing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(Key);
            }
            TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
            tDes.Key = keyArray;
            tDes.Mode = CipherMode.ECB;
            tDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tDes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tDes.Clear();
            
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }

        public static string Decrypt(string cypherString, bool useHasing)
        {
            byte[] keyArray;
            byte[] toDecryptArray = Convert.FromBase64String(cypherString);
            
            //byte[] toEncryptArray = Convert.FromBase64String(cypherString);
            //System.Configuration.AppSettingsReader settingReader = new AppSettingsReader();
            
            string key = Encription.keyValue;
            
            if (useHasing)
            {
                MD5CryptoServiceProvider hashmd = new MD5CryptoServiceProvider();
                keyArray = hashmd.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }
            
            TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
            tDes.Key = keyArray;
            tDes.Mode = CipherMode.ECB;
            tDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tDes.CreateDecryptor();
            
            try
            {
                byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
                tDes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}