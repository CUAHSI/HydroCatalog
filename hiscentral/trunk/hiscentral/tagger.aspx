<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tagger.aspx.cs" Inherits="tagger"
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
        
       
            <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%" style="top: 0px;
                position: absolute; left: 0px;">
                <tr style="height:400px; width:800px">
                    <td colspan="3" align="center">
                        <div id="appletSection">

                       <applet name="TreeApplet" code="STApplet.class" codebase="applets" archive="StarTree30c.jar" WIDTH="100%" HEIGHT="450" MAYSCRIPT>'+
                        <param="cache_option" VALUE="No">
                        <param name="dataset" value="">
                        <param name="data_streaming" value="false">
                        <param name="invoke_double_click" value="FALSE">
                        <param name="Search_button" value="false">
                        <param name="Help_button" value="false">
                        <param name="Home_button" value="false">
                        <param name="Show_PlusMinus" value="true">
                        <param name="Display_panel" value="BOTTOM">
                        </applet>
                        </div>
                    </td>
                </tr>

                <tr bgcolor="#D6E7F7">
                <td align="center">
                <table><tr><td style="width:5px">&nbsp;</td>
                    <td bgcolor="#D6E7F7" valign="top" style="height: 190px; width: 343px;">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF"
                                    CssClass="gridview" OnRowDataBound="HandleRowDatabound" HorizontalAlign="Right"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal"
                                    AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True"
                                    AllowSorting="True" Height="95px" PageSize="5" Width="331px">
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <Columns>                                    
                                        <asp:BoundField DataField="AltVariableName" HeaderText="Variable Name" SortExpression="AltVariableName">
                                            <ItemStyle Width="180px" Wrap="False" HorizontalAlign="Left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AltVariableCode" HeaderText="Code" SortExpression="AltVariableName">
                                            <ItemStyle Width="120px" Wrap="False" HorizontalAlign="Left"/>
                                        </asp:BoundField>                                        
                                        <asp:BoundField DataField="SampleMedium" HeaderText="Medium" SortExpression="SampleMedium">
                                            <ItemStyle Width="90px" Wrap="False" HorizontalAlign="Left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataFormatString="&lt;a href=javascript:AddVarNameToList('{0}')&gt;Select&lt;/a&gt;"
                                            DataField="variableid" HtmlEncodeFormatString="False" />
                                    </Columns>
                                    <PagerSettings FirstPageImageUrl="img/first.gif" FirstPageText="First Page"
                                        LastPageImageUrl="img/last.gif" LastPageText="Last Page" NextPageImageUrl="img/next.gif"
                                        NextPageText="Next Page" PreviousPageImageUrl="img/prev.gif" PreviousPageText="Previous Page" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
        <emptydatatemplate>           
            Database contains No Unmapped Variables  
        </emptydatatemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
                            SelectCommand="SELECT AltVariableName, VariableID, SampleMedium, networkId FROM Variables WHERE (VariableID NOT IN (SELECT VariableID FROM MappingsApproved)) AND (networkId = @NetworkID)">
                          <SelectParameters>
                            <asp:SessionParameter Name="NetworkID" SessionField="NetworkID" />
                          </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td style="text-align: center; vertical-align: top; top: 0px; position: relative;width:250px">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <table style="top: 0px; position: relative;">
                                    <tr>
                                        <td height="30" align="center">
                                            <b>Variable:</b><br />
                                            <input type="text" name="textfield" onfocus="this.blur()"></td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <b>Mapping:</b><br />
                                            <input type="hidden"  name="textfield2" onfocus="this.blur()">
                                            <input type="text"  name="textfieldKeyword" onfocus="this.blur()"><br/>
                   
                                        </td>
                                    </tr>
                                                                        <tr>
                                        <td align="center">
                                            <div id="suggestpanel" style="position:relative;top:3px"><b>Search:</b><br /><input type="text" name="textfield4"><br/><input type="submit" name="SearchButton" value="Search" onclick="searchTree();return false;" id="Submitz" style="width: 60px;position:relative;top:5px;" /></div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 386px; height: 190px; text-align: right" bgcolor="#D6E7F7" valign="top"
                        align="right">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"
                                    Height="95px" AllowPaging="True" AllowSorting="True" PageSize="5" CssClass="gridview"
                                    OnRowDataBound="HandleRowsDatabound" HorizontalAlign="Right" Width="412px" BorderWidth="0px"
                                    CellPadding="1" DataKeyNames="VariableID,ConceptID">
                                    <Columns>
                                        <asp:BoundField DataField="AltVariableName" HeaderText="Variable" 
                                            SortExpression="AltVariableName">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ConceptKeyword" HeaderText="Keyword" 
                                            SortExpression="ConceptKeyword">
                                        </asp:BoundField>
                                        <asp:CommandField ShowDeleteButton="True" />
                                    </Columns>
                                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageImageUrl="img/first.gif" FirstPageText="First Page"
                                        LastPageImageUrl="img/last.gif" LastPageText="Last Page" NextPageImageUrl="img/next.gif"
                                        NextPageText="Next Page" PreviousPageImageUrl="img/prev.gif" PreviousPageText="Previous Page" />
                                                <emptydatatemplate>           
            <center>Database contains No mapped Variables</center>  
        </emptydatatemplate>
                                </asp:GridView>
                                <asp:ImageButton ID="Button1" ImageUrl="img/but-on.jpg" Style="width: 0px; height: 0px"
                                    runat="server" OnClick="LoadItemsBtn_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>" 
                            
                            SelectCommand="SELECT v.AltVariableName, m.ConceptID, m.ConceptKeyword, m.VariableID FROM MappingsApproved AS m INNER JOIN Variables AS v ON v.VariableID = m.VariableID ORDER BY m.DateMapped DESC" 
                                                        DeleteCommand="DeleteMapping" DeleteCommandType="StoredProcedure" OnDeleted="LoadItemsBtn_Click" ProviderName="<%$ ConnectionStrings:CentralHISConnectionString.ProviderName %>">
                

                            
                            <DeleteParameters>
                                <asp:ControlParameter Name="variableID" ControlID="GridView2" PropertyName="SelectedValue" />
                                <asp:ControlParameter Name="conceptID" ControlID="GridView2" PropertyName="SelectedValue" />
                            </DeleteParameters>
                            
                        </asp:SqlDataSource>
                    </td>
                    </tr></table>
                    </td>
                </tr>               
            </table>
        
                <asp:HiddenField ID="uem" runat="server" />
    </form>


    <script src="tagger.js" type="text/javascript"></script>


</body>
</html>
