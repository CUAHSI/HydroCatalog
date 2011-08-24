<%@ Page Title="" EnableViewState="false"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicServicesStatus.aspx.cs" Inherits="ServicesWebSite.PublicServicesStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    
    ConnectionString="<%$ ConnectionStrings:hiscentral_loggingReader %>" SelectCommand="SELECT     Working, Severity, TimeUpdated, ServiceName, MethodName, ErrorString, Endpoint
FROM         hiscentral_logging.dbo.LastServiceRecords
ORDER BY Working"></asp:SqlDataSource>
<p>
    Alert:
    <ul>
    <li>Clear - Service Working as of last test
    </li>
       <li>Critical- Service Failed test. May not be working.    </li>
       <li>Major - Issues. Service Failed test. May not be working.
    </li>
      <li>Minor - Issues. Usuaily, indicating that monitoring disable to prevent the sending of alerts
      <ul><li>
      disabled - URL disabled</li></ul>
    </li>
    </ul></p>
    <p>
</p>
<asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
    AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" 
    ForeColor="#333333" GridLines="None" 
    onrowdatabound="servicesGridView_RowDataBound" Width="929px">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:CheckBoxField DataField="Working" HeaderText="Working" 
            SortExpression="Working" />
        <asp:BoundField DataField="Severity" HeaderText="Severity" 
            SortExpression="Severity" />
        <asp:BoundField DataField="TimeUpdated" HeaderText="TimeUpdated" 
            SortExpression="TimeUpdated" />
        <asp:BoundField DataField="ServiceName" HeaderText="ServiceName" 
            SortExpression="ServiceName" />
        <asp:BoundField DataField="MethodName" HeaderText="MethodName" 
            SortExpression="MethodName" />
        <asp:BoundField DataField="ErrorString" HeaderText="ErrorString" 
            SortExpression="ErrorString" />
        <asp:BoundField DataField="Endpoint" HeaderText="Endpoint" 
            SortExpression="Endpoint" />
    </Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
</asp:Content>
