using Element.Reveal.DataLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Element.Sigma.Web.Biz.TrueTask
{
    class DTOHelper
    {
        public static void DataRederToList<T>(IDataReader reader, IList<T> list, Type type)
        {
            while (reader.Read())
            {
                T item = (T)Activator.CreateInstance(type);

                // Get all the properties of the type
                PropertyInfo[] properties = ((Type)item.GetType()).GetProperties();

                for (int j = 0; j < reader.FieldCount; j++)
                {
                    if (reader.GetName(j) == properties[j].Name)
                    {
                        properties[j].SetValue(item, reader[j], null);
                    }
                }
                list.Add(item);
            }
        }

        public static T DataTableToSingleDTO<T>(DataSet ds) where T : new()
        {
            T retDTO = new T();
            List<T> Temp = DataTableToListDTO<T>(ds);
            if (Temp != null)
                retDTO = Temp[0];
            
            return retDTO;
        }

        public static T DataTableToSingleDTO<T>(DataSet ds, int idx) where T : new()
        {
            T retDTO = new T();
            List<T> Temp = DataTableToListDTO<T>(ds, idx);
            if (Temp != null)
                retDTO = Temp[0];

            return retDTO;
        }

        public static List<T> DataTableToListDTO<T>(DataSet ds) where T : new()
        {
            List<T> Temp = new List<T>();
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            
            DataTable datatable = ds.Tables[0];

            List<string> columnsNames = new List<string>();
            foreach (DataColumn DataColumn in datatable.Columns)
                columnsNames.Add(DataColumn.ColumnName);
            Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getListObject<T>(row, columnsNames));
            return Temp;
        }

        public static List<T> DataTableToListDTO<T>(DataSet ds, int idx) where T : new()
        {
            List<T> Temp = new List<T>();
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[idx].Rows.Count == 0)
                return null;

            DataTable datatable = ds.Tables[idx];

            List<string> columnsNames = new List<string>();
            foreach (DataColumn DataColumn in datatable.Columns)
                columnsNames.Add(DataColumn.ColumnName);
            Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getListObject<T>(row, columnsNames));
            return Temp;
        }

        public static List<T> DataTableToList<T>(DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getListObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }

        public static T getListObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            string columnname = "";
            string value = "";
            PropertyInfo[] Properties;
            T obj = new T();
            try
            {
                columnname = "";
                value = "";
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch(Exception ex)
            {
                string strEx = ex.Message + ";" + obj.ToString() + ";" +  columnname + ";" + value;
                throw new Exception(strEx);
                //return obj;
            }
        }

        #region "Element.Reveal.Server.DALC.DTOSerializerHelper"

        public static DataSet SerializeDTOList<T>(Type type, List<T> t) where T : new()
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(type);
                MemoryStream stream = new MemoryStream();
                xmlSer.Serialize(stream, t);
                DataSet ds = new DataSet();
                stream.Position = 0;
                ds.ReadXml(stream);
                DoUpdateRowStatus(ds);
                return ds;

            }
            catch (Exception ex)
            {
                // Propogate the exception.
                throw ex;
            }
        }

        public static object DeserializeDTOList(Type type, DataSet ds)
        {

            try
            {
                DoResetRowStatus(ds);

                System.IO.StringReader read = new StringReader(ds.GetXml());
                XmlSerializer xmlSer = new XmlSerializer(type);
                System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
                settings.ConformanceLevel = System.Xml.ConformanceLevel.Auto;

                System.Xml.XmlReader reader = System.Xml.XmlReader.Create(read, settings);

                return (object)xmlSer.Deserialize(reader);

            }
            catch (Exception ex)
            {
                // Propogate the exception.
                throw ex;
            }
        }

        public static DataSet DoResetRowStatus(DataSet ds)
        {
            foreach (System.Data.DataRow rw in ds.Tables[0].Select("[DTOStatus] <> " + (int)RowStatusNo.None))
            {
                rw["DTOStatus"] = (int)RowStatusNo.None;
            }
            ds.Tables[0].AcceptChanges();

            return ds;
        }

        public static DataSet DoUpdateRowStatus(DataSet ds)
        {
            try
            {

                ds.Tables[0].AcceptChanges();

                foreach (System.Data.DataRow rw in ds.Tables[0].Select("DTOStatus = '" + (int)RowStatusNo.New + "'"))
                {
                    rw.SetAdded();
                }

                foreach (System.Data.DataRow rw in ds.Tables[0].Select("DTOStatus = '" + (int)RowStatusNo.Update + "'"))
                {
                    rw.SetModified();
                }

                foreach (System.Data.DataRow rw in ds.Tables[0].Select("DTOStatus = '" + (int)RowStatusNo.Delete + "'"))
                {
                    rw.Delete();
                }

                return ds;
            }
            catch (Exception ex)
            {
                // Propogate the exception.
                throw new Exception("DoUpdateRowStatus expection", ex);
            }
        }

        //public static byte[] StringToUnicodeByteArray(String pXmlString)
        //{
        //    UnicodeEncoding encoding = new UnicodeEncoding();
        //    byte[] byteArray = encoding.GetBytes(pXmlString);
        //    return byteArray;
        //}


        //public static byte[] StringToUTF8ByteArray(String pXmlString)
        //{

        //    UTF8Encoding encoding = new UTF8Encoding();

        //    byte[] byteArray = encoding.GetBytes(pXmlString);

        //    return byteArray;

        //}

        //public static object DeserializeXml<T>(DataSet ds, List<T> t) where T : DTOBase
        //{
        //    try
        //    {
        //        System.IO.StringReader read = new StringReader(ds.GetXml());
        //        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(t.GetType());
        //        System.Xml.XmlReader reader = new System.Xml.XmlTextReader(read);

        //        return serializer.Deserialize(reader);

        //    }
        //    catch (Exception ex)
        //    {
        //        // Propogate the exception.
        //        throw ex;
        //    }
        //}

        //public static DataSet SerializeDTO<T>(T t) where T : DTOBase
        //{
        //    try
        //    {
        //        DTOParser dto = DTOParserFactory.GetParser(typeof(T));

        //        XmlSerializer xmlSer = new XmlSerializer(dto.GetType());
        //        MemoryStream stream = new MemoryStream();
        //        xmlSer.Serialize(stream, dto);

        //        DataSet ds = new DataSet();
        //        stream.Position = 0;

        //        ds.ReadXml(stream);
        //        stream.Close();
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Propogate the exception.
        //        throw ex;
        //    }
        //}

        #endregion "Element.Reveal.Server.DALC.DTOSerializerHelper"

        //#region Convert DTO To Json (test용)
        //public static Task<T> TestjsonConvertDTO2Json<T>(string method, List<dynamic> dParams, string servicetype)
        //{

        //    T result;

        //    string requestUrl = TestjsonMakeUrl(method, dParams, servicetype);
        //    //MakeLog("GET - Url: " + requestUrl);

        //    //HttpClient hClient = new HttpClient();
        //    //var response = await hClient.GetAsync(requestUrl);

        //    //response.EnsureSuccessStatusCode();

        //    string content = response.Content.ReadAsStringAsync();
        //    if (true == content.Contains(method + "Result"))  // Json에서 method + result 제거
        //    {
        //        content = content.Replace("{\"" + method + "Result" + "\":", "");
        //        content = content.Remove(content.Length - 1);
        //    }

        //    // Generic type이 아니면서 []로 묶여 있으면 이를 제거
        //    if (typeof(T).IsConstructedGenericType == false &&
        //        content.Contains("},") == false &&
        //        content.Substring(0, 1) == "[")
        //    {
        //        content = content.Remove(0, 1).Remove(content.Remove(0, 1).Length - 1);
        //    }

        //    result = TestjsonDeserialize<T>(content);

        //    //return result;

        //    return result;
        //}

        ///// <summary>
        ///// GET에서 사용할 URL
        ///// </summary>
        ///// <param name="method"></param>
        ///// <param name="dParams"></param>
        ///// <param name="servicetype"></param>
        ///// <returns></returns>
        //private static string TestjsonMakeUrl(string method, List<dynamic> dParams, string servicetype)
        //{
        //    //string requestUrl = base_url + servicetype + method;
        //    string requestUrl = "" + servicetype + method;
        //    string jsonParam;

        //    if (dParams != null && dParams.Count() > 0)
        //    {
        //        foreach (dynamic param in dParams)
        //        {
        //            if (Object.ReferenceEquals(param, null) || string.IsNullOrEmpty(param.ToString()))
        //            {
        //                jsonParam = "{}";
        //            }
        //            else
        //            {
        //                jsonParam = TestSerialize(param);
        //            }

        //            if (jsonParam.Contains("{") == false && jsonParam.Contains("[") == true)  // 단순 배열의 경우 []를 {}로 교체
        //            {
        //                jsonParam = jsonParam.Replace("[", "{").Replace("]", "}");
        //            }

        //            if (jsonParam.Contains("{") == true || jsonParam.Contains("[") == true)  // Json으로 Serialize되면 그대로 사용
        //            {
        //                requestUrl = requestUrl + "/" + jsonParam;
        //            }
        //            else
        //            {
        //                if (param.GetType() == typeof(DateTime))
        //                {
        //                    requestUrl = requestUrl + "/" + param.ToString("yyyyMMddHHmmss");
        //                }
        //                else
        //                {
        //                    requestUrl = requestUrl + "/" + param;
        //                }
        //            }
        //        }
        //    }

        //    return requestUrl;
        //}

        ///// <summary>
        ///// POST, PUT에서 사용할 URL
        ///// </summary>
        ///// <param name="method"></param>
        ///// <param name="servicetype"></param>
        ///// <returns></returns>
        //private static string TestjsonMakeUrl(string method, string servicetype)
        //{
        //    return "" + servicetype + method;  // Real
        //    //return base_url + servicetype + method;  // Real
        //    //return "http://dev.elementindustrial.com/element.Reveal.Server.WCF/" + servicetype + method;  // for dev test
        //}

        ///// <summary>
        ///// object를 JSON string으로 serialize
        ///// </summary>
        ///// <param name="instance"></param>
        ///// <returns></returns>
        //public static string TestSerialize(object instance)
        //{
        //    using (MemoryStream _Stream = new MemoryStream())
        //    {
        //        var _Serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(instance.GetType());
        //        _Serializer.WriteObject(_Stream, instance);
        //        _Stream.Position = 0;
        //        using (StreamReader _Reader = new StreamReader(_Stream))
        //        {
        //            return _Reader.ReadToEnd();
        //        }
        //    }
        //}

        ///// <summary>
        ///// JSON string을 T형태로 deserialize
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="json"></param>
        ///// <returns></returns>
        //public static T TestjsonDeserialize<T>(string json)
        //{
        //    var _Bytes = Encoding.Unicode.GetBytes(json);
        //    using (MemoryStream _Stream = new MemoryStream(_Bytes))
        //    {
        //        var _Serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
        //        return (T)_Serializer.ReadObject(_Stream);
        //    }
        //}

        //private static void TestjsonMakeLog(string message)
        //{
        //    //string fileName = DateTime.Now.ToString("yyyyMMdd") + "Logfile.log";

        //    //folder = ApplicationData.Current.LocalFolder;
        //    //try
        //    //{
        //    //    StorageFile file = folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
        //    //    string log = Environment.NewLine + DateTime.Now.ToString("yyyy/MM/dd H:mm:ss") + "    " + message;
        //    //    FileIO.AppendTextAsync(file, log);
        //    //}
        //    //catch { }
        //}

        //#endregion Convert DTO To Json End
    }
}
