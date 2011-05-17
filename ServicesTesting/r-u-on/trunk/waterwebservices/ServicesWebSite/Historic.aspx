<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historic.aspx.cs" Inherits="ServicesWebSite.Historic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Xml ID="Xml1" runat="server" 
    TransformSource="~/xsltRss.xsl" EnableViewState="False"></asp:Xml>
</asp:Content>
