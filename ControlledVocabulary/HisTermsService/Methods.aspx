    <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Methods.aspx.cs" Inherits="cuahsi.his.vocabservice.Methods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        .style1
        {
            width: 64px;
            color: black;
            font-family: Arial;
        }
        .style3
        {
            width: 273px;
        }
        .style4
        {
            width: 283px;
        }
        .style5
        {
            width: 294px;
        }
        .style8
        {
            width: 292px;
        }
        .style9
        {
            width: 276px;
        }
        .style10
        {
            width: 275px;
        }
        .style11
        {
            width: 283px;
            background-color: #3399FF;
        }
        .style12
        {
            width: 273px;
            background-color: #3399FF;
        }
        .style13
        {
            width: 294px;
            background-color: #3399FF;
        }
        .style14
        {
            color: #000000;
        }
        .style18
        {
            width: 275px;
            background-color: #99CCFF;
        }
        .style19
        {
            width: 276px;
            background-color: #99CCFF;
        }
        .style20
        {
            width: 292px;
            background-color: #99CCFF;
        }
        .style26
        {
            width: 316px;
            background-color: #99CCFF;
        }
        .style27
        {
            width: 316px;
        }
        .style32
        {
            width: 340px;
            background-color: #99CCFF;
        }
        .style33
        {
            width: 340px;
        }
        .style34
        {
            width: 349px;
            background-color: #99CCFF;
        }
        .style35
        {
            width: 349px;
        }
        .styel12
        {
            background-color: #0099FF;
        }
        .style36
        {
            width: 410px;
            background-color: #3399FF;
        }
        .style37
        {
            width: 410px;
        }
        .style38
        {
            width: 357px;
            background-color: #3399FF;
        }
        .style39
        {
            width: 357px;
        }
        .style40
        {
            background-color: #0099FF;
            width: 384px;
        }
        .style41
        {
            width: 384px;
        }
        .style42
        {
            background-color: #0099FF;
            width: 468px;
        }
        .style43
        {
            width: 468px;
        }
        .style44
        {
            width: 294px;
            background-color: #99CCFF;
        }
        .style45
        {
            width: 273px;
            background-color: #99CCFF;
        }
        .style46
        {
            width: 283px;
            background-color: #99CCFF;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:BulletedList ID="BulletedList1" runat="server">
        <asp:ListItem>REST</asp:ListItem>
        <asp:ListItem>SOAP</asp:ListItem>
    </asp:BulletedList>
    <div style="margin-left: 40px">
        <h1 class="style1"><strong>REST
        </strong>
        </h1>
      <div>Help Endpoint: <a href="terms/rest/help">http://{host}/{service}terms/rest/help</a></div>
           <div>Endpoint: <a href="terms/rest/">http://{host}/{service}/terms/rest</a></div>
  <div style="margin-left: 40px"><div><strong>Methods</strong><br />
            Vocabularies</div>
        </div>

        <div style="margin-left: 40px"><div>Vocabulary/{Vocab}</div>
        </div>
        
        <div style="margin-left: 40px"><div>Vocabulary/{Vocab}/{Term}</div>
        </div>
    
         &nbsp;<ul>
            <li><strong>Vocabularies</strong></li> - this links you a list of the vocabularies and their 
                description
                <br />
                <br />
                INPUT<table border="1">
                    <tr class="style14">
                        <th class="style44">
                            Parmaters</th>
                        <th class="style45">
                            Variable Type</th>
                        <th class="style46">
                            Example</th>
                    </tr>
                    <tr>
                        <td class="style5">
                            -- 
                        </td>
                        <td class="style3">
                            --</td>
                        <td class="style4">
                            --</td>
                    </tr>
                </table>
                
                <br />
                
                OUTPUT<table border="1">
                    <tr class="style14">
                        <th class="style13">
                            Object &nbsp;</th>
                        <th class="style12">
                            Variable Type&nbsp;</th>
                        <th class = "styel12">
                            Path
                        </th>
                        <th class ="style38">
                            Description
                        </th>
                        <th class="style11">
                            Example</th>
                    </tr>
                    <tr>
                        <td class="style5">
                            site</td>
                        <td class="style3">
                            &nbsp;Object&nbsp;</td>
                        <td class="style4">
                            ./Vocabularies&nbsp;</td>
                        <td class="style39">
                            Returns a list of the vocabularies and their descriptions in&nbsp; xml </td>
                        <td class="style4">
                            <asp:HyperLink ID="HyperLink4" runat="server" 
                                NavigateUrl="~/terms/rest/Vocabularies">see vocabularies here</asp:HyperLink></td>

                    </tr>
                </table>
        </ul>
        <p>
            &nbsp;</p>
        <ul>
            <li><strong>Vocabulary/{Vocab}</strong> - this links you to the vocabulary you 
                specified, where you can view all that vocabulary&#39;s terms and definitions<br />
                <br />
                INPUT
                <table border="1" style="width: 838px; height: 55px;">
                    <tr class="style14">
                        <th class="style34">
                            Parmaters</th>
                        <th class="style32">
                            Variable Type</th>
                        <th class="style26">
                            Example</th>
                    </tr>
                    <tr>
                        <td class="style35">
                            VocabularyName 
                        </td>
                        <td class="style33">
                            String 
                        </td>
                        <td class="style27">
                            "CensorCode" 
                        </td>
                    </tr>
                </table>
                        
                <br />
                        
                OUTPUT<table border="1">
                    <tr class="style14">
                        <th class="style13">
                            Object &nbsp;</th>
                        <th class="style12">
                            Variable Type&nbsp;</th>
                        <th class = "style40">
                            Path
                        </th>
                        <th class ="style36">
                            Description
                        </th>
                        <th class="style11">
                            Example</th>
                    </tr>
                    <tr>
                        <td class="style5">
                            site</td>
                        <td class="style3">
                            &nbsp;Object&nbsp;</td>
                        <td class="style41">
                            ./Vocabulary/{VocabularyName}</td>
                        <td class="style37">
                            Returns a vocabulary list and its terms and definition in xml</td>
                      <td class="style4">
                            <asp:HyperLink ID="HyperLink3" runat="server" 
                                NavigateUrl="~/terms/rest/Vocabulary/CensorCode">see vocbulary : CensorCode</asp:HyperLink></td>

                    </tr>
                </table>
        </ul>
        <p>
            &nbsp;</p>
        <ul>
            <li><strong>Vocabulary/{Vocab}/{Term}</strong></li>
                - this links you to the term you have selected, where you can view its 
                definition<br />
                <br />
                INPUT
                <table border="1">
                    <tr class="style14">
                        <th class="style20">
                            Parmaters</th>
                        <th class="style19">
                            Variable Type</th>
                        <th class="style18">
                            Example</th>
                    </tr>
                    <tr>
                        <td class="style8">
                            VocabularyName/Term 
                        </td>
                        <td class="style9">
                            String 
                        </td>
                        <td class="style10">
                            "CensorCode/gt" 
                        </td>
                    </tr>
                </table>
                
                                
                <br />
                
                                
                OUTPUT<table border="1">
                    <tr class="style14">
                        <th class="style13">
                            Object &nbsp;</th>
                        <th class="style12">
                            Variable Type&nbsp;</th>
                        <th class = "style42">
                            Path
                        </th>
                        <th class ="style36">
                            Description
                        </th>
                        <th class="style11">
                            Example</th>
                    </tr>
                    <tr>
                        <td class="style5">
                            site</td>
                        <td class="style3">
                            &nbsp;Object&nbsp;</td>
                        <td class="style43">
                            ./Vocabulary/{VocabularyName}/{Term}</td>
                        <td class="style37">
                            Returns a term and its definition in xml</td>
                        <td class="style4">
                            <asp:HyperLink ID="HyperLink2" runat="server" 
                                NavigateUrl="~/terms/rest/Vocabulary/CensorCode/gt">see term : gt (vocabulary : CensorCode)
                            </asp:HyperLink></td>

                    </tr>
                </table>
        </ul>
    </div>
    <div> <h1 class="style14">SOAP</h1>
    
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/terms">SOAP description</asp:HyperLink>
    
    <div>
        Description of Soap methods
        <ul>
            <li>GetVocabularies</li>
             <li>GetVocabulary</li>
              <li>GetVocabularyTerm</li>
               <li>GetAllTerms</li>
        </ul>
    </div>

   </div>
</asp:Content>
