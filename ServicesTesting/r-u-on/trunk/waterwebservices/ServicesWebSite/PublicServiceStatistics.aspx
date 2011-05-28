<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicServiceStatistics.aspx.cs" Inherits="ServicesWebSite.PublicServiceStatistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:hiscentral_loggingReader %>" 
        
    SelectCommand="SELECT * FROM [ServiceWorkingStats] ORDER BY [ServiceName]">
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ServiceName" HeaderText="ServiceName" 
                SortExpression="ServiceName" />
            <asp:BoundField DataField="MethodName" HeaderText="MethodName" 
                SortExpression="MethodName" />
            <asp:BoundField DataField="TotalTests" HeaderText="TotalTests" 
                SortExpression="TotalTests" />
            <asp:BoundField DataField="FailedTests" HeaderText="FailedTests" 
                SortExpression="FailedTests" />
            <asp:BoundField DataField="WorkingTests" HeaderText="WorkingTests" 
                SortExpression="WorkingTests" />
        </Columns>
    </asp:GridView>
</asp:Content>
