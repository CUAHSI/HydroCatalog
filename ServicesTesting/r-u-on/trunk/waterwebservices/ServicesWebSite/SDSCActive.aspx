<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SDSCActive.aspx.cs" Inherits="ServicesWebSite.SDSCActive" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>This lists all the Services hosted by SDSC, and the services that they are  dependent, upon.</p>
    <asp:Xml ID="Xml1" runat="server" 
   
    TransformSource="~/xsltRss.xsl"></asp:Xml>
</asp:Content>
