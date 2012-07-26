<%@ Page Title="Cuahsi HIS VocabularyDescription Services" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HisTermsService._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to the CUASHI VocabularyDescription Services
    </h2>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp To view all the vocabularies and their descriptions click <a href="localhost:1132/HisVocabularyService.svc/rest/Vocabularies" > here </a>
    </p>
    <p>
        <span style="padding-left:20px">1)    To access individual vocabularies and their terms, please have the name of the vocabulary ready : <br/>
        <span style="padding-left:20px">2)    Lets say I want to view all the terms within the vocabulary of CensorCode, <br/>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;given this url :  <a href="localhost:1132/HisVocabularyService.svc/rest/Vocabulary/CensorCode">localhost:1132/HisVocabularyService.svc/rest/Vocabulary/CensorCode </a> <br/>              
        <br/> 
        <span style="padding-left:40px"/>--Basically you can replace the segment "CensorCode" with the name of any vocabulary of your choice,
            <br/>
            <span style="padding-left:40px">and you will be able to view the vocabulary and its terms.<br/><br/>
                <span style="padding-left:20px"> 3) To view the individual term within the vocabulary you need to add one more parameter to the url
                    <br/>
                    <span style="padding-left:20px"> 4) Lets say we are still in the vocabulary, "CensorCode", and we want to view the term "lt"<br/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;given this url<span>: <a href="localhost:1132/HisVocabularyService.svc/rest/Vocabulary/CensorCode/lt">localhost:1132/HisVocabularyService.svc/rest/Vocabulary/CensorCode/lt </a> <br/> <br/>

                    <span style="padding-left:40px"/>--Basically you can replace the segment "lt" with the name of any term of your choice,
            <br/>
            <span style="padding-left:40px">and you will be able to view the information of that term.<br/><br/>             
                    </span>              
                    </span>
                </span></span></span></span></span>

    </p>

</asp:Content>
