<%@ Page Title="VocabularyDescriptionSelection" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="HisTermsService.Selection.VocabularySelection" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        DISPLAY VOCABULARY IN SKOS FORMAT
    </h2>
    <p>
        Pleas select the VocabularyDescription and Term you would like to view.
    </p>

    <script src = "functions.js"></script>
    
    <form id="form1" runat="server">
        <div>
            &nbsp;VocabularyDescription:&nbsp;&nbsp;<asp:DropDownList ID="ddlVocabulary" runat="server" Width="110px" onChange='ddlVocabularyDescriptionOnChange();'>
            </asp:DropDownList>
            <br />
            &nbsp; Term :&nbsp; &nbsp;  &nbsp;   &nbsp; &nbsp;<asp:DropDownList ID="ddlTerm" runat="server" Width="110px" onChange='ddlTermOnChange();'>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="66px" OnClick="btnSubmit_Click" />
            </div>
            <p>
                <asp:Label ID="lblResult" runat="server"></asp:Label>
                <asp:HiddenField ID="hdfVocabulary" runat="server" />
                <asp:HiddenField ID="hdfTerm" runat="server" />
                <asp:HiddenField ID="hdfResult" runat="server" />
                <asp:HiddenField ID="hdfVocabularySelectValue" runat="server" />
                <asp:HiddenField ID="hdfTermSelectValue" runat="server" Value="0" />
            </p>
    </form>
    


</asp:Content>
