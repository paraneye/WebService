using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ServiceModel;
using System.IO;
using System.Collections;
using Element.Shared.Common;
using Element.Sigma.Web.Biz.ProjectData;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;

using System.Web.Configuration;

namespace Element.Sigma.Web.Service.Common
{
    public class FileHandler : IHttpHandler
    {

        // Upload File
        public void ProcessRequest(HttpContext context)
        {
            string sourceFilePath = string.Empty;
            string detailFilePath = string.Empty;

            System.Web.Configuration.HttpRuntimeSection m_RuntimeSection = new HttpRuntimeSection();
            //* The maximum request size in kilobytes. The default size is 4096 KB (4 MB)
            //context.Response.Write(m_RuntimeSection.MaxRequestLength.ToString() + "<br>");

            //if (context.Request.Params["maxFileSize"] != null)
            //    int.TryParse(context.Request.Params["maxFileSize"], out maxFileSize);

            int maxFileSize = 4;

            if (context.Request.ContentLength > maxFileSize * 1024 * 1024) // maxFileSize 4 MB - System.Web.Configuration
            {
                context.Response.Write("_Maximum request length exceeded!");
                return;
            }

            if (context.Request.Files.Count > 0)
            {
                SigmaResultType result = new SigmaResultType();

                HttpFileCollection files = context.Request.Files;

                //HttpPostedFile file = context.Request.Files["file"];
                string fileType = context.Request.Form["name"];
                //fileType 종류 "ImportList" --> saveFullPath 전송, "DrawingImage" --> childPath  Directory 전송, "HRImage" --> saveFullPath 전송

                string rootPath = string.Empty;
                string childPath = string.Empty;

                //각 FileType에 따른 저장경로를 가져옴
                rootPath = GetRootPath(fileType);
                childPath = GetChildPath(fileType);
                
                string saveFullPath = rootPath + childPath;
                              

                foreach (string key in files)
                {
                    HttpPostedFile file = files[key];

                    //FileStream fileToupload = new FileStream(saveFullPath + file.FileName, FileMode.Create);
                    
                    //byte[] bytearray = new byte[10000];
                    //int bytesRead, totalBytesRead = 0;
                    //do
                    //{
                    //    bytesRead = file.InputStream.Read(bytearray, 0, bytearray.Length);
                    //    totalBytesRead += bytesRead;
                    //} while (bytesRead > 0);

                    //fileToupload.Write(bytearray, 0, bytearray.Length);
                    //fileToupload.Close();
                    //fileToupload.Dispose();

                    
                    string connStr = ConnStrHelper.getDbConnString();

                    if (!System.IO.Directory.Exists(saveFullPath))
                    {
                        System.IO.Directory.CreateDirectory(saveFullPath);
                    }

                    //--------------- IE - The given path's format is not supported.  error 해결 -------------------------
                    // IE : 선택 File.확장자의 전체 경로가 넘어오는 경우
                    // Crome : 선택 File.확장자만 넘어오는 경우
                    //         File Name.확장자 만 필요함
                    string filename = System.IO.Path.GetFileName(file.FileName);

                    sourceFilePath = System.IO.Path.Combine(saveFullPath, filename);
                    //-----------------------------------------------------------------------------------------------------

                    //sourceFilePath = saveFullPath + file.FileName;
                    
                    string fileExtention = Path.GetExtension(sourceFilePath);


                    // File .pdf 만 등록 가능하도록 변경.
                    if (fileType == "DrawingImage")
                    {
                        if (fileExtention == ".pdf" || fileExtention == ".PDF")
                        {

                        }
                        else
                        {
                            // _ 붙으면 Client 화면에서  _다음 Text 를 Error Message로 인식하기로 한다.
                            context.Response.ContentType = "text/plain";
                            context.Response.Write("_Upload Only [PDF] File!");
                            return;
                        }
                    }
                                                            
                    file.SaveAs(sourceFilePath);
                    file.InputStream.Dispose();
                    
                    detailFilePath = childPath + filename;
                }
                // Upload 결과에 대해 Return - Upload File Path: 
                context.Response.ContentType = "text/plain";
                //context.Response.Write("File(s) uploaded successfully!");
                                
                switch (fileType)
                {
                    case "DrawingImage":
                        //"DrawingImage" --> childPath  Directory 전송,
                        context.Response.Write(detailFilePath);
                        break;
                    default:
                        //"ImportList" --> saveFullPath 전송, "HRImage - Photo, Logo" --> saveFullPath 전송
                        context.Response.Write(detailFilePath);
                        break;
                }
            }

        }

        private string GetRootPath(string fileType)
        {
            string rootPath = string.Empty;
            string iisvirtualpath = HttpContext.Current.Server.MapPath("/SigmaStorage");

            switch (fileType)
            {
                case "Photo":
                    rootPath = System.Web.Configuration.WebConfigurationManager.AppSettings["UploadedImage"];
                    break;
                case "HrPhoto":
                    rootPath = System.Web.Configuration.WebConfigurationManager.AppSettings["UploadedImage"];
                    break;
                case "Document":
                case "Form":
                    rootPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentFolderRoot"];
                    break;
                case "DrawingImage":
                    rootPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"];
                    break;
                default:
                    rootPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"];
                    break;
            }

            rootPath = iisvirtualpath + "\\" + rootPath + "\\";
            return rootPath;
        }
        
        private string GetChildPath(string fileType)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            string childPath = string.Empty;

            switch (fileType)
            {
                case "Photo":
                    childPath = userinfo.CompanyName + "\\" + "Photo\\";
                    break;
                case "HrPhoto":
                    childPath = userinfo.CompanyName + "\\" + userinfo.CurrentProjectId + "\\" + "Photo\\";
                    break;
                case "Document":
                    childPath = userinfo.CompanyName + "\\" + userinfo.CurrentProjectId + "\\" + "Document\\";
                    break;
                case "Form":
                    childPath = userinfo.CompanyName + "\\" + userinfo.CurrentProjectId + "\\" + "Form\\";
                    break;
                case "DrawingImage":
                    childPath = userinfo.CompanyName + "\\" + userinfo.CurrentProjectId + "\\" + "ImportFiles\\" + "DrawingImage\\";
                    break;
                default:
                    childPath = userinfo.CompanyName + "\\" + userinfo.CurrentProjectId + "\\" + "ImportFiles\\";
                    break;
            }

            return childPath;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


    

    }
}