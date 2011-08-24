<%@ Page Title="" EnableViewState="false"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicServiceStatistics.aspx.cs" Inherits="ServicesWebSite.PublicServiceStatistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 133px;
        }
        .style2
        {
            width: 379px;
        }
        .style3
        {
            width: 133px;
            height: 46px;
        }
        .style4
        {
            width: 379px;
            height: 46px;
        }
        .style5
        {
            height: 46px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:hiscentral_loggingReader %>" 
        
    SelectCommand="SELECT * FROM [ServiceWorkingStats] ORDER BY [ServiceName]">
    </asp:SqlDataSource>
    <br />
    There are four severities of the alert.<table 
        style="border-style: solid; width: 100%;">
        <tr>
            <td class="style1" style="border-style: solid; border-collapse: inherit">
                Severity</td>
            <td class="style2" style="border-style: solid; border-collapse: inherit">
                Description</td>
            <td style="border-style: solid; border-collapse: inherit">
                Notes</td>
        </tr>
        <tr>
            <td class="style1" style="border-style: solid; border-collapse: inherit">
                <span class="Apple-style-span" 
                    style="border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; ">
                <span class="Apple-style-span" 
                    style="border-collapse: collapse; color: rgb(105, 105, 105); font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif; font-size: 13px; ">
                Clear</span></span></td>
            <td class="style2" style="border-style: solid; border-collapse: inherit">
                Service is Working.
            </td>
            <td style="border-style: solid; border-collapse: inherit">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" style="border-style: solid; border-collapse: inherit">
                <span class="Apple-style-span" 
                    style="border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; ">
                <span class="Apple-style-span" 
                    style="color: rgb(105, 105, 105); font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif; font-size: 13px; ">
                
                Minor</span></span></td>
            <td class="style2" style="border-style: solid; border-collapse: inherit">
                Service is flagged as disabled. URL_Status will show up as failed</td>
            <td style="border-style: solid; border-collapse: inherit">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" style="border-style: solid; border-collapse: inherit">
                <span class="Apple-style-span" 
                    style="border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; ">
                <span class="Apple-style-span" 
                    style="border-collapse: collapse; color: rgb(105, 105, 105); font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif; font-size: 13px; ">
                Major</span></span></td>
            <td class="style2" style="border-style: solid; border-collapse: inherit">
                Should not be seen in the monitors</td>
            <td style="border-style: solid; border-collapse: inherit">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" style="border-style: solid; border-collapse: inherit">
                <span class="Apple-style-span" 
                    style="border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; ">
                <span class="Apple-style-span" 
                    style="border-collapse: collapse; color: rgb(105, 105, 105); font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif; font-size: 13px; ">
                Critical</span></span></td>
            <td class="style2" style="border-style: solid; border-collapse: inherit">
                Service is not working</td>
            <td style="border-style: solid; border-collapse: inherit">
                Serivces are tested every hour. SDSC hosted services are tested more frequently.</td>
        </tr>
    </table>
    <br />
    There are four Methods that are called in a service:<br />
    <table style="border-style: solid; width: 100%;">
        <tr>
            <td class="style1" style="border-style: solid">
                Method</td>
            <td class="style2" style="border-style: solid">
                Description</td>
            <td style="border-style: solid">
                Notes</td>
        </tr>
        <tr>
            <td class="style1" style="border-style: solid">
                <span class="Apple-style-span" 
                    style="border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; ">
                <span class="Apple-style-span" 
                    style="border-collapse: collapse; color: rgb(105, 105, 105); font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif; font-size: 13px; ">
                URL_STATUS</span></span></td>
            <td class="style2" style="border-style: solid">
                Status. Should the URL be checked</td>
            <td style="border-style: solid">
                If service is disabled, then this is flagged as a failed test</td>
        </tr>
        <tr>
            <td class="style3" style="border-style: solid">
                <span class="Apple-style-span" 
                    style="border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; ">
                <span class="Apple-style-span" 
                    style="color: rgb(105, 105, 105); font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif; font-size: 13px; ">
                
                            WSDL
                  
                </span></span>
            </td>
            <td class="style4" style="border-style: solid">
                Check is the WSDL is available, and determine the version of the service</td>
            <td class="style5" style="border-style: solid">
                If WDSL is not available, test fails, Service will be shown as Severity: Major</td>
        </tr>
        <tr>
            <td class="style1" style="border-style: solid">
                <span class="Apple-style-span" 
                    style="border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; ">
                <span class="Apple-style-span" 
                    style="border-collapse: collapse; color: rgb(105, 105, 105); font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif; font-size: 13px; ">
                GetSites</span></span></td>
            <td class="style2" style="border-style: solid">
                Call GetSites for the service</td>
            <td style="border-style: solid">
                If GetSites fails. service is GetValues is still tested.</td>
        </tr>
        <tr>
            <td class="style1" style="border-style: solid">
                <span class="Apple-style-span" 
                    style="border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; ">
                <span class="Apple-style-span" 
                    style="border-collapse: collapse; color: rgb(105, 105, 105); font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif; font-size: 13px; ">
                GetSiteInfo_GetValues</span></span></td>
            <td class="style2" style="border-style: solid">
                Call GetSiteInfo, and GetValues for a service.
            </td>
            <td style="border-style: solid">
                IF GetValues fails, then the service is flagged with a critical severity.</td>
        </tr>
    </table>
    <br />
    <asp:Table ID="Table1" runat="server">
    </asp:Table>
    <br />
    <br />
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
