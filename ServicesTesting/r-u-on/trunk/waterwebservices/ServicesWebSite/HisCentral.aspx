<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HisCentral.aspx.cs" Inherits="ServicesWebSite.HisCentral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Xml ID="Xml1" runat="server" 
    DocumentSource="https://www.r-u-on.com/ctrl?action=alarmsreport&amp;load=HisCentral&amp;reverse" 
    TransformSource="~/xsltRss.xsl"></asp:Xml>
</asp:Content>
