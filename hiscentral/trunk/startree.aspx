<%@ Page Language="C#" AutoEventWireup="true" CodeFile="startree.aspx.cs" Inherits="_Default"
    Debug="true" EnableEventValidation="true" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
  Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CUAHSI HIS Central Data Annotation Tool</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body onload="GetApplet()">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            <Services>
                <asp:ServiceReference Path="TaggerService.asmx" InlineScript="False" />
            </Services>
        </asp:ScriptManager>
          <uc1:HeaderControl ID="HeaderControl1" runat="server" />
        <div>
            <table border="0" cellspacing="0" cellpadding="0" height="100%" style="top: 199px;
                position: absolute; left: 0px; width: 100%;">
                <tr>
                    <td colspan="3" style="height: 61px">
                        <div id="appletSection">

                       <applet name="TreeApplet" code="STApplet.class" codebase="applets" archive="StarTree30c.jar" WIDTH="100%" HEIGHT="100%" MAYSCRIPT>'+
                        <param="cache_option" VALUE="No">
                        <param name="dataset" value="ontology_mar1.stc">
                        <param name="data_streaming" value="false">
                        <param name="invoke_double_click" value="FALSE">
                        <param name="Search_button" value="true">
                        <param name="Help_button" value="false">
                        <param name="Home_button" value="false">
                        <param name="Show_PlusMinus" value="true">
                        <param name="Display_panel" value="BOTTOM">
                        </applet>
                        </div>
                    </td>
                </tr>

             
            </table>
        </div>
                <asp:HiddenField ID="uem" runat="server" />
    </form>


    <script src="startree.js" type="text/javascript"></script>


</body>
</html>
