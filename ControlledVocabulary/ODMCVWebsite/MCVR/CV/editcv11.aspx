<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMaster.master" CodeFile="editcv11.aspx.cs" Inherits="CV_editcv11" %>
<%@ Register TagPrefix="Logger" TagName="status" Src="~/status.ascx" %>

<asp:Content ID="Content1"  runat="server" ContentPlaceHolderID="MainContent">
    <div style="min-height:460px;">
    
        <Logger:status id="Status" runat="server" />
    
        <h2>Controlled Vocabulary for ODM 1.1</h2>
        <h3><asp:Label ID="NameLabel" runat="server"></asp:Label><asp:Label ID="DescriptionLabel" runat="server"></asp:Label></h3>
        
        <br />
       
        <div id="CV10Display" runat="server" style="font-size: 14px;">        
            <asp:GridView ID="CV10Contents" runat="server" 
                    CellPadding="14" CellSpacing="10" ForeColor="#333333" GridLines="None" 
                    HorizontalAlign="Left" Width="1000px"
                    style="margin-left:50px; text-align:center;" 
                DataSourceID="cv10AccessDataSource" 
                onselectedindexchanged="CV10Contents_SelectedIndexChanged">
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                           <asp:LinkButton ID="SelectButton" runat="server" CausesValidation="False" 
                               CommandName="Select" Text="Edit"></asp:LinkButton>                   
                           </ItemTemplate>
                   </asp:TemplateField>
                    </Columns>
                   <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />             
                   <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                   <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                   <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                   <EditRowStyle BackColor="#999999" />
                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
               </asp:GridView>       
            
            <div style="clear:both;"></div><br />
               
            <asp:Button ID="AddEntryButton" runat="server" style="margin-left:50px;" Text="Add New" onclick="AddEntryButton_Click" /> 
            
            <br />                     
            <asp:ObjectDataSource ID="cv10AccessDataSource" runat="server" 
                SelectMethod="GetCVContents" TypeName="cv11Access">
                <SelectParameters>
                    <asp:QueryStringParameter Name="TableName" QueryStringField="tbl" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>        
        </div>
        
        <div style="clear:both;"></div>                  
    
        <div id="EditSelectedCV" runat="server" visible="false" style="font-size: 14px;">
        
            <h3>Change Request</h3><br />
            
            <asp:Panel ID="EditVariablePanel" runat="server">
            
            <table>
					<tr>
						<td>
							<asp:Label id="lbl1" Runat="server" Visible="False"></asp:Label></td>
						<td>
							<asp:TextBox id="txt1" Runat="server" Visible="False" Width="300"></asp:TextBox>
							<asp:RequiredFieldValidator ID="req1" ControlToValidate="txt1" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
						</td>						
					</tr>			
					<tr>
						<td>
							<asp:label id="lbl2" Runat="server" Visible="False"></asp:label></td>
						<td>
							<asp:TextBox id="txt2" Runat="server" Visible="False" Width="300"></asp:TextBox>
							<asp:RegularExpressionValidator id="reg1" Runat="server" ControlToValidate="txt2" ValidationExpression="^[-,\d]+$" Display="Dynamic"
								ErrorMessage="Values may only be numeric for this field." ForeColor="#cc0000" Enabled="False" />
							<asp:RequiredFieldValidator ID="req2" ControlToValidate="txt2" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
						</td>
					</tr>
					<tr>
						<td>
							<asp:label id="lbl3" Runat="server" Visible="False"></asp:label></td>
						<td>
							<asp:TextBox id="txt3" Runat="server" Visible="False" Width="300"></asp:TextBox>
							<asp:RequiredFieldValidator ID="req3" ControlToValidate="txt3" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label id="lbl4" Runat="server" Visible="False"></asp:Label></td>
						<td>
							<asp:TextBox id="txt4" Runat="server" Visible="False" Width="300"></asp:TextBox>
							<asp:RequiredFieldValidator ID="req4" ControlToValidate="txt4" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
							<asp:DropDownList id="ddl1" Runat="server" Visible="False">
								<asp:ListItem Value="True"></asp:ListItem>
								<asp:ListItem Value="False"></asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label id="lbl5" Runat="server" Visible="False"></asp:Label></td>
						<td>
							<asp:TextBox id="txt5" Runat="server" Visible="False" Width="300"></asp:TextBox>
						</td>
					</tr>
					<tr><td>&nbsp;</td></tr>
					<tr>
						<td colspan="2">
							<asp:CheckBox id="CheckDelete" Runat="server" Text="Delete this entry" onclick="DeleteWarning(this)"></asp:CheckBox>
						</td>
					</tr>					
				</table>	
			    
			    <br /><br />
			    
			    <table>
			        <tr>
			            <td>Reason<br />for request</td>
					    <td>
						    <asp:TextBox id="txtReason" Runat="server" Width="300" TextMode="MultiLine" Rows="3"></asp:TextBox>
						    <asp:RequiredFieldValidator ID="reqReason" ControlToValidate="txtReason" Runat="server" 
							    ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
				        </td>
				    </tr>
				    <tr><td>&nbsp;</td></tr>
				    <tr>
					    <td colspan="2">We may need to contact you to discuss this request</td>
				    </tr>
				    <tr><td>&nbsp;</td></tr>
				    <tr>
					    <td>Your name</td>
					    <td>
						    <asp:TextBox id="txtName" Runat="server" Width="300"></asp:TextBox>
						    <asp:RequiredFieldValidator ID="reqName" ControlToValidate="txtName" Runat="server"  
							    ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
					    </td>
				    </tr>
				    <tr>
					    <td>Email Address</td>
					    <td>
						    <asp:TextBox id="txtEmail" Runat="server" Width="300"></asp:TextBox>
						    <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" Runat="server" 
							    ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
						    <asp:RegularExpressionValidator id="regEmail" Runat="server" ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
							    Display="Dynamic" ErrorMessage="Invalid email address" ForeColor="#cc0000"></asp:RegularExpressionValidator></td>
				    </tr>
				    <tr><td>&nbsp;</td></tr>
				    <tr>
						<td>&nbsp;</td>
						<td align="right">
							<asp:Button id="SubmitButton" Runat="server" Text="Submit Changes" 
                                onclick="SubmitButton_Click"></asp:Button>
                            &nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="CancelButton" Runat="server" Text="Cancel" 
                                CausesValidation="False" onclick="CancelButton_Click"></asp:Button></td>
					</tr>					
			    </table> 
			    
			    <asp:Label id="lblEdit1" Runat="server" Visible="False"></asp:Label>
				<asp:Label id="lblEdit2" Runat="server" Visible="False"></asp:Label>
				<asp:Label id="lblEdit3" Runat="server" Visible="False"></asp:Label>
				<asp:Label id="lblEdit4" Runat="server" Visible="False"></asp:Label>
				<asp:Label id="lblEdit5" Runat="server" Visible="False"></asp:Label>        
                
            </asp:Panel>                 
        
        </div>
        
        <asp:panel id="pnlMsg" Visible="False" Runat="server">
			
			<h4><asp:Label id="lblMsg" Runat="server"></asp:Label></h4>
			
			<asp:Panel id="pnlReturn" Runat="server" Visible="False">	
			    <asp:LinkButton id="BackToEntryButton" Runat="server" onclick="BackToEntryButton_Click">Make another Change Request</asp:LinkButton>				
			</asp:Panel>
				
		</asp:panel>
        
        <br /><br />
        
        <asp:HyperLink ID="BackLink" runat="server" NavigateUrl="~/CV/cv11.aspx">Back to Controlled Vocabulary Page</asp:HyperLink>
        
    </div>
    
</asp:Content>

