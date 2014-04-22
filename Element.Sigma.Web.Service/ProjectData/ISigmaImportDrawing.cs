using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.ServiceModel.Web;
using System.IO;
using Element.Shared.Common;


namespace Element.Sigma.Web.Service.ProjectData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISigmaImportDrawing" in both code and config file together.
    [ServiceContract]
    public interface ISigmaImportDrawing
    {
        ////[OperationContract]
        ////void DoWork();

        ////[OperationContract]
        ////[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        ////List<ResultDTO> NewImportDrawing(string dbInstance, string filePath, int projectId, int moduleId, string workSheet);

        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "UploadFile/{fileName}")]
        ////SigmaResultType UploadFile(string fileName, Stream fileStream);
        //string UploadFile(string fileName, Stream fileContents);
        ////[WebInvoke(Method = "POST", UriTemplate = "FileUpload/{fileType}?path={filePath}")]
        ////SigmaResultType FileUpload(string fileType, string filePath);


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "UploadFile/{fileName}")]
        string UploadFile(string fileName, Stream fileStream);

    }
}
