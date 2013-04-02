Option Strict On
Imports Database
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml
Imports System.IO

<WebService(Namespace:="http://his.cuahsi.org/his/1.1/ws/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ODMCVService
    Inherits System.Web.Services.WebService

    'CUAHSI Observations Data Model Version 1.1 Controlled Vocabulary Web Service
    'This web service provides access to the master controlled vocabularies of the ODM Version 1.1.

#Region " Web Service Methods "

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the CensorCode Controlled Vocabulary.")> _
      Public Function GetCensorCodeCV() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM CensorCodeCV ORDER BY Term ASC")

        'Create the result string
        Result.Append("<GetCensorCodeCVResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<Term>" & Convert.ToString(objDataRow.Item("Term")) & "</Term>" _
                & "<Definition>" & Convert.ToString(objDataRow.Item("Definition")) & "</Definition>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetCensorCodeCVResponse>")

        Return Result.ToString

    End Function

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the DataType Controlled Vocabulary.")> _
      Public Function GetDataTypeCV() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM DataTypeCV ORDER BY Term ASC")

        'Create the result string
        Result.Append("<GetDataTypeCVResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<Term>" & Convert.ToString(objDataRow.Item("Term")) & "</Term>" _
                & "<Definition>" & Convert.ToString(objDataRow.Item("Definition")) & "</Definition>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetDataTypeCVResponse>")

        Return Result.ToString

    End Function

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the GeneralCategory Controlled Vocabulary.")> _
      Public Function GetGeneralCategoryCV() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM GeneralCategoryCV ORDER BY Term ASC")

        'Create the result string
        Result.Append("<GetGeneralCategoryCVResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<Term>" & Convert.ToString(objDataRow.Item("Term")) & "</Term>" _
                & "<Definition>" & Convert.ToString(objDataRow.Item("Definition")) & "</Definition>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetGeneralCategoryCVResponse>")

        Return Result.ToString

    End Function

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the SampleMedium Controlled Vocabulary.")> _
      Public Function GetSampleMediumCV() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM SampleMediumCV ORDER BY Term ASC")

        'Create the result string
        Result.Append("<GetSampleMediumCVResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<Term>" & Convert.ToString(objDataRow.Item("Term")) & "</Term>" _
                & "<Definition>" & Convert.ToString(objDataRow.Item("Definition")) & "</Definition>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetSampleMediumCVResponse>")

        Return Result.ToString

    End Function

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the SampleType Controlled Vocabulary.")> _
      Public Function GetSampleTypeCV() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM SampleTypeCV ORDER BY Term ASC")

        'Create the result string
        Result.Append("<GetSampleTypeCVResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<Term>" & Convert.ToString(objDataRow.Item("Term")) & "</Term>" _
                & "<Definition>" & Convert.ToString(objDataRow.Item("Definition")) & "</Definition>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetSampleTypeCVResponse>")

        Return Result.ToString

    End Function

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the TopicCategory Controlled Vocabulary.")> _
      Public Function GetTopicCategoryCV() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM TopicCategoryCV ORDER BY Term ASC")

        'Create the result string
        Result.Append("<GetTopicCategoryCVResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<Term>" & Convert.ToString(objDataRow.Item("Term")) & "</Term>" _
                & "<Definition>" & Convert.ToString(objDataRow.Item("Definition")) & "</Definition>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetTopicCategoryCVResponse>")

        Return Result.ToString

    End Function

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the ValueType Controlled Vocabulary.")> _
      Public Function GetValueTypeCV() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM ValueTypeCV ORDER BY Term ASC")

        'Create the result string
        Result.Append("<GetValueTypeCVResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<Term>" & Convert.ToString(objDataRow.Item("Term")) & "</Term>" _
                & "<Definition>" & Convert.ToString(objDataRow.Item("Definition")) & "</Definition>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetValueTypeCVResponse>")

        Return Result.ToString

    End Function

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the VariableName Controlled Vocabulary.")> _
      Public Function GetVariableNameCV() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM VariableNameCV ORDER BY Term ASC")

        'Create the result string
        Result.Append("<GetVariableNameCVResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<Term>" & Convert.ToString(objDataRow.Item("Term")) & "</Term>" _
                & "<Definition>" & Convert.ToString(objDataRow.Item("Definition")) & "</Definition>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetVariableNameCVResponse>")

        Return Result.ToString

    End Function

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the VerticalDatum Controlled Vocabulary.")> _
      Public Function GetVerticalDatumCV() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM VerticalDatumCV ORDER BY Term ASC")

        'Create the result string
        Result.Append("<GetVerticalDatumCVResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<Term>" & Convert.ToString(objDataRow.Item("Term")) & "</Term>" _
                & "<Definition>" & Convert.ToString(objDataRow.Item("Definition")) & "</Definition>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetVerticalDatumCVResponse>")

        Return Result.ToString

    End Function

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the SpatialReferences Controlled Vocabulary.")> _
      Public Function GetSpatialReferences() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM SpatialReferences ORDER BY SpatialReferenceID ASC")

        'Create the result string
        Result.Append("<GetSpatialReferencesResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<SpatialReferenceID>" & Convert.ToString(objDataRow.Item("SpatialReferenceID")) & "</SpatialReferenceID>" _
                & "<SRSID>" & Convert.ToString(objDataRow.Item("SRSID")) & "</SRSID>" _
                & "<SRSName>" & Convert.ToString(objDataRow.Item("SRSName")) & "</SRSName>" _
                & "<IsGeographic>" & Convert.ToString(objDataRow.Item("IsGeographic")) & "</IsGeographic>" _
                & "<Notes>" & Convert.ToString(objDataRow.Item("Notes")) & "</Notes>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetSpatialReferencesResponse>")

        Return Result.ToString

    End Function

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the Units Controlled Vocabulary.")> _
      Public Function GetUnits() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM Units ORDER BY UnitsID ASC")

        'Create the result string
        Result.Append("<GetUnitsResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<UnitsID>" & Convert.ToString(objDataRow.Item("UnitsID")) & "</UnitsID>" _
                & "<UnitsName>" & Convert.ToString(objDataRow.Item("UnitsName")) & "</UnitsName>" _
                & "<UnitsType>" & Convert.ToString(objDataRow.Item("UnitsType")) & "</UnitsType>" _
                & "<UnitsAbbreviation>" & Convert.ToString(objDataRow.Item("UnitsAbbreviation")) & "</UnitsAbbreviation>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetUnitsResponse>")

        Return Result.ToString

    End Function

    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the Speciation Controlled Vocabulary.")> _
      Public Function GetSpeciationCV() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM SpeciationCV ORDER BY Term ASC")

        'Create the result string
        Result.Append("<GetSpeciationCVResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<Term>" & Convert.ToString(objDataRow.Item("Term")) & "</Term>" _
                & "<Definition>" & Convert.ToString(objDataRow.Item("Definition")) & "</Definition>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetSpeciationCVResponse>")

        Return Result.ToString

    End Function
    <WebMethod(Description:="This method returns a string (formatted as XML) with all of the items in the SiteType Controlled Vocabulary.")> _
      Public Function GetSiteTypeCV() As String
        Dim Result As New Text.StringBuilder
        Dim objDataTable As Data.DataTable
        Dim objDataRow As Data.DataRow

        'Get the items in the controlled vocabulary from the database
        objDataTable = OpenTable("SELECT * FROM SiteTypeCV ORDER BY Term ASC")

        'Create the result string
        Result.Append("<GetSiteTypeCVResponse>")

        'Get the count of the records
        Result.Append("<Records count=" & """" & CStr(objDataTable.Rows.Count) & """" & ">")

        'Now create an element for each record
        For Each objDataRow In objDataTable.Select
            Result.Append("<Record>" _
                & "<Term>" & Convert.ToString(objDataRow.Item("Term")) & "</Term>" _
                & "<Definition>" & Convert.ToString(objDataRow.Item("Definition")) & "</Definition>" _
                & "</Record>")
        Next

        Result.Append("</Records></GetSiteTypeCVResponse>")

        Return Result.ToString

    End Function

#End Region

End Class
