<%@ Page Language="C#" AutoEventWireup="true" CodeFile="taggeradmin.aspx.cs" Inherits="admin" EnableEventValidation="true"%>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
  Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="expires" content="0"/> 
<meta http-equiv="expires" content="now"/> 
<meta http-equiv="Pragma" content="no-cache"/> 
<meta http-equiv="Cache-Control" content="no-cache"/> 
    <title>CUAHSI Data Annotation Tool Admin Interface</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body onload="GetApplet();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            <Services>
                <asp:ServiceReference Path="TaggerService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%" style="top: 0px;
                position: absolute; left: 0px;">
                <tr>
                    <td colspan="3">
                        <div id="appletSection">

                        </div>
                    </td>
                </tr>

                <tr bgcolor="#D6E7F7">
                <td align="center">
                <table><tr><td style="width:5px"><asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <asp:ImageButton ID="Button2" ImageUrl="but-on.jpg" Style="width: 0px; height: 0px"
                                    runat="server" OnClick="CreateConcept"/>
</ContentTemplate>
</asp:UpdatePanel></td>
                
                 <td style="width: 386px; height: 190px; text-align: right" bgcolor="#D6E7F7" valign="top"
                        align="right">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"
                                    Height="95px" AllowPaging="True" AllowSorting="True" PageSize="5" CssClass="gridview"
                                    OnRowDataBound="HandleRowsDatabound" HorizontalAlign="Right" Width="612px" BorderWidth="0px"
                                    CellPadding="1" DataKeyNames="variableID,conceptID">
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True">
                                            <ItemStyle Font-Bold="True" Width="55px" HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="conceptID" HeaderText="ConceptCode" SortExpression="conceptID">
                                            <ItemStyle Width="180px" Wrap="False" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="altvariablename" HeaderText="Variable Name" SortExpression="altvariablename">
                                            <ItemStyle Width="330px" Wrap="False" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="TextualDescription" HeaderText="Suggestions" SortExpression="TextualDescription">
                                            <ItemStyle Width="310px" Wrap="False" HorizontalAlign="Left" />
                                        </asp:BoundField>
    <asp:BoundField DataFormatString="&lt;a href=javascript:AddPendingMappingToList('{0}')&gt;Select&lt;/a&gt;"
                                            DataField="variableid" HtmlEncode="False" HtmlEncodeFormatString="False" />
                                    </Columns>
                                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageImageUrl="img/first.gif" FirstPageText="First Page"
                                        LastPageImageUrl="img/last.gif" LastPageText="Last Page" NextPageImageUrl="img/next.gif"
                                        NextPageText="Next Page" PreviousPageImageUrl="img/prev.gif" PreviousPageText="Previous Page" />
                                                                                        <emptydatatemplate>           
            <center>No pending mappings</center>  
        </emptydatatemplate>
                                </asp:GridView>
                                <asp:ImageButton ID="Button1" ImageUrl="but-on.jpg" Style="width: 0px; height: 0px"
                                    runat="server" OnClick="LoadItemsBtn_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
                            SelectCommand="select altvariablename, p.conceptID, m.variableID,TextualDescription from mappingsapproved as m join variables as v on v.variableid=m.variableID join mappingspending as p on p.variableID=m.variableid order by m.datemapped desc"
                            DeleteCommand="DeleteMapping" DeleteCommandType="StoredProcedure">
                            <DeleteParameters>
                                <asp:ControlParameter Name="variableID" ControlID="GridView2" PropertyName="SelectedValue" />
                            </DeleteParameters>
                        </asp:SqlDataSource>
                    </td>
                               
                    <td style="text-align: center; vertical-align: top; top: 0px; position: relative;width:200px">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <table style="top: 0px; position: relative;">
                                                                 <tr>
                                        <td height="30px" align="center">
                                            <b>Select Variable</b><br />
                                    </tr>
                                    <tr>
                                        <td height="30" align="center">
                                            <b>Variable:</b><br />
                                            <input type="text" name="textfield" onfocus="this.blur()"></td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <b>Mapping:</b><br />
                                            <input type="text" name="textfield2" onfocus="this.blur()"><br/>
                   
                                        </td>
                                    </tr>
                                                                        <tr>
                                        <td align="center">
                                            <div id="suggestpanel" style="position:relative;top:3px"></div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                <td style="text-align: center; vertical-align: top; top: 0px; position: relative;width:200px">
                        <asp:UpdatePanel ID="UpdatePanelz" runat="server">
                            <ContentTemplate><div id="createConceptPanel" style="visibility:hidden">
                                <table style="top: 0px; position: relative;">
                                
                                    <tr>
                                        <td height="30px" align="center">
                                            <b>Create New Concept</b><br />
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <b>Concept ID:</b><br />
                                            <input type="text" name="textfield5"><br/>
                   
                                        </td>
                                    </tr>
                                                                        <tr>
                                        <td align="center">
                                            <div id="cbut" style="position:relative;top:3px"><b>Concept Label:</b><br /><input type="text" name="textfield6"><br/><input type="submit" name="createButton" value="Create" onclick="CreateNewConcept();return false;" id="Submitc" style="width: 60px;position:relative;top:5px;" /></div>
                                        </td>
                                    </tr>
                                    
                                </table></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                
 
                   
                    </tr></table>
                    </td>
                </tr>               
            </table>
        </div>
        <asp:HiddenField ID="parentID" runat="server" />
        <asp:HiddenField ID="conceptID" runat="server" />
        <asp:HiddenField ID="conceptLabel" runat="server" />
        <asp:HiddenField ID="message" runat="server" Value="New concept successfully added. Refresh page to see the updates"/>
        <asp:HiddenField ID="uem" runat="server" />
    </form>

    <script src="taggeradmin.aspx.js" type="text/javascript"></script>

</body>
</html>