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
        .style50
        {
            font-size: medium;
            font-weight: 700;
        }
        .style51
        {
            font-size: small;
            font-family: "Courier New", Courier, monospace;
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
        <ul>
            <li>
                <div style="margin-left: 40px">
                    <div>
                        Vocabularies</div>
                </div>
            </li>
            <li>
                <div style="margin-left: 40px">
                    <div>
                        Vocabulary/{Vocab}</div>
                </div>
            </li>
            <li>
                <div style="margin-left: 40px">
                    <div>
                        Vocabulary/{Vocab}/{Term}</div>
                </div>
            </li>
    
                <strong>
                <br />
                Vocabularies</strong> - this links you a list of the vocabularies and their 
                description
                <br />
                <br />INPUT<table border="1">
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
                <br />OUTPUT<table border="1">
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
                            Returns a list of the vocabularies and their descriptions in&nbsp; xml 
                        </td>
                        <td class="style4">
                            <asp:HyperLink ID="HyperLink4" runat="server" 
                                NavigateUrl="~/HisVocabularyService.svc/rest/Vocabularies">see vocabularies here</asp:HyperLink>
                        </td>
                    </tr>
                </table>
        </ul>
        <p>
            &nbsp;</p>
        <ul>
            <strong>Vocabulary/{Vocab}</strong> - this links you to the vocabulary you 
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
                                NavigateUrl="~/HisVocabularyService.svc/rest/Vocabulary/CensorCode">see vocbulary : CensorCode</asp:HyperLink></td>

                    </tr>
                </table>
        </ul>
        <p>
            &nbsp;</p>
        <ul>
            <strong>Vocabulary/{Vocab}/{Term}</strong>
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
                                NavigateUrl="~/HisVocabularyService.svc/rest/Vocabulary/CensorCode/gt">see term : gt (vocabulary : CensorCode)
                            </asp:HyperLink></td>

                    </tr>
                </table>
        </ul>
    </div>
    <div> <h1 class="style14">SOAP</h1>
    
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/HisVocabularyService.svc">SOAP description</asp:HyperLink>
    
    <div>
        Description of Soap methods
        <ul>
            <li>GetVocabularies</li>
            <li>GetVocabulary</li>
            <li>GetVocabularyTerm</li>
            <li>GetAllTerms<br />
                <br />
                <br />
                <br />
            </li>
                <span class="style50">GetVocabularies&nbsp; </span></br>
                this method returns every single vocabulary in the database, each vocabulary including a description as well<br />
&nbsp;<br/>SOAP REQUEST
                <div style="height:230px; width:820px; border:1px solid #ccc;font:16px/26px Georgia, Garamond, Serif;overflow:auto; margin-left: 40px;">
                    <PRE lang=xml><span class="style51">&lt;soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ont="http://his.cuahsi.org/services/ontology"&gt;</span>
<span class="style51">   &lt;soapenv:Header/&gt;</span>
<span class="style51">   &lt;soapenv:Body&gt;</span>
<span class="style51">      &lt;ont:GetVocabularies/&gt;</span>
<span class="style51">   &lt;/soapenv:Body&gt;</span>
<span class="style51">&lt;/soapenv:Envelope&gt;</span></PRE>
                    </h3>
                </div>
                <br />SOAP RESPONSE
                <div style="height:216px; width:825px; border:1px solid #ccc;font:16px/26px Georgia, Garamond, Serif;overflow:auto; margin-left: 40px;">
                    <PRE lang=xml 
                        style="font-size: small; font-family: 'Courier New', Courier, monospace">&lt;s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"&gt;
   &lt;s:Body&gt;
      &lt;GetVocabulariesResponse xmlns="http://his.cuahsi.org/services/ontology"&gt;
         &lt;GetVocabulariesResult xmlns:a="http://his.cuahsi.org/ontology" xmlns:i="http://www.w3.org/2001/XMLSchema-instance"&gt;
            &lt;a:Vocabulary&gt;
               &lt;a:Description&gt;used to populate the CensorCode field of the DataValues table&lt;/a:Description&gt;
               &lt;a:Name&gt;CensorCode&lt;/a:Name&gt;
            &lt;/a:Vocabulary&gt;
            &lt;a:Vocabulary&gt;
               &lt;a:Description&gt;Used to populate the DataType field of the Variables table&lt;/a:Description&gt;
               &lt;a:Name&gt;DataType&lt;/a:Name&gt;
            &lt;/a:Vocabulary&gt;
            &lt;a:Vocabulary&gt;
               &lt;a:Description&gt;Used to populate the GeneralCategory field in the Variables table&lt;/a:Description&gt;
               &lt;a:Name&gt;GeneralCategory&lt;/a:Name&gt;
            &lt;/a:Vocabulary&gt;
            &lt;a:Vocabulary&gt;
               &lt;a:Description&gt;Used to populate the SampleMedium field in the Variables table&lt;/a:Description&gt;
               &lt;a:Name&gt;SampleMedium&lt;/a:Name&gt;
            &lt;/a:Vocabulary&gt;
            &lt;a:Vocabulary&gt;
               &lt;a:Description&gt;Used to populate the SampleType field in the Samples table&lt;/a:Description&gt;
               &lt;a:Name&gt;SampleType&lt;/a:Name&gt;
            &lt;/a:Vocabulary&gt;
            &lt;a:Vocabulary&gt;
               &lt;a:Description&gt;Used to populate the SiteType field in the Sites table&lt;/a:Description&gt;
               &lt;a:Name&gt;SiteType&lt;/a:Name&gt;
            &lt;/a:Vocabulary&gt;
            &lt;a:Vocabulary&gt;
               &lt;a:Description&gt;Used to poputate the Speciation field in the Variables table&lt;/a:Description&gt;
               &lt;a:Name&gt;Speciation&lt;/a:Name&gt;
            &lt;/a:Vocabulary&gt;
            &lt;a:Vocabulary&gt;
               &lt;a:Description&gt;Used to populate the TopicCategory field in the ISOMetadata table&lt;/a:Description&gt;
               &lt;a:Name&gt;TopicCategory&lt;/a:Name&gt;
            &lt;/a:Vocabulary&gt;
            &lt;a:Vocabulary&gt;
               &lt;a:Description&gt;Used to populate the ValueType field in the Variables table&lt;/a:Description&gt;
               &lt;a:Name&gt;ValueType&lt;/a:Name&gt;
            &lt;/a:Vocabulary&gt;
            &lt;a:Vocabulary&gt;
               &lt;a:Description&gt;Used to populate the VariableName field in the Variables table&lt;/a:Description&gt;
               &lt;a:Name&gt;VariableName&lt;/a:Name&gt;
            &lt;/a:Vocabulary&gt;
            &lt;a:Vocabulary&gt;
               &lt;a:Description&gt;Used to populate the VerticalDatum field im the Sites table&lt;/a:Description&gt;
               &lt;a:Name&gt;VerticalDatum&lt;/a:Name&gt;
            &lt;/a:Vocabulary&gt;
         &lt;/GetVocabulariesResult&gt;
      &lt;/GetVocabulariesResponse&gt;
   &lt;/s:Body&gt;
&lt;/s:Envelope&gt;
            
        </PRE>
                    </h3>
                </div>
                <br />
                <br /><span class="style50"><strong>GetVocabulary</strong></span><br/>
                this method returns the list of terms in the specified vocabulary 
                ( the example below returns the terms from vocabulary: CensorCode )<br />
                <br />SOAP REQUEST
                <div style="height:157px; width:824px; border:1px solid #ccc;font:16px/26px Georgia, Garamond, Serif;overflow:auto; margin-left: 40px;">
                    <PRE lang=xml 
                        style="font-size: small; font-family: 'Courier New', Courier, monospace">&lt;soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ont="http://his.cuahsi.org/services/ontology"&gt;
   &lt;soapenv:Header/&gt;
   &lt;soapenv:Body&gt;
      &lt;ont:GetVocabulary&gt;
         &lt;ont:VocabularyName&gt;CensorCode&lt;/ont:VocabularyName&gt;
      &lt;/ont:GetVocabulary&gt;
   &lt;/soapenv:Body&gt;
&lt;/soapenv:Envelope&gt;
                </PRE>
                </div>
                <br />SOAP RESPONSE
                <div style="height:157px; width:824px; border:1px solid #ccc;font:16px/26px Georgia, Garamond, Serif;overflow:auto; margin-left: 40px;">
                    <PRE lang=xml 
                        style="font-size: small; font-family: 'Courier New', Courier, monospace"> &lt;s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"&gt;
   &lt;s:Body&gt;
      &lt;GetVocabularyResponse xmlns="http://his.cuahsi.org/services/ontology"&gt;
         &lt;GetVocabularyResult xmlns:a="http://his.cuahsi.org/ontology" xmlns:i="http://www.w3.org/2001/XMLSchema-instance"&gt;
            &lt;a:Description i:nil="true"/&gt;
            &lt;a:Name&gt;CensorCode&lt;/a:Name&gt;
            &lt;a:VocabularyTerms xmlns:b="http://www.w3.org/2004/02/skos/core#"&gt;
               &lt;b:Concept&gt;
                  &lt;b:definition&gt;less than&lt;/b:definition&gt;
                  &lt;b:inShceme&gt;CensorCode&lt;/b:inShceme&gt;
                  &lt;b:prefLabel&gt;lt&lt;/b:prefLabel&gt;
               &lt;/b:Concept&gt;
               &lt;b:Concept&gt;
                  &lt;b:definition&gt;greater than&lt;/b:definition&gt;
                  &lt;b:inShceme&gt;CensorCode&lt;/b:inShceme&gt;
                  &lt;b:prefLabel&gt;gt&lt;/b:prefLabel&gt;
               &lt;/b:Concept&gt;
               &lt;b:Concept&gt;
                  &lt;b:definition&gt;not censored&lt;/b:definition&gt;
                  &lt;b:inShceme&gt;CensorCode&lt;/b:inShceme&gt;
                  &lt;b:prefLabel&gt;nc&lt;/b:prefLabel&gt;
               &lt;/b:Concept&gt;
               &lt;b:Concept&gt;
                  &lt;b:definition&gt;non-detect&lt;/b:definition&gt;
                  &lt;b:inShceme&gt;CensorCode&lt;/b:inShceme&gt;
                  &lt;b:prefLabel&gt;nd&lt;/b:prefLabel&gt;
               &lt;/b:Concept&gt;
               &lt;b:Concept&gt;
                  &lt;b:definition&gt;present but not quantified&lt;/b:definition&gt;
                  &lt;b:inShceme&gt;CensorCode&lt;/b:inShceme&gt;
                  &lt;b:prefLabel&gt;pnq&lt;/b:prefLabel&gt;
               &lt;/b:Concept&gt;
            &lt;/a:VocabularyTerms&gt;
         &lt;/GetVocabularyResult&gt;
      &lt;/GetVocabularyResponse&gt;
   &lt;/s:Body&gt;
&lt;/s:Envelope&gt;
                </PRE>
                </div>
                <span class="style50"><strong>
                <br />
                <br />GetVocabularyTerm<br />
               
                </strong></span>this method returns the definition of the specified term in the specified vocabulary ( the examples below request term: gt from </br>
                vocabulary: CensorCode )
                <br />
                <br />
                SOAP REQUEST 
                <div style="height:157px; width:824px; border:1px solid #ccc;font:16px/26px Georgia, Garamond, Serif;overflow:auto; margin-left: 40px;">
                    <PRE lang=xml 
                        style="font-size: small; font-family: 'Courier New', Courier, monospace"> &lt;soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ont="http://his.cuahsi.org/services/ontology"&gt;
   &lt;soapenv:Header/&gt;
   &lt;soapenv:Body&gt;
      &lt;ont:GetVocabularyTerm&gt;
         &lt;ont:VocabularyName&gt;CensorCode&lt;/ont:VocabularyName&gt;
         &lt;ont:TermName&gt;gt&lt;/ont:TermName&gt;
      &lt;/ont:GetVocabularyTerm&gt;
   &lt;/soapenv:Body&gt;
&lt;/soapenv:Envelope&gt;
                </PRE>
                </div>
                <br />
                         SOAP RESPONSE
                <div style="height:157px; width:824px; border:1px solid #ccc;font:16px/26px Georgia, Garamond, Serif;overflow:auto; margin-left: 40px;">
                    <PRE lang=xml 
                        style="font-size: small; font-family: 'Courier New', Courier, monospace">&lt;s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"&gt;
   &lt;s:Body&gt;
      &lt;GetVocabularyTermResponse xmlns="http://his.cuahsi.org/services/ontology"&gt;
         &lt;GetVocabularyTermResult xmlns:a="http://www.w3.org/2004/02/skos/core#" xmlns:i="http://www.w3.org/2001/XMLSchema-instance"&gt;
            &lt;a:definition&gt;greater than&lt;/a:definition&gt;
            &lt;a:inShceme&gt;CensorCode&lt;/a:inShceme&gt;
            &lt;a:prefLabel&gt;gt&lt;/a:prefLabel&gt;
         &lt;/GetVocabularyTermResult&gt;
      &lt;/GetVocabularyTermResponse&gt;
   &lt;/s:Body&gt;
&lt;/s:Envelope&gt;
                </PRE>
                </div>
                <span class="style50"><strong>
                <br />
                GetAllTerms</strong></span><br>
                this method returns the definitions from 
                every term in the database (which means every term from every vocabulary in the 
                database)<br />
                </br>
            SOAP REQUEST
                 <div style="height:157px; width:824px; border:1px solid #ccc;font:16px/26px Georgia, Garamond, Serif;overflow:auto; margin-left: 40px;">
                    <PRE lang=xml 
                         style="font-size: small; font-family: 'Courier New', Courier, monospace">&lt;soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ont="http://his.cuahsi.org/services/ontology"&gt;
   &lt;soapenv:Header/&gt;
   &lt;soapenv:Body&gt;
      &lt;ont:getAllTerms/&gt;
   &lt;/soapenv:Body&gt;
&lt;/soapenv:Envelope&gt;
                </PRE>
                </div>
                <br />SOAP RESPONSE
                <div style="height:157px; width:824px; border:1px solid #ccc;font:16px/26px Georgia, Garamond, Serif;overflow:auto; margin-left: 40px;">
                    <PRE lang=xml 
                        style="font-size: small; font-family: 'Courier New', Courier, monospace">&lt;s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"&gt;
   &lt;s:Body&gt;
      &lt;getAllTermsResponse xmlns="http://his.cuahsi.org/services/ontology"&gt;
         &lt;getAllTermsResult xmlns:a="http://www.w3.org/2004/02/skos/core#" xmlns:i="http://www.w3.org/2001/XMLSchema-instance"&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;less than&lt;/a:definition&gt;
               &lt;a:inShceme&gt;CensorCode&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;lt&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;greater than&lt;/a:definition&gt;
               &lt;a:inShceme&gt;CensorCode&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;gt&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;not censored&lt;/a:definition&gt;
               &lt;a:inShceme&gt;CensorCode&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;nc&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;non-detect&lt;/a:definition&gt;
               &lt;a:inShceme&gt;CensorCode&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;nd&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;present but not quantified&lt;/a:definition&gt;
               &lt;a:inShceme&gt;CensorCode&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;pnq&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The data type is unknown&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Unknown&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The values represent the median over a time interval, such as daily median discharge or daily median temperature.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Median&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The values represent the variance of a set of observations made over a time interval.  Variance computed using the unbiased formula SUM((Xi-mean)^2)/(n-1) are preferred.  The specific formula used to compute variance can be noted in the methods description.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Variance&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Best Easy Systematic Estimator BES = (Q1 +2Q2 +Q3)/4.  Q1, Q2, and Q3 are first, second, and third quartiles. See Woodcock, F. and Engel, C., 2005: Operational Consensus Forecasts.Weather and Forecasting, 20, 101-111. (http://www.bom.gov.au/nmoc/bulletins/60/article_by_Woodcock_in_Weather_and_Forecasting.pdf) and Wonnacott, T. H., and R. J. Wonnacott, 1972: Introductory Statistics. Wiley, 510 pp.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Best Easy Systematic Estimator&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The values represent the standard deviation of a set of observations made over a time interval. Standard deviation computed using the unbiased formula SQRT(SUM((Xi-mean)^2)/(n-1)) are preferred. The specific formula used to compute variance can be noted in the methods description.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;StandardDeviation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The values are the most frequent values occurring at some time during a time interval, such as annual most frequent wind direction.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Mode&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A quantity specified at a particular instant in time measured with sufficient frequency (small spacing) to be interpreted as a continuous record of the phenomenon.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Continuous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The phenomenon is sampled at a particular instant in time but with a frequency that is too coarse for interpreting the record as continuous.  This would be the case when the spacing is significantly larger than the support and the time scale of fluctuation of the phenomenon, such as for example infrequent water quality samples.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sporadic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The values represent the cumulative value of a variable measured or calculated up to a given instant of time, such as cumulative volume of flow or cumulative precipitation.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cumulative&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The values represent the incremental value of a variable over a time interval, such as the incremental volume of flow or incremental precipitation.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Incremental&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The values represent the average over a time interval, such as daily mean discharge or daily mean temperature.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Average&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The values are the maximum values occurring at some time during a time interval, such as annual maximum discharge or a daily maximum air temperature.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Maximum&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The values are the minimum values occurring at some time during a time interval, such as 7-day low flow for a year or the daily minimum temperature.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Minimum&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The values are quantities that can be interpreted as constant for all time, or over the time interval to a subsequent measurement of the same variable at the same site.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Constant Over Interval&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The values are categorical rather than continuous valued quantities. Mapping from Value values to categories is through the CategoryDefinitions table.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;DataType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Categorical&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The general category is unknown&lt;/a:definition&gt;
               &lt;a:inShceme&gt;GeneralCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Unknown&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with instrumentation and instrument properties such as battery voltages, data logger temperatures, often useful for diagnosis.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;GeneralCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Instrumentation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with water quality variables or processes&lt;/a:definition&gt;
               &lt;a:inShceme&gt;GeneralCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Water Quality&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with the climate, weather, or atmospheric processes&lt;/a:definition&gt;
               &lt;a:inShceme&gt;GeneralCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Climate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with hydrologic variables or processes&lt;/a:definition&gt;
               &lt;a:inShceme&gt;GeneralCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Hydrology&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with biological organisms&lt;/a:definition&gt;
               &lt;a:inShceme&gt;GeneralCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Biota&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with geology or geological processes&lt;/a:definition&gt;
               &lt;a:inShceme&gt;GeneralCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Geology&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The sample medium is unknown&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Unknown&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sample medium other than those contained in the CV&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Other&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Observation in, of or sample taken from snow&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Snow&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sample medium not relevant in the context of the measurement&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Not Relevant&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Observation or sample of surface water such as a stream, river, lake, pond, reservoir, ocean, etc.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Surface Water&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sample taken from water located below the surface of the ground, such as from a well or spring&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Groundwater&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sample taken from the sediment beneath the water column&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sediment&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sample taken from the soil&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Soil&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sample taken from the atmosphere&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Air&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sample taken from the tissue of a biological organism&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Tissue&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sample taken from solid or liquid precipitation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Precipitation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Air contained in the soil pores&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Soil air&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;the water contained in the soil pores&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Soil water&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sample taken from raw municipal waste water stream.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Municipal waste water&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Fluids produced from wells during oil or gas production which may include formation water, injected fluids, oil and gas.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Production water&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A mixture of formation water and hydraulic fracturing injectates deriving from oil and gas wells prior to placing wells into production&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleMedium&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Flowback water&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The sample type is unknown&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Unknown&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;There is no lab sample associated with this measurement&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;No Sample&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Foliage Digestion&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;FD&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Forest Floor Digestion&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;FF&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Foliage Leaching&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;FL&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Litter Fall Digestion&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;LF&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Groundwater&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;GW&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Precipitation Bulk&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;PB&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Petri Dish (Dry Deposition)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;PD&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Precipitation Event&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;PE&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Precipitation Increment&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;PI&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Precipitation Weekly&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;PW&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Rock Extraction&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;RE&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Stemflow Event&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;SE&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Standard Reference&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;SR&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Streamwater Suspended Sediment&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;SS&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Streamwater&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;SW&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Throughfall Event&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;TE&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Throughfall Increment&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;TI&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Throughfall Weekly&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;TW&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Vadose Water Event&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;VE&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Vadose Water Increment&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;VI&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Vadose Water Weekly&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;VW&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Grab sample&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Grab&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sample collected using an automated sampler&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Automated&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;sample type can include a number of measured sample types including temperature, RH, solar radiation, precipitation, wind speed, wind direction.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SampleType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;meteorological&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A coastal inlet of the sea or ocean; esp. the mouth of a river, where tide water normally mixes with stream water (modified, Webster). Salinity in estuaries typically ranges from 1 to 25 Practical Salinity Units (psu), as compared oceanic values around 35-psu. See also: tidal stream and coastal.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Estuary&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An inland body of standing fresh or saline water that is generally too deep to permit submerged aquatic vegetation to take root across the entire body (cf: wetland). This site type includes an expanded part of a river, a reservoir behind a dam, and a natural or excavated depression containing a water body without surface-water inlet and/or outlet.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Lake, Reservoir, Impoundment&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Site in the open ocean, gulf, or sea. (See also: Coastal, Estuary, and Tidal stream).&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Ocean&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An oceanic site that is located off-shore beyond the tidal mixing zone (estuary) but close enough to the shore that the investigator considers the presence of the coast to be important. Coastal sites typically are within three nautical miles of the shore.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Coastal&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A body of running water moving under gravity flow in a defined channel. The channel may be entirely natural, or altered by engineering practices through straightening, dredging, and (or) lining. An entirely artificial channel should be qualified with the "canal" or "ditch" secondary site type.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Stream&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An artificial watercourse designed for navigation, drainage, or irrigation by connecting two or more bodies of water; it is larger than a ditch.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Canal&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An excavation artificially dug in the ground, either lined or unlined, for conveying water for drainage or irrigation; it is smaller than a canal.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Ditch&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A stream reach where the flow is influenced by the tide, but where the water chemistry is not normally influenced. A site where ocean water typically mixes with stream water should be coded as an estuary.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Tidal stream&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Land where saturation with water is the dominant factor determining the nature of soil development and the types of plant and animal communities living in the soil and on its surface (Cowardin, December 1979). Wetlands are found from the tundra to the tropics and on every continent except Antarctica. Wetlands are areas that are inundated or saturated by surface or groundwater at a frequency and duration sufficient to support, and that under normal circumstances do support, a prevalence of vegetation typically adapted for life in saturated soil conditions. Wetlands generally include swamps, marshes, bogs and similar areas. Wetlands may be forested or unforested, and naturally or artificially created.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wetland&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A hole or shaft constructed in the earth intended to be used to locate, sample, or develop groundwater, oil, gas, or some other subsurface material. The diameter of a well is typically much smaller than the depth. Wells are also used to artificially recharge groundwater or to pressurize oil and gas production zones. Additional information about specific kinds of wells should be recorded under the secondary site types or the Use of Site field. Underground waste-disposal wells should be classified as waste-injection wells.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Well&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An infiltration gallery consisting of one or more underground laterals through which groundwater is collected and a vertical caisson from which groundwater is removed. Also known as a "horizontal well". These wells produce large yield with small drawdown.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Collector or Ranney type well&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A well equipped to measure small changes in the thickness of the penetrated sediments, such as those caused by groundwater withdrawal or recharge.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Extensometer well&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A permanent well, drive point, or other device intended to sample a saturated zone in close proximity to a stream.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Hyporheic-zone well&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Collector or drainage wells connected by an underground lateral.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Interconnected wells&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A group of wells that are pumped through a single header and for which little or no data about the individual wells are available.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Multiple wells&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An uncased hole (or one cased only temporarily) that was drilled for water, or for geologic or hydrogeologic testing. It may be equipped temporarily with a pump in order to make a pumping test, but if the hole is destroyed after testing is completed, it is still a test hole. A core hole drilled as a part of mining or quarrying exploration work should be in this class.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Test hole not completed as a well&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A location below the land surface, but not a well, soil hole, or excavation.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Subsurface&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A natural open space within a rock formation large enough to accommodate a human. A cave may have an opening to the outside, is always underground, and sometimes submerged. Caves commonly occur by the dissolution of soluble rocks, generally limestone, but may also be created within the voids of large-rock aggregations, in openings along seismic faults, and in lava formations.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cave&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An underground pipe or tunnel through which groundwater is artificially diverted to surface water for the purpose of reducing erosion or lowering the water table. A drain is typically open to the atmosphere at the lowest elevation, in contrast to a well which is open at the highest point.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Groundwater drain&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A constructed subsurface open space large enough to accommodate a human that is not substantially open to the atmosphere and is not a well. The excavation may have been for minerals, transportation, or other purposes. See also: Excavation.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Tunnel, shaft, or mine&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A site equipped to measure conditions in the subsurface deeper than a soil hole, but above the water table or other zone of saturation.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Unsaturated zone&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A location at which the water table intersects the land surface, resulting in a natural flow of groundwater to the surface. Springs may be perennial, intermittent, or ephemeral.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Spring&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A site established primarily to measure meteorological properties or atmospheric deposition.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Atmosphere&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An Aggregate Groundwater Withdrawal/Return site represents an aggregate of specific sites whe groundwater is withdrawn or returned which is defined by a geographic area or some other common characteristic. An aggregate groundwatergroundwater site type is used when it is not possible or practical to describe the specific sites as springs or as any type of well including 'multiple wells', or when water-use information is only available for the aggregate. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Aggregate groundwater use&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An Aggregate Surface-Water Diversion/Return site represents an aggregate of specific sites where surface water is diverted or returned which is defined by a geographic area or some other common characteristic. An aggregate surface-water site type is used when it is not possible or practical to describe the specific sites as diversions, outfalls, or land application sites, or when water-use information is only available for the aggregate. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Aggregate surface-water-use&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An underground conduit created to convey storm drainage and waste products into a wastewater-treatment plant, stream, reservoir, or disposal site.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Combined sewer&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A facility that generates electric power by converting potential energy of water into kinetic energy. Typically, turbine generators are turned by falling water.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Hydroelectric plant&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A site where water or wastewater is returned to a surface-water body, e.g. the point where wastewater is returned to a stream. Typically, the discharge end of an effluent pipe.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Outfall&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An Aggregate Water-Use Establishment represents an aggregate class of water-using establishments or individuals that are associated with a specific geographic location and water-use category, such as all the industrial users located within a county or all self-supplied domestic users in a county. The aggregate class of water-using establishments is identified using the national water-use category code and optionally classified using the Standard Industrial Classification System Code (SIC code) or North American Classification System Code (NAICS code). An aggregate water-use establishment site type is used when specific information needed to create sites for the individual facilities or users is not available or when it is not desirable to store the site-specific information in the database. Data entry rules that apply to water-use establishments also apply to aggregate water-use establishments. Aggregate sites that span multiple counties should be coded with 000 as the county code, or an aggregate site can be created for each county.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Aggregate water-use establishment&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A non-ambient location where environmental measurements are expected to be strongly influenced by current or previous activities of humans. *Sites identified with a "facility" primary site type must be further classified with one of the applicable secondary site types.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Facility&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A facility for storage and/or biological treatment of wastes from livestock operations. Animal-waste lagoons are earthen structures ranging from pits to large ponds, and contain manure which has been diluted with building washwater, rainfall, and surface runoff. In treatment lagoons, the waste becomes partially liquefied and stabilized by bacterial action before the waste is disposed of on the land and the water is discharged or re-used.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Animal waste lagoon&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An artificial, non-pressurized reservoir filled by gravity flow and used for water storage. The reservoir may be located above, at, or below ground level. The water may be supplied from diversion of precipitation, surface, or groundwater sources.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cistern&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A site where water is withdrawn or diverted from a surface-water body (e.g. the point where the upstream end of a canal intersects a stream, or point where water is withdrawn from a reservoir). Includes sites where water is pumped for use elsewhere.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Diversion&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A water-using facility characterized by an area where plants are grown for transplanting, for use as stocks for budding and grafting, or for sale. Irrigation water may or may not be applied.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Field, Pasture, Orchard, or Nursery&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A place-of-use, either public or private, where the game of golf is played. A golf course typically uses water for irrigation purposes. Should not be used if the site is a specific hydrologic feature or facility; but can be used especially for the water-use sites.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Golf course&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A typically dry location on the surface of the land where primarily solid waste products are currently, or previously have been, aggregated and sometimes covered with a veneer of soil. See also: Wastewater disposal and waste-injection well.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Landfill&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A surface site where the land surface is covered by a relatively impermeable material, such as concrete or asphalt. Pavement sites are typically part of transportation infrastructure, such as roadways, parking lots, or runways.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Pavement&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A facility where water is treated prior to use for consumption or other purpose.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Water-supply treatment plant&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A site where the disposal of waste water on land occurs. Use "waste-injection well" for underground waste-disposal sites.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wastewater land application&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A facility where wastewater is treated to reduce concentrations of dissolved and (or) suspended materials prior to discharge or reuse.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wastewater-treatment plant&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The part of a rock formation that appears at the surface of the surrounding land.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Outcrop&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A site where some types of quality-control samples are collected, and where equipment and supplies for environmental sampling are prepared. Equipment blank samples are commonly collected at this site type, as are samples of locally produced deionized water. This site type is typically used when the data are either not associated with a unique environmental data-collection site, or where blank water supplies are designated by Center offices with unique station IDs.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Laboratory or sample-preparation area&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An underground conduit created to convey liquid and semisolid domestic, commercial, or industrial waste into a treatment plant, stream, reservoir, or disposal site. If the sewer also conveys storm water, then the "combined sewer" secondary site type should be used.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wastewater sewer&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A site within or in close proximity to a subsurface sewage disposal system that generally consists of: (1) a septic tank where settling of solid material occurs, (2) a distribution system that transfers fluid from the tank to (3) a leaching system that disperses the effluent into the ground.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Septic system&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An underground conduit created to convey storm drainage into a stream channel or reservoir. If the sewer also conveys liquid waste products, then the "combined sewer" secondary site type should be used.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Storm sewer&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A facility that uses water in the generation of electricity from heat. Typically turbine generators are driven by steam. The heat may be caused by various means, including combustion, nuclear reactions, and geothermal processes.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Thermoelectric plant&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A site located somewhere on a networked infrastructure that distributes treated or untreated water to multiple domestic, industrial, institutional, and (or) commercial users. May be owned by a municipality or community, a water district, or a private concern.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Water-distribution system&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A facility used to convey industrial waste, domestic sewage, brine, mine drainage, radioactive waste, or other fluid into an underground zone. An oil-test or deep-water well converted to waste disposal should be in this category. A well where fresh water is injected to artificially recharge thegroundwaterr supply or to pressurize an oil or gas production zone by injecting a fluid should be classified as a well (not an injection-well facility), with additional information recorded under Use of Site.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Waste injection well&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A place-of-use (a water using facility that is associated with a specific geographical point location, such as a business or industrial user) that cannot be specified with any other facility secondary type. Water-use place-of-use sites are establishments such as a factory, mill, store, warehouse, farm, ranch, or bank. A place-of-use site is further classified using the national water-use category code (C39) and optionally classified using the Standard Industrial Classification System Code (SIC code) or North American Classification System Code (NAICS code). See also: Aggregate water-use-establishment.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Water-use establishment&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Vent from which volcanic gases escape to the atmosphere. Also known as fumarole.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Volcanic vent&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Body of land ice that consists of recrystallized snow accumulated on the surface of the ground and moves slowly downslope (WSP-1541A) over a period of years or centuries. Since glacial sites move, the lat-long precision for these sites is usually coarse.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Glacier&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A location on the surface of the earth that is not normally saturated with water. Land sites are appropriate for sampling vegetation, overland flow of water, or measuring land-surface properties such as temperature. (See also: Wetland).&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Land&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;An artificially constructed cavity in the earth that is deeper than the soil (see soil hole), larger than a well bore (see well and test hole), and substantially open to the atmosphere. The diameter of an excavation is typically similar or larger than the depth. Excavations include building-foundation diggings, roadway cuts, and surface mines.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Excavation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A dried-up, vegetation-free, flat-floored area composed of thin, evenly stratified sheets of fine clay, silt or sand, and represents the bottom part of a shallow, completely closed or undrained desert lake basin in which water accumulates and is quickly evaporated, usually leaving deposits of soluble salts.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Playa&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A small excavation into soil at the top few meters of earth surface. Soil generally includes some organic matter derived from plants. Soil holes are created to measure soil composition and properties. Sometimes electronic probes are inserted into soil holes to measure physical properties, and (or) the extracted soil is analyzed.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Soil hole&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A crater formed when the roof of a cavern collapses; usually found in limestone areas. Surface water and precipitation that enters a sinkhole usually evaporates or infiltrates into the ground, rather than draining into a stream.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sinkhole&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The land along the edge of the sea, a lake, or a wide river where the investigator considers the proximity of the water body to be important. Land adjacent to a reservoir, lake, impoundment, or oceanic site type is considered part of the shore when it includes a beach or bank between the high and low water marks.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;SiteType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Shore&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Speciation is unknown&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Unknown&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Speciation is not applicable&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Not Applicable&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as carbon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;C&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as calcium carbonate&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;CaCO3&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;N&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as ammonium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;NH4&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as nitrite&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;NO2&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as nitrate&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;NO3&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as phosphorus&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;P&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as phosphate&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;PO4&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as Sulfur&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;S&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as silicon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Si&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as silicate&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;SiO2&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as Sulfate&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;SO4&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as water&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;H2O&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as calcium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Ca&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as potassium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;K&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as magnesium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Mg&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as sodium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Na&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as nitrogen-15&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;delta N15&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as carbon dioxide&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;CO2&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as hydrogen carbonate&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;HCO3&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as carbonate&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;CO3&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as thallium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Tl&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as tin&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;SN&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as mercury&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Hg&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as barium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Ba&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as zircon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Zr&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as methane&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;CH4&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as ethane&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;C2H6&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as aluminium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Al&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as arsenic&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;As&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as boron&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;B&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as cadmium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cd&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as cobalt&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Co&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as chromium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cr&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as copper&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cu&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as iron&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Fe&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as manganese&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Mn&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as molybdenum&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Mo&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as nickel&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Ni&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as lead&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Pb&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as antimony&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sb&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as selenium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Se&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as strontium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sr&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as zinc&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Zn&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as fluorine&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;F&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as chlorine&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cl&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as bromine&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Br&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as pH&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;pH&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as electrical conductivity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;EC&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as total alkalinity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;TA&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as oxygen-18&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;delta O18&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as deuterium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;delta 2H&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as uranium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;U&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as vanadium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;V&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Expressed as titanium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;Speciation&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Ti&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The topic category is unknown&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Unknown&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with agricultural production&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;farming&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with biological organisms&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;biota&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with boundaries&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;boundaries&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with climatology, meteorology, or the atmosphere&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;climatology/meteorology/atmosphere&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with the economy&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;economy&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with elevation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;elevation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with the environment&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;environment&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with geoscientific information&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;geoscientificInformation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with health&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;health&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with imagery, base maps, or earth cover&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;imageryBaseMapsEarthCover&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with intelligence or the military&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;intelligenceMilitary&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with inland waters&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;inlandWaters&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with location&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;location&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with oceans&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;oceans&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with planning or cadestre&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;planningCadastre&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with society&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;society&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with structure&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;structure&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with transportation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;transportation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Data associated with utilities or communication&lt;/a:definition&gt;
               &lt;a:inShceme&gt;TopicCategory&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;utilitiesCommunication&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The value type is unknown&lt;/a:definition&gt;
               &lt;a:inShceme&gt;ValueType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Unknown&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Observation of a variable using a field instrument&lt;/a:definition&gt;
               &lt;a:inShceme&gt;ValueType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Field Observation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Observation that is the result of analyzing a sample in a laboratory&lt;/a:definition&gt;
               &lt;a:inShceme&gt;ValueType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sample&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Values generated by a simulation model&lt;/a:definition&gt;
               &lt;a:inShceme&gt;ValueType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Model Simulation Result&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Value that is directly derived from an observation or set of observations&lt;/a:definition&gt;
               &lt;a:inShceme&gt;ValueType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Derived Value&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A value used as part of the calibration of an instrument at a particular time.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;ValueType&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Calibration Value&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The phytoplankton pigment 19-Hexanoyloxyfucoxanthin&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;19-Hexanoyloxyfucoxanthin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The phytoplankton pigment  9 cis-Neoxanthin&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;9 cis-Neoxanthin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Acid neutralizing capacity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Acid neutralizing capacity&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Code for the agency which analyzed the sample&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Agency code&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Bicarbonate Alkalinity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Alkalinity, bicarbonate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Carbonate Alkalinity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Alkalinity, carbonate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Hydroxide Alkalinity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Alkalinity, hydroxide&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Alkalinity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Alkalinity, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The phytoplankton pigment Alloxanthin&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Alloxanthin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Barometric pressure&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Barometric pressure&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The battery voltage of a datalogger or sensing system, often recorded as an indicator of data reliability&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Battery voltage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Bicarbonate (HCO3-)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Bicarbonate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;20-day Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD20&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;20-day Nitrogenous Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD20, nitrogenous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;5-day Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD5&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;5-day Carbonaceous Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD5, carbonaceous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;5-day Nitrogenous Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD5, nitrogenous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Ultimate Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BODu&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Carbonaceous Ultimate Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BODu, carbonaceous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Nitrogenous Ultimate Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BODu, nitrogenous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Boron (B)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Boron&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Bulk electrical conductivity of a medium measured using a sensor such as time domain reflectometry (TDR), as a raw sensor response in the measurement of a quantity like soil moisture.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Bulk electrical conductivity&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Cadmium (Cd)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cadmium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Calcium (Ca)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Calcium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The phytoplankton pigment Canthaxanthin&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Canthaxanthin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Carbon dioxide (CO2) flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon dioxide flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Carbon dioxide (CO2) storage flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon dioxide storage flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Carbon dioxide (CO2), raw data from sensor&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon dioxide, transducer signal&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;C:N (molar)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon to Nitrogen molar ratio&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Inorganic Carbon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon, dissolved inorganic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Organic Carbon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon, dissolved organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Total (Organic+Inorganic) Carbon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon, dissolved total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Suspended Inorganic Carbon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon, suspended inorganic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;DEPRECATED -- The use of this term is discouraged in favor of the use of the synonymous term "Carbon, particulate organic".&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon, suspended organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Suspended Total (Organic+Inorganic) Carbon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon, suspened total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total (Dissolved+Particulate) Carbon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total (Dissolved+Particulate) Inorganic Carbon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon, total inorganic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total (Dissolved+Particulate) Organic Carbon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon, total organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chloride (Cl-)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chloride&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chlorophyll (a+b+c)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chlorophyll (a+b+c)&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chlorophyll a&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chlorophyll a&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The phytoplankton pigment Chlorophyll a allomer&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chlorophyll a allomer&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chlorophyll b&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chlorophyll b&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chlorophyll c&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chlorophyll c&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chlorophyll c1 and c2&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chlorophyll c1 and c2&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chlorophyll Fluorescence&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chlorophyll fluorescence&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Trivalent Chromium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chromium (III)&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Hexavalent Chromium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chromium (VI)&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chromium, all forms&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chromium, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Carbonate ion (CO3-2) concentration&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbonate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chemical oxygen demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;COD&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Fecal Coliform&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Coliform, fecal&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Coliform&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Coliform, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Color in quantified in color units&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Color&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The concentration of colored dissolved organic matter (humic substances)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Colored dissolved organic matter&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The identifying number for a water sampler container.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Container number&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Copper (Cu)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Copper&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The chlorophyll a concentration contributed by cryptophytes&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cryptophytes&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dew point temperature&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Temperature, dew point&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The phytoplankton pigment Diadinoxanthin&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Diadinoxanthin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The phytoplankton pigment Diatoxanthin&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Diatoxanthin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The chlorophyll a concentration contributed by Dinoflagellates&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Dinoflagellates&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Discharge&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Discharge&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Escherichia coli&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;E-coli&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Evaporation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Evaporation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Evapotranspiration&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Evapotranspiration&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The amount of water that could be evaporated and transpired if there was sufficient water available.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Evapotranspiration, potential&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A counter which counts the number of  datalogger flash memory errors&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Flash memory error count&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Friction velocity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Friction velocity&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Water level with regard to an arbitrary gage datum (also see Water depth for comparison)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Gage height&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Water Flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Water flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Carbonate hardness also known as temporary hardness&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Hardness, carbonate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Non-carbonate hardness&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Hardness, non-carbonate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total hardness&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Hardness, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Iron sulfide (FeS2)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Iron sulfide&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Ferric Iron (Fe+3)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Iron, ferric&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Ferrous Iron (Fe+2)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Iron, ferrous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Latent Heat Flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Latent heat flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Latitude as a variable measurement or observation (Spatial reference to be designated in methods).  This is distinct from the latitude of a site which is a site attribute.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Latitude&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Lead (Pb)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Lead&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The effect of moisture settling on the surface of a leaf as a result of either condensation or rainfall.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Leaf wetness&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Light attenuation coefficient&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Light attenuation coefficient&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Longitude as a variable measurement or observation (Spatial reference to be designated in methods). This is distinct from the longitude of a site which is a site attribute.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Longitude&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A counter of the number of times the battery voltage dropped below a minimum threshold&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Low battery count&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Langelier Saturation Index is an indicator of the degree of saturation of water with respect to calcium carbonate&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;LSI&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Magnesium (Mg)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Magnesium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Manganese (Mn)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Manganese&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Mercury (Hg)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Mercury&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Methylmercury (CH3Hg)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Methylmercury&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Molybdenum (Mo)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Molybdenum&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Momentum flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Momentum flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Albuminoid Nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;N, albuminoid&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved inorganic nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, dissolved inorganic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Organic Nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, dissolved organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Gaseous Nitrogen (N2)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, gas&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Inorganic Nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, inorganic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total (free+ionized) Ammonia&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, NH3 + NH4&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Free Ammonia (NH3)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, NH3&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Ammonium (NH4)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, NH4&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Nitrate (NO3) Nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, nitrate (NO3)&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Nitrite (NO2) + Nitrate (NO3) Nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, nitrite (NO2) + nitrate (NO3)&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Nitrite (NO2) Nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, nitrite (NO2)&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Organic Nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Particulate Organic Nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, particulate organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Nitrogen (NO3+NO2+NH4+NH3+Organic)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Kjeldahl Nitrogen (Ammonia+Organic)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, total kjeldahl&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved oxygen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Oxygen, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved oxygen, percent saturation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Oxygen, dissolved percent of saturation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved oxygen, raw data from sensor&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Oxygen, dissolved, transducer signal&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The phytoplankton pigment Peridinin&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Peridinin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;pH is the measure of the acidity or alkalinity of a solution. pH is formally a measure of the activity of dissolved hydrogen ions (H+).  Solutions in which the concentration of H+ exceeds that of OH- have a pH value lower than 7.0 and are known as acids.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;pH&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Pheophytin (Chlorophyll which has lost the central Mg ion) is a degradation product of Chlorophyll&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Pheophytin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Inorganic Phosphorus&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, inorganic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Organic Phosphorus&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Orthophosphate Phosphorus&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, orthophosphate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Phosphate phosphorus&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, phosphate (PO4)&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Polyphosphate Phosphorus&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, polyphosphate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Phosphorus&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Potassium (K)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Potassium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Precipitation such as rainfall. Should not be confused with settling.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Precipitation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Primary Productivity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Primary productivity&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A unique data recorder program identifier which is useful for knowing when the source code in the data recorder has been modified.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Program signature&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Incoming Longwave Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, incoming longwave&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Incoming Photosynthetically-Active Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, incoming PAR&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The ratio of reflected to incident light.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Albedo&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Water depth averaged over a channel cross-section or water body.  Averaging method to be specified in methods.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Water depth, averaged&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Water level relative to datum. The datum may be local or global such as NGVD 1929 and should be specified in the method description for associated data values.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Water level&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Water vapor density&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Water vapor density&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Wind direction&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wind direction&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Wind speed&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wind speed&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The phytoplankton pigment Zeaxanthin&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Zeaxanthin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Zinc (Zn)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Zinc&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Fluoride - F-&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Fluoride&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Bromide&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Bromide&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Permittivity is a physical quantity that describes how an electric field affects, and is affected by a dielectric medium, and is determined by the ability of a material to polarize in response to the field, and thereby reduce the total electric field inside the material. Thus, permittivity relates to a material's ability to transmit (or "permit") an electric field.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Permittivity&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Water potential is the potential energy of water relative to pure free water (e.g. deionized water) in reference conditions. It quantifies the tendency of water to move from one area to another due to osmosis, gravity, mechanical pressure, or matrix effects including surface tension.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Water potential&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Flow rate from well while pumping&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Well flow rate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The pressure exerted by the fluid at the wellhead or casinghead after the well has been shut off for a period of time, typically 24 hours&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wellhead pressure&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total dissolved phosphorus&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, total dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total dissolved nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, total dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chlorphyll a corrected for pheophytin&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chlorophyll a, corrected for pheophytin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chlorophyll a uncorrected for pheophytin&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chlorophyll a, uncorrected for pheophytin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Oxidation-reduction potential&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Reduction potential&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Particulate phosphorus&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, particulate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sodium (Na)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sodium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Carbon dioxide&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon dioxide&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Deuterium (2H), Delta D&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Deuterium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;18 O, Delta O&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Oxygen-18&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Alkalinity, carbonate plus bicarbonate&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Alkalinity, carbonate plus bicarbonate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Lithium (Li)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Lithium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Difference in the 15N:14N ratio between the sample and standard&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen-15, stable isotope ratio delta&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Distance measured from a sensor to a target object such as the surface of a water body or snow surface.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Distance&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Electric Power&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Electric Power&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Electric Energy&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Electric Energy&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Density&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Density&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Voltage or Electrical Potential&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Voltage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Electrical conductivity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Electrical conductivity&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Soil reponse of a reflected standing electromagnetic wave of a particular frequency which is related to the stored energy within the medium.  This is the real portion of the complex dielectric constant.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Real dielectric constant&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Soil reponse of a reflected standing electromagnetic wave of a particular frequency which is related to the dissipation (or loss) of energy within the medium. This is the imaginary portion of the complex dielectric constant.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Imaginary dielectric constant&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total solid phase carbon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon, total solid phase&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Ground heat flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Ground heat flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Classification of material encountered by a driller at various depths during the drilling of a well and recorded in the borehole log.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Borehole log material classification&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Ozone (O3)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Ozone&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total amount of outgoing radiation from all frequencies&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, total outgoing&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Net respiration&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Respiration, net&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total biomass&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Biomass, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Hydrogen sulfide (H2S)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Hydrogen sulfide&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Ammonium (NH4) flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Ammonium flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Oxygen (O2) flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Oxygen flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Phosphate (PO4) flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, phosphate flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Aluminium (Al)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Aluminium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Arsenic (As)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Arsenic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Cobalt (Co)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cobalt&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Iron (Fe)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Iron, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Nickel (Ni)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nickel&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Antimony (Sb)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Antimony&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Selenium (Se)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Selenium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Chromium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chromium, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Incoming Shortwave Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, incoming shortwave&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Incoming Ultraviolet A Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, incoming UV-A&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Incoming Ultraviolet B Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, incoming UV-B&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Net Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, net&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Net Longwave Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, net longwave&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Net Photosynthetically-Active Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, net PAR&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Net Shortwave radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, net shortwave&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Outgoing Longwave Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, outgoing longwave&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Outgoing Photosynthetically-Active Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, outgoing PAR&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Outgoing Shortwave Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, outgoing shortwave&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Shortwave Radiation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, total shortwave&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A code used to identifier a data recorder.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Recorder code&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Relative humidity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Relative humidity&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Salinity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Salinity&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Secchi depth&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Secchi depth&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sensible Heat Flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sensible heat flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A counter of events in a sequence&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sequence number&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Signal-to-noise ratio (often abbreviated SNR or S/N) is defined as the ratio of a signal power to the noise power corrupting the signal. The higher the ratio, the less obtrusive the background noise is.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Signal-to-noise ratio&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Silica (SiO2)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Silica&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Silicate.  Chemical compound containing silicon, oxygen, and one or more metals, e.g., aluminum, barium, beryllium, calcium, iron, magnesium, manganese, potassium, sodium, or zirconium.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Silicate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Silicon (Si)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Silicon&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Snow depth&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Snow depth&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The depth of water if a snow cover is completely melted, expressed in units of depth, on a corresponding horizontal surface area.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Snow water equivalent&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sodium adsorption ratio&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sodium adsorption ratio&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sodium plus potassium&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sodium plus potassium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sodium, fraction of cations&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sodium, fraction of cations&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Fixed Dissolved Solids&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Solids, fixed dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Fixed Suspended Solids&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Solids, fixed suspended&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Solids&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Solids, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Dissolved Solids&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Solids, total dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Fixed Solids&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Solids, total fixed&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Suspended Solids&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Solids, total suspended&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Volatile Solids&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Solids, total volatile&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Volatile Dissolved Solids&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Solids, volatile dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Volatile Suspended Solids&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Solids, volatile suspended&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Specific conductance&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Specific conductance&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The volume of water flowing past a fixed point.  Equivalent to discharge&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Streamflow&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Fecal Streptococci&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Streptococci, fecal&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sulfate (SO4)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sulfate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sulfur (S)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sulfur&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sulfur dioxide (SO2)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sulfur dioxide&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Organic Sulfur&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sulfur, organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Pyritic Sulfur&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sulfur, pyritic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Sunshine duration&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sunshine duration&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A counter which counts the number of datalogger table overrun errors&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Table overrun error count&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Time domain reflextometry, apparent length divided by probe length. Square root of dielectric&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;TDR waveform relative length&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Temperature&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Temperature&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Temperature, raw data from sensor&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Temperature, transducer signal&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Transpiration&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Transpiration&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Carlson Trophic State Index is a measurement of eutrophication based on Secchi depth&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;TSI&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Turbidity&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Turbidity&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The pressure of a vapor in equilibrium with its non-vapor phases&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Vapor pressure&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The difference between the actual water vapor pressure and the saturation of water vapor pressure at a particular temperature.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Vapor pressure deficit&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The velocity of a substance, fluid or object&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Velocity&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Visibility&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Visibility&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Volume. To quantify discharge or hydrograph volume or some other volume measurement.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Volume&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Volume of liquid water relative to bulk volume. Used for example to quantify soil moisture&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Volumetric water content&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A counter which counts the number of total datalogger watchdog errors&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Watchdog error count&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Water depth is the distance between the water surface and the bottom of the water body at a specific location specified by the site location and offset.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Water depth&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Difference in the 18O:16O ratio between the sample and standard&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Oxygen-18, stable isotope ratio delta&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Difference in the  2H:1H ratio between the sample and standard&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Hydrogen-2, stable isotope ratio delta&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved orthophosphate phosphorus&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, orthophosphate dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Parameter related to a hydrologic process.  An example usage would be for a starge-discharge relation parameter.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Parameter&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Position of an element that interacts with water such as reservoir gates&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Position&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The number of fish identified by the detection equipment&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Fish detections&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Urea ((NH2)2CO)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Urea&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Urea ((NH2)2CO) flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Urea flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Strontium (Sr)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Strontium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Fluorine (F-)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Fluorine&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Chlorine (Cl)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chlorine&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Bromine (Br)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Bromine&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The length of flow of air past a point over a time interval. Windspeed times the interval of time.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wind Run&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total amount of incoming radiation from all frequencies&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Radiation, total incoming&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Particulate organic carbon in suspension&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon, particulate organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Pressure&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Pressure, absolute&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Pressure relative to the local atmospheric or ambient pressure&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Pressure, gauge&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Hydrated silica (SiO2 nH20)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Biogenic silica&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Hydrated silica disolved in water&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Silicic acid&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Silicate acid (H4SiO4) flux&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Silicic acid flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The effect of wind on the temperature felt on human skin.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wind chill&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The combination effect of heat and humidity on the temperature felt by people.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Heat index&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Solar radiation, direct and diffuse, received from a solid angle of 2p steradians on a horizontal surface. 
Source: World Meteorological Organization, Meteoterm&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Global Radiation&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Measurement of phytoplankton with no differentiation between species&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phytoplankton&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Enterococcal bacteria&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Enterococci&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved nitrite (NO2) nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, dissolved nitrite (NO2)&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved nitrite (NO2) + nitrate (NO3) nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, dissolved nitrite (NO2) + nitrate (NO3)&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total petroleum hydrocarbon&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Petroleum hydrocarbon, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Carbon disulfide (CS2)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon disulfide&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;1-day Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD1&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Weather conditions&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Weather conditions&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Tidal stage&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Tide stage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The battery temperature of a datalogger or sensing system&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Battery Temperature&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Carbon tetrachloride (CCl4)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Carbon tetrachloride&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total (dissolved + particulate) organic nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, total organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved nitrate (NO3) nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, dissolved nitrate (NO3)&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Kjeldahl (organic nitrogen + ammonia (NH3) + ammonium (NH4))nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, dissolved Kjeldahl&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Organic Kjeldahl (organic nitrogen + ammonia (NH3) + ammonium (NH4)) nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen, organic kjeldahl&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;3-day Carbonaceous Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD3, carbonaceous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;7-day Carbonaceous Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD7, carbonaceous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;20-day Carbonaceous Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD20, carbonaceous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;2-day Carbonaceous Biochemical Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD2, carbonaceous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;4-day Carbonaceous Biological Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD4, carbonaceous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;6-day Carbonaceous Biological Oxygen Demand&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;BOD6, carbonaceous&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Thallium (Tl)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Thallium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Batis maritima&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Batis maritima Coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Borrichia frutescens&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Borrichia frutescens Coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Distichlis spicata&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Distichlis spicata Coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Limonium nashii&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Limonium nashii Coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Lycium carolinianum&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Lycium carolinianum Coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Monanthochloe littoralis&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Monanthochloe littoralis Coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Salicornia bigelovii&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Salicornia bigelovii coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Salicornia virginica&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Salicornia virginica coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Spartina alterniflora&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Spartina alterniflora coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;15 Nitrogen, Delta Nitrogen&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nitrogen-15&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Odor&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Odor&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Spartina spartinea&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Spartina spartinea coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Suaeda linearis&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Suaeda linearis coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Suaeda maritima&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Suaeda maritima coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Cuscuta spp.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cuscuta spp. coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Iva frutescens&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Iva frutescens coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of the plant Asteridae&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Asteridae coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of no vegetation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;No vegetation coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of dead vegetation&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wrack coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Areal coverage of transient species&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Transient species coverage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Zooplanktonic organisms, non-specific&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Zooplankton&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Area of a measurement location&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Area&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Benthic species&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Benthos&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Speed of gusts of wind&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wind gust speed&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Barium (Ba)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Barium, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Strontium (Sr)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Strontium, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total Chloride (Cl-)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chloride, total&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Methane (CH4)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Methane, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Ethane (C2H6)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Ethane, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The THSW Index uses temperature, humidity, solar radiation, and wind speed to calculate an apparent temperature.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;THSW Index&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The THW Index uses temperature, humidity, and wind speed to calculate an apparent temperature.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;THW Index&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The height of a surface wave, measured as the difference in elevation between the wave crest and an adjacent trough.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wave height&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Reservoir water volume&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Reservoir storage&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Blue-green algae (cyanobacteria) with phycocyanin pigments&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Blue-green algae (cyanobacteria), phycocyanin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The portion of streamflow (discharge) that is supplied by groundwater sources.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Baseflow&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;A measure of the intensity of rainfall, calculated as the depth of water to fall over a given time period if the intensity were to remain constant over that time interval (in/hr, mm/hr, etc)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Rainfall rate&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Outgoing rate of heat energy transfer minus the incoming rate of heat energy transfer through a given area&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Net heat flux&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Drag or trangential force per unit area exerted on a surface by the adjacent layer of moving air&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wind stress&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Total mass of phytoplankton, per unit area or volume&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Biomass, phytoplankton&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Particulate organic phosphorus in suspension&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, particulate organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved organic phosphorus&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, dissolved organic&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Tin (Sn)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Tin&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Titanium (Ti)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Titanium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Uranium (U)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Uranium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Vanadium (V)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Vanadium&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Groundwater depth is the distance between the water surface and the ground surface at a specific location specified by the site location and offset.&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Groundwater Depth&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Silicon (Si)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Silicon, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Strontium (Sr)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Strontium, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Zinc (Zn)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Zinc, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Zircon (Zr)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Zircon, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Fluorine (Fl)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Fluorine, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Chlorine (Cl)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Chlorine, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Bromine (Br)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Bromine, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Sulfate (SO4)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sulfate, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Aluminum (Al)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Aluminum, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Barium (Ba)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Barium, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Calcium (Ca)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Calcium, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Cobalt (Co)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Cobalt, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Copper (Cu)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Copper, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Potassium (K)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Potassium, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Magnesium (Mg)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Magnesium, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Manganese (Mn)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Manganese, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Sodium (Na)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Sodium, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Nickel (Ni)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Nickel, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Dissolved Phosphorus (P)&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Phosphorus, dissolved&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Direction of gusts of wind&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VariableName&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Wind gust direction&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;The vertical datum is unknown&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VerticalDatum&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;Unknown&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;North American Vertical Datum of 1988&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VerticalDatum&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;NAVD88&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;National Geodetic Vertical Datum of 1929&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VerticalDatum&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;NGVD29&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
            &lt;a:Concept&gt;
               &lt;a:definition&gt;Mean Sea Level&lt;/a:definition&gt;
               &lt;a:inShceme&gt;VerticalDatum&lt;/a:inShceme&gt;
               &lt;a:prefLabel&gt;MSL&lt;/a:prefLabel&gt;
            &lt;/a:Concept&gt;
         &lt;/getAllTermsResult&gt;
      &lt;/getAllTermsResponse&gt;
   &lt;/s:Body&gt;
&lt;/s:Envelope&gt;
                </PRE>
                </div>
        </ul>
        

    </div>

   </div>

        
</asp:Content>
