using Element.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.IO;
using Element.Sigma.Web.Biz.TrueTask;
using Element.Reveal.DataLibrary;

namespace Element.Sigma.Web.Service.Prev
{
    /// <summary>
    /// MobileFileHandler의 요약 설명입니다.
    /// </summary>
    public class MobileFileHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string sourceFilePath = string.Empty;
            string detailFilePath = string.Empty;

            System.Web.Configuration.HttpRuntimeSection m_RuntimeSection = new HttpRuntimeSection();
            //* The maximum request size in kilobytes. The default size is 4096 KB (4 MB)

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

                string mobileLoginId = context.Request.Form["MobileLoginId"];
                string mobileUdId = context.Request.Form["MobileUdId"];
                string relationTable = context.Request.Form["RelationTable"];
                string fileName = context.Request.Form["FileName"];
                string filePath = context.Request.Form["FilePath"];

                string rootPath = "/SigmaStorage/";

                //각 FileType에 따른 저장경로를 가져옴
                //rootPath = GetRootPath(fileType);
                //childPath = GetChildPath(fileType);

                string saveFullPath = rootPath + filePath;

                foreach (string key in files)
                {
                    HttpPostedFile file = files[key];

                    string connStr = ConnStrHelper.getDbConnString();

                    if (!System.IO.Directory.Exists(saveFullPath))
                    {
                        System.IO.Directory.CreateDirectory(saveFullPath);
                    }

                    string filename = System.IO.Path.GetFileName(file.FileName);

                    sourceFilePath = System.IO.Path.Combine(saveFullPath, filename);

                    string fileExtention = Path.GetExtension(sourceFilePath);

                    file.SaveAs(sourceFilePath);
                    file.InputStream.Dispose();

                    detailFilePath = saveFullPath + filename;

                    UploadFileHistoryInfoDTO uploadFileHistoryInfoDTO = new UploadFileHistoryInfoDTO();
                    DataSync dataSync = new DataSync();
                    uploadFileHistoryInfoDTO.FileName = fileName;
                    uploadFileHistoryInfoDTO.FilePath = filePath;
                    uploadFileHistoryInfoDTO.RelationTable = relationTable;
                    uploadFileHistoryInfoDTO.MobileLoginId = mobileLoginId;
                    uploadFileHistoryInfoDTO.MobileUdId = mobileUdId;

                    dataSync.AddUploadFileHistoryInfo(uploadFileHistoryInfoDTO);
                }
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write("Success");
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