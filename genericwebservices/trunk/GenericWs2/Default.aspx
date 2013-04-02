<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GenericWebservice.Apis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Container">
        <div id="Content">
        There are serveral API available to access the data. The CUAHSI hydrodesktop 
        accesses the services using SOAP API called WaterOneFlow. This returns WaterML 
        1.x documents. A REST endpoint that matches the .Net webservice over httpGet has 
        been added to this version of te services.&nbsp;
    <ul>
    <li>WaterOneFlow SOAP</li>
    <ul><li>Version 1.0</li>
    <li>Version 1.1</li></ul>
    <li>WaterOneFlow REST</li>
    <ul><li>Version 1.0</li>
    <li>Version 1.1</li></ul></ul>

    <div> In the future that access will be done using OpenGeospatial Consortium Standards, and the SOS specifically. The WaterML 2 REST endpoint transforms WaterML 1.1 into WaterML 2. And SOS endpoint is in development.</div>
    <ul>
    <li>WaterML 2</li>
    <ul><li>REST</li>
    <li>version 1.1</li></ul>
    <li>SOS</li>
    <ul><li>IN Development
    </ul></ul>
        </div>
    </div>
</asp:Content>