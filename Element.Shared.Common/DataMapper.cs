using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Xml.Linq;
using System.Reflection;


namespace Element.Shared.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class DataMapper
    {
        private Database _database_;

        public DataMapper(string dbName)
        {
            _database_ = DatabaseFactory.CreateDatabase(dbName);
        }


        public Object toList<T>(string spname, params object[] parms)
        {
            Object resultObject = new Object();
            DataSet ds = new DataSet();

            try
            {
                ds = _database_.ExecuteDataSet(spname, parms);
                resultObject = toDeserialize<T>(ds);
                ds.Dispose();
            }

            catch (Exception ex)
            {
                throw new Exception("toList Convert exception", ex);
            }

            return resultObject;
        }


        public Object insert(string spname, params object[] parms)
        {
            return _database_.ExecuteNonQuery(spname, parms); 
        }









        private Object toDeserialize<T>(DataSet ds)
        {
            ds.Tables[0].TableName = typeof(T).Name; // XML Node Name 수정, 임시 땜방
            //차후 Base Class <T>에서 XML Node Name으로 Class를 다이나믹 상속,생성 후 바인딩 시킬것

            string xml = ds.GetXml();

            XmlSerializer xmlSer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("NewDataSet"));
            XDocument doc = XDocument.Load(new StringReader(xml));
            System.Xml.XmlReader reader = doc.CreateReader();

            return (Object)xmlSer.Deserialize(reader);
        }

        public Object[] toArray<T>(T DTO)
        {
            Object[] obj = null;
            Type type = DTO.GetType();

            try
            {
                FieldInfo[] Fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                if (Fields.Length == 0) return obj;

                obj = new Object[Fields.Length];

                for (int i = 0; i < Fields.Length; i++)
                {
                    obj[i] = Fields[i].GetValue(DTO);
                }
            }

            catch (Exception ex)
            {
               throw new Exception(String.Format("RunTime Exception [DataMapper:toArray() : {0}", ex.Message));
            }

            return obj;
        }
    }
}
