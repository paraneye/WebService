using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.IO;
using Element.Shared.Common;
using Element.Sigma.Web.Biz.ProjectData;
using System.ServiceModel.Web;

using System.ServiceModel.Activation;
using System.Web.Script.Serialization;



namespace Element.Sigma.Web.Service.ProjectData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SigmaImportDrawing" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SigmaImportDrawing.svc or SigmaImportDrawing.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class SigmaImportDrawing : ISigmaImportDrawing
    {
        [WebInvoke(Method = "POST", UriTemplate = "UploadFile?fileName={fileName}")]
   
        public void DoWork()
        {
        }

        
        //public SigmaResultType FileUpload(string fileName, Stream fileStream)
        //{
        //    SigmaResultType result = new SigmaResultType();
        public string UploadFile(string fileName, Stream fileStream)
        {
            FileStream fileToupload = new FileStream("D:\\FileUpload\\" + fileName, FileMode.Create);

            byte[] bytearray = new byte[10000];
            int bytesRead, totalBytesRead = 0;
            do
            {
                bytesRead = fileStream.Read(bytearray, 0, bytearray.Length);
                totalBytesRead += bytesRead;
            } while (bytesRead > 0);

            fileToupload.Write(bytearray, 0, bytearray.Length);
            fileToupload.Close();
            fileToupload.Dispose();

            //return result;
            return "Upload OK";
        }      

        //public SigmaResultType FileUpload(string fileName, Stream fileStream)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        // FileSave
        //        //string sourcePath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"];
        //        //string sourcePath = string.Format("{0}\\FileUpload\\{1}"
        //        //                        , sourcePath, fileName);

        //        // TargetPath [company]/[project id]/[document type]/[document name(id)]/[document revision]
        //        // Revision 관리 할 것..

        //        string sourcePath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentFolderRoot"];
        //        sourcePath = sourcePath + "Company\\" + "Project\\" + "Drawing\\";


        //        if (!System.IO.Directory.Exists(sourcePath))
        //        {
        //            System.IO.Directory.CreateDirectory(sourcePath);
        //        }

        //        string sourceFileName = sourcePath + fileName;

        //        //FileStream fileToupload = new FileStream("D:\\FileUpload\\" + fileName, FileMode.Create);
        //        FileStream fileToupload = new FileStream(sourceFileName, FileMode.Create);


        //        byte[] bytearray = new byte[100000];
        //        int bytesRead, totalBytesRead = 0;
        //        do
        //        {
        //            bytesRead = fileStream.Read(bytearray, 0, bytearray.Length);
        //            totalBytesRead += bytesRead;
        //        } while (bytesRead > 0);

        //        fileToupload.Write(bytearray, 0, bytearray.Length);
        //        fileToupload.Close();
        //        fileToupload.Dispose();


        //        // FileUpload
        //        ImportDrawing importDrawing = new ImportDrawing();
        //        result = importDrawing.AddDrawing(sourceFileName);

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log Exception
        //        ExceptionHelper.logException(ex);
        //        result.IsSuccessful = false;
        //        result.ErrorMessage = ex.Message;
        //        return result;
        //    }
        //}

        //public SigmaResultType FileUpload(string fileName, Stream fileStream)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        // FileUpload
        //        ImportDrawing importDrawing = new ImportDrawing();
        //        result = importDrawing.AddDrawing(fileName);

                
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log Exception
        //        ExceptionHelper.logException(ex);
        //        result.IsSuccessful = false;
        //        result.ErrorMessage = ex.Message;
        //        return result;
        //    }

        //    return result;
        //}
    }
}
