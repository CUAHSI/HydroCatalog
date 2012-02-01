<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMaster.master" Title="CUAHSI Hydrologic Information System - Master Controlled Vocabulary Registry | Page Error" CodeFile="error.aspx.cs" Inherits="error" %>
<%@ Register TagPrefix="Logger" TagName="status" Src="~/status.ascx" %>

<asp:Content ID="Content1"  runat="server" ContentPlaceHolderID="MainContent">
    
    <div style="min-height:460px;">
    
        <Logger:status id="Status" runat="server" />
        <h2>Error: Page not found</h2>
        <p>We apologize for the inconvenience, but the page you attempted to access does not 
            exist in our system.
            <br />
            The page could have been moved or it could have mistyped.    
        </p>
        <br />
        <p><a href="http://his.cuahsi.org/mastercvreg.html" target="_blank">Back to main page</a></p>
     
     </div>
</asp:Content>
