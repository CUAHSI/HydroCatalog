<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Title="CUAHSI HIS | Master Controlled Vocabulary Registry | Administrator" MasterPageFile="~/SiteMaster.master" Inherits="manage_admin_Default" %>
<%@ Register TagPrefix="Logger" TagName="status" Src="~/status.ascx" %>

<asp:Content ID="Content1"  runat="server" ContentPlaceHolderID="MainContent">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    
   <Logger:status id="Status" runat="server" />

   <div style= "font-size:12px;min-height:460px;">
   
       <h2>Master Controlled Vocabulary Administration.</h2>
       
       <h3>User Management Section</h3>
       
       <div>
           
           <h4>Manage Users in role: Moderator</h4>
           
           <br />
           
           <asp:GridView ID="Managers" runat="server" AutoGenerateColumns="False" 
                CellPadding="12" CellSpacing="7" ForeColor="#333333" GridLines="None" 
                HorizontalAlign="Left" Width="700px"
                style="margin-left:50px;" DataSourceID="AdminAccessDataSource" DataKeyNames="UserName" 
                                         onrowdatabound="Managers_RowDataBound">
               <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
               <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                           <asp:LinkButton ID="SelectUserButton" runat="server" CausesValidation="False" 
                               CommandName="Select" Text="Manage"></asp:LinkButton>                   
                           </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                              <asp:LinkButton ID="LinkButtonJava2" runat="server" CausesValidation="false" 
                                CommandName="Delete" Text="Delete" onclientclick="return confirm('Are you sure you want to delete this user?')" ></asp:LinkButton>
                        </ItemTemplate>
                   </asp:TemplateField>
                  <asp:BoundField DataField="UserName" HeaderText="user name" ReadOnly="True" 
                       SortExpression="UserName" />
                   <asp:BoundField DataField="Email" HeaderText="email" SortExpression="Email" />
                   <asp:BoundField DataField="CreationDate" HeaderText="user added" 
                       ReadOnly="True" SortExpression="CreationDate" />
                   <asp:BoundField DataField="LastActivityDate" HeaderText="last Activity" 
                       SortExpression="LastActivityDate" />
                   <asp:CheckBoxField DataField="IsOnline" HeaderText="is Online?" ReadOnly="True" 
                       SortExpression="IsOnline" />  
               </Columns>
               <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
               <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
               <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
               <EditRowStyle BackColor="#999999" />
               <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
           </asp:GridView>       
         
           <asp:ObjectDataSource ID="AdminAccessDataSource" runat="server" 
                SelectMethod="GetManagers" TypeName="AdminAccess" DeleteMethod="DeleteUser">
               <DeleteParameters>
                   <asp:Parameter Name="UserName" Type="String" />
               </DeleteParameters>
           </asp:ObjectDataSource>
           
       </div>
       <div style="clear:both;" />
       <div>
            <h4>Manage Users in role: User</h4>
         
            <br />
                   
            <asp:GridView ID="Users" runat="server" AutoGenerateColumns="False" 
                CellPadding="12" CellSpacing="7" ForeColor="#333333" GridLines="None" 
                HorizontalAlign="Left" 
                style="margin-left:50px; text-align:center;" 
                DataSourceID="AdminAccessDataSource2" Width="699px" DataKeyNames="UserName" 
                                             onrowdatabound="Users_RowDataBound">
               <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
               <Columns>
               <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                           <asp:LinkButton ID="SelectUserButton2" runat="server" CausesValidation="False" 
                               CommandName="Select" Text="Manage"></asp:LinkButton>                   
                           </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                              <asp:LinkButton ID="LinkButtonJava3" runat="server" CausesValidation="false" 
                                CommandName="Delete" Text="Delete" onclientclick="return confirm('Are you sure you want to delete this user?')" ></asp:LinkButton>
                        </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="UserName" HeaderText="user name" ReadOnly="True" 
                       SortExpression="UserName" />
                   <asp:BoundField DataField="Email" HeaderText="email" SortExpression="Email" />
                   <asp:BoundField DataField="CreationDate" HeaderText="user added" 
                       ReadOnly="True" SortExpression="CreationDate" />
                   <asp:BoundField DataField="LastActivityDate" HeaderText="last Activity" 
                       SortExpression="LastActivityDate" />
                   <asp:CheckBoxField DataField="IsOnline" HeaderText="is Online?" ReadOnly="True" 
                       SortExpression="IsOnline" />  
               </Columns>
               <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
               <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
               <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
               <EditRowStyle BackColor="#999999" />
               <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
           </asp:GridView>     
       
           <asp:ObjectDataSource ID="AdminAccessDataSource2" runat="server" 
                SelectMethod="GetUsers" TypeName="AdminAccess" DeleteMethod="DeleteUser">
               <DeleteParameters>
                   <asp:Parameter Name="UserName" Type="String" />
               </DeleteParameters>
            </asp:ObjectDataSource>
        </div>
        <div style="clear:both;" />
       
        <div>
            <br /><br />
            <h3>Controlled Vocabulary Management Section</h3>
            
            <h4><asp:LinkButton ID="cv10Button" runat="server" OnClientClick="window.open('manageCV10.aspx',null,'height=500, width=750,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no ');">ODM 1.0</asp:LinkButton></h4>
           
            <h4><asp:LinkButton ID="cv11Button" runat="server" OnClientClick="window.open('manageCV11.aspx',null,'height=500, width=750,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no ');">ODM 1.1</asp:LinkButton></h4>                                                                                                           
       </div>   
       
       <br /><br />
               
       <asp:HyperLink ID="Link" runat="server" NavigateUrl="~/manage/default.aspx" >Back to Moderator Section</asp:HyperLink>
       
    </div>    
	  
</asp:Content>
