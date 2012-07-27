<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Methods.aspx.cs" Inherits="cuahsi.his.vocabservice.Methods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:BulletedList ID="BulletedList1" runat="server">
        <asp:ListItem>REST</asp:ListItem>
        <asp:ListItem>SOAP</asp:ListItem>
    </asp:BulletedList>
    <div>
        <h1>REST</h1>
    
         Description of REST methods
        <ul>
            <li>Vocabularies</li>
            <li>Vocabulary/{Vocab}</li>
            <li>Vocabulary/{Vocab}/{Term}</li>
              
        </ul>
        <div><div>Vocabularies</div>
        <div>Method Description</div></div>

        <div><div>Vocabulary/{Vocab}</div>
        <div>Method Description</div></div>
        
        <div><div>Vocabulary/{Vocab}/{Term</div>
        <div>Method Description</div></div>
    </div>
    <div> <h1>SOAP</h1>
    
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/HisVocabularyService.svc">SOAP description</asp:HyperLink>
    
    <div>
        Description of Soap methods
        <ul>
            <li>GetVocabularies</li>
             <li>GetVocabulary</li>
              <li>GetVocabularyTerm</li>
               <li>GetAllTerms</li>
        </ul>
    </div>
     <div><div>GetVocabularies</div>
        <div>Method Description</div></div>

         <div><div>GetVocabulary</div>
        <div>Method Description</div></div>

         <div><div>GetVocabularyTerm</div>
        <div>Method Description</div></div>

         <div><div>GetAllTerms</div>
        <div>Method Description</div></div>

   </div>
</asp:Content>
