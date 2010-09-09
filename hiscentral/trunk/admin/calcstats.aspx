<%@ Page Language="C#" AutoEventWireup="true" CodeFile="calcstats.aspx.cs" Inherits="admin_calcstats" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
        UpdateCommand="UPDATE HISNetworks SET LatestRec = @latestRec, EarliestRec = @EarliestRec, SiteCount = @SiteCount, VariableCount = @VariableCount, ValueCount = @ValueCount, Ymax = @Ymax, Ymin = @Ymin, Xmax = @Xmax, Xmin = @Xmin WHERE (NetworkID = @NetworkID)" 
        SelectCommand="SELECT * FROM [HISNetworks]"   >
        <UpdateParameters>
          <asp:Parameter Name="latestRec" />
          <asp:Parameter Name="EarliestRec" />
          <asp:Parameter Name="SiteCount" />
          <asp:Parameter Name="VariableCount" />
          <asp:Parameter Name="ValueCount" />
          <asp:Parameter Name="Ymax" />
          <asp:Parameter Name="Ymin" />
          <asp:Parameter Name="Xmax" />
          <asp:Parameter Name="Xmin" />
          <asp:Parameter Name="NetworkID" />
        </UpdateParameters>
      </asp:SqlDataSource>
    <div>


          <uc1:HeaderControl ID="HeaderControl1" runat="server" />
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="z-index: 100;
        left: 137px; position: absolute; top: 180px" Text="go" Width="91px" />
    </div>
    </form>
</body>
</html>
