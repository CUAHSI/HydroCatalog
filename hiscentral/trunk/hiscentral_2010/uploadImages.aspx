<%@ Page Language="C#" AutoEventWireup="true" Inherits="uploadImages" Codebehind="uploadImages.aspx.cs" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>
<script language="javascript" type="text/javascript">
<!--



// -->
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <p>
                &nbsp;</p>
        <p>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
                DeleteCommand="DELETE FROM [HISNetworks] WHERE [NetworkID] = @NetworkID" InsertCommand="INSERT INTO [HISNetworks] ([OrgIconPath]) VALUES (@OrgIconPath)"
                SelectCommand="SELECT [NetworkID], [OrgIconPath] FROM [HISNetworks]" UpdateCommand="UPDATE [HISNetworks] SET [OrgIconPath] = @OrgIconPath WHERE [NetworkID] = @NetworkID">
                <DeleteParameters>
                    <asp:Parameter Name="NetworkID" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="OrgIconPath" Type="String" />
                    <asp:Parameter Name="NetworkID" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="OrgIconPath" Type="String" />
                </InsertParameters>
            </asp:SqlDataSource>
        </p>
    </div>
      <input id="uploadOrgFile" type="file" runat="server" style="z-index: 109; left: 129px; position: absolute; top: 201px; width: 306px;" />
      <asp:Button ID="btmOrgUpload" runat="server" Text="Upload" OnClick="uploadOrgIconButton_Click" style="z-index: 100; left: 355px; position: absolute; top: 231px" Width="79px" />
        <asp:Image ID="imgOrgIcon" runat="server" Height="150px" Style="z-index: 101; left: 461px;
            position: absolute; top: 162px" Width="150px" Visible="False" ImageUrl="getLogo.aspx" />
        <asp:Button ID="Button1" runat="server" Style="z-index: 102; left: 40px; position: absolute;
            top: 476px" Text="<< Back" OnClick="Button1_Click" Width="136px" Height="29px" />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Style="z-index: 103; left: 126px;
            position: absolute; top: 169px" Text="Organization Icon:" Width="149px"></asp:Label>
        <asp:Label ID="Label2" runat="server" Style="z-index: 104; left: 133px; position: absolute;
            top: 237px" Text="150 x 150 pixel size image"></asp:Label>
        <input id="uploadMapFile" type="file" runat="server" style="z-index: 110; left: 144px; position: absolute; top: 381px; width: 306px;" />
        <asp:Button ID="btnMapiconUpload" runat="server" Text="Upload" OnClick="uploadMapIconButton_Click" style="z-index: 105; left: 373px; position: absolute; top: 407px" Width="79px" />
        <asp:Image ID="imgMapIcon" runat="server" Height="16px" Style="z-index: 106; left: 470px;
            position: absolute; top: 384px" Width="16px" Visible="False" ImageUrl="getIcon.aspx" />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="z-index: 107; left: 138px;
            position: absolute; top: 355px" Text="Map Icon:" Width="149px"></asp:Label>
        <asp:Label ID="Label4" runat="server" Style="z-index: 111; left: 156px; position: absolute;
            top: 412px" Text="16 x 16 pixel size image"></asp:Label>
        <uc1:HeaderControl ID="HeaderControl1" runat="server" />
    </form>
</body>
</html>
