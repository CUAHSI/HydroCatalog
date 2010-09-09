<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testpage11.aspx.cs" Inherits="testpage" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    
        
        <asp:Panel ID="pnl2" runat="server" Height="49px" Style="font-weight: bold; z-index: 100;
            left: 20px; color: black; text-indent: 10px; position: absolute; top: 252px;
             text-align: left" Width="640px">
        <asp:Label ID="Label6" runat="server" Style="z-index: 100; left: 56px; position: absolute;
            top: 13px" Text="Site:" Font-Size="14px"></asp:Label>
            &nbsp;
        <asp:DropDownList ID="ddlSiteIDS" runat="server" Style="z-index: 99; left: 106px;
            position: absolute; top: 13px" Width="421px">
        </asp:DropDownList>
        <asp:Button ID="btnGetSiteInfo" runat="server" OnClick="btnGetSiteInfo_Click" Style="z-index: 103;
            left: 537px; position: absolute; top: 11px" Text="Get Site info" Width="97px" Height="24px" Font-Size="14px" />
            &nbsp; &nbsp;
            &nbsp; &nbsp;<br />
            &nbsp;
        </asp:Panel>
        <asp:Panel ID="pnl1" runat="server" Height="48px" Style="font-weight: bold; z-index: 101;
            left: 20px; color: black; text-indent: 10px; position: absolute; top: 200px;
            text-align: left" Width="640px" BackColor="LightSteelBlue">
            &nbsp;
            <asp:Label ID="LabelNetworkname" runat="server" Font-Bold="False" Style="z-index: 106;
                left: 121px; position: absolute; top: 3px" Font-Size="12px"></asp:Label>
            &nbsp;<br />
            &nbsp;
            &nbsp; &nbsp;
            <asp:Button ID="btnConnect2" runat="server" OnClick="btnConnect_Click" Style="z-index: 102;
                left: 536px; position: absolute; top: 0px" Text="Get Sites" Width="100px" Font-Size="14px" />
            &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="Label8" runat="server" Style="z-index: 103; left: 8px; position: absolute;
                top: 4px" Text="NetworkName" Font-Size="14px"></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 104; left: 9px; position: absolute;
                top: 25px" Text=" NetworkWSDL" Font-Size="14px"></asp:Label>
            <asp:Label ID="LabelNetworkWSDL" runat="server" Font-Bold="False" Style="z-index: 105;
                left: 121px; position: absolute; top: 23px" Font-Size="12px"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="pnl3" runat="server" Height="149px" Style="font-weight: bold; z-index: 102;
            left: 20px; color: black; text-indent: 10px; position: absolute; top: 306px; 
            text-align: left" Width="640px">
        <asp:Panel ID="Panel1" runat="server" Height="109px" ScrollBars="Vertical" Style="z-index: 100;
            left: 18px; position: absolute; top: 32px" Width="615px">
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999"
                BorderStyle="None" BorderWidth="1px" CellPadding="3"
                GridLines="Vertical" Style="z-index: 100; left: 2px; position: absolute; top: 1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="1px" Width="594px" Font-Size="12px">
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="Gainsboro" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>

            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<br />
            &nbsp;

            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;<br />
            &nbsp;

            </asp:Panel>
        <asp:Label ID="Label7" runat="server" Style="z-index: 101; left: 132px; position: absolute;
            top: 12px" Text="Service Variable Details" Width="202px" Font-Size="14px"></asp:Label>
        <asp:DropDownList ID="ddlVariables" runat="server" Style="z-index: 102; left: 464px;
            position: absolute; top: 5px" Width="160px" Enabled="False" Visible="False" OnSelectedIndexChanged="ddlVariables_SelectedIndexChanged">
        </asp:DropDownList>
            &nbsp;
        </asp:Panel>
        <asp:Panel ID="pnl4" runat="server" Height="163px" Style="font-weight: bold; z-index: 103;
            left: 22px; color: black; text-indent: 10px; position: absolute; top: 459px;
            text-align: left" Width="639px">
            <br />
            &nbsp;
        <asp:Calendar ID="calStart" runat="server" BackColor="White" BorderColor="#999999"
            CellPadding="3" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="10px"
            ForeColor="Black" Height="69px" Style="z-index: 100; left: 7px; position: absolute;
            top: 7px" Width="150px" OnSelectionChanged="calStart_SelectionChanged">
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <TodayDayStyle BackColor="Gainsboro" ForeColor="Black" />
            <SelectorStyle BackColor="#CCCCCC" />
            <WeekendDayStyle BackColor="White" />
            <OtherMonthDayStyle ForeColor="Gray" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        </asp:Calendar>
        <asp:Calendar ID="calEnd" runat="server" BackColor="White" BorderColor="#999999"
            CellPadding="3" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="10px"
            ForeColor="Black" Height="106px" Style="z-index: 101; left: 326px; position: absolute;
            top: 9px" Width="155px" OnSelectionChanged="calEnd_SelectionChanged">
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <TodayDayStyle BackColor="Gainsboro" ForeColor="Black" />
            <SelectorStyle BackColor="#CCCCCC" />
            <WeekendDayStyle BackColor="White" />
            <OtherMonthDayStyle ForeColor="Gray" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        </asp:Calendar>
        <asp:CheckBox ID="chkStart" runat="server" Style="z-index: 102; left: 157px; position: absolute;
            top: 79px" Text="Use Start Date" Font-Size="14px" />
        <asp:CheckBox ID="chkEnd" runat="server" Style="z-index: 103; left: 487px; position: absolute;
            top: 87px" Text="Use End Date" Font-Size="14px" />
            &nbsp;
        <asp:TextBox ID="txtStart" runat="server" Style="z-index: 105; left: 160px; position: absolute;
            top: 101px" Width="104px"></asp:TextBox>
        <asp:TextBox ID="txtEnd" runat="server" Style="z-index: 106; left: 485px; position: absolute;
            top: 109px" Width="110px"></asp:TextBox>
        <asp:Button ID="btnStart" runat="server" Style="z-index: 107; left: 159px; position: absolute;
            top: 126px" Height="24px" OnClick="btnStart_Click" Width="111px" Text="Set Date" Font-Size="14px" />
        <asp:Button ID="btnEnd" runat="server" Style="z-index: 108; left: 484px; position: absolute;
            top: 131px" Height="24px" OnClick="btnEnd_Click" Width="116px" Text="Set Date" Font-Size="14px" />
            &nbsp; &nbsp;
        </asp:Panel>
        &nbsp; &nbsp;&nbsp;
        <div style="z-index: 115; left: 20px; overflow:auto; width:887px; position: absolute; top: 692px; height:100px">
        <asp:Label ID="txtResults" runat="server" Style="" Width="100%" BorderStyle="Inset" Font-Names="Courier New" Font-Size="Smaller"></asp:Label></div>
        <asp:Label ID="Label5" runat="server" Style="z-index: 104; left: 21px; position: absolute;
            top: 670px" Text="Raw XML Response:"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="14px" ForeColor="Red"
            Height="45px" Style="z-index: 105; left: 156px; position: absolute; top: 643px"
            Visible="False" Width="755px"></asp:Label>
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnGetValues" runat="server" OnClick="btnGetValues_Click" Style="z-index: 106;
            left: 681px; position: absolute; top: 358px" Text="Get Values" Width="226px" />
        <asp:Label ID="lblServiceURL" runat="server" Style="z-index: 107; left: 682px; position: absolute;
            top: 221px" Height="19px" Font-Size="12px"></asp:Label>
        <asp:Label ID="lblSiteInfo" runat="server" Style="z-index: 108; left: 682px; position: absolute;
            top: 241px" Height="19px" Font-Size="12px"></asp:Label>
        <asp:Label ID="lblGeolocation" runat="server" Style="z-index: 109; left: 682px; position: absolute;
            top: 263px" Font-Size="12px"></asp:Label>
        <asp:Label ID="lblVariable" runat="server" Style="z-index: 110; left: 682px; position: absolute;
            top: 298px" Font-Size="12px"></asp:Label>
        <asp:Label ID="lblDateRange" runat="server" Style="z-index: 111; left: 682px; position: absolute;
            top: 335px" Font-Size="12px"></asp:Label>
        <asp:Panel ID="Panel2" runat="server" Height="227px" Style="z-index: 112; left: 679px;
            position: absolute; top: 390px" Width="226px" ScrollBars="Auto">
            <asp:GridView ID="GridView2" runat="server" Style="z-index: 100; left: 0px; position: absolute;
                top: 0px; width: 100%;" CellPadding="4" ForeColor="#333333" GridLines="None" Height="83px" Width="238px" Font-Size="12px">
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="LightSteelBlue" Font-Bold="True" ForeColor="Black" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        </asp:Panel>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <uc1:HeaderControl ID="HeaderControl1" runat="server" />
        &nbsp;
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Style="z-index: 116;
            left: 22px; position: absolute; top: 160px" Text="Service Test Page:" Width="178px"></asp:Label>
        </div>
    </form>
</body>
</html>
