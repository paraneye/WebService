<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Version.aspx.cs" Inherits="Element.Sigma.Web.Service.Common.Version" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Build Version</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Calibri">
            <%  
               System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("Element.Sigma.Web.Service");
               string version = assembly.GetName().Version.ToString();
               Response.Write("Sigma(Web) Version : " + version);
               Response.Write("<br/>");
               

               Response.Write("Build Date : " + new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).CreationTime.ToString());

            %>
        </div>
    </form>
</body>
</html>
