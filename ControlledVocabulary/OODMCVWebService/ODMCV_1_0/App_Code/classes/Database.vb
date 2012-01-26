Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Database
    Private Shared Function OpenConnection() As SqlConnection
        'Original connection string for connecting to the old database server
        '--------------------------------------------------------------------
        'Dim strDataSource As String
        'If HttpContext.Current.Request.UserHostAddress = "127.0.0.1" Then
        '    strDataSource = "(local)"
        'Else
        '    strDataSource = "waterdata.uwrl.usu.edu"
        'End If

        'Dim strConnectionString As String = "Data Source=" & strDataSource & ";" & _
        ' "Initial Catalog=ODMCV;" & _
        ' "User Id=ODMWebService;" & _
        ' "Password=ODMWebService4U;"
        '---------------------------------------------------------------------

        Dim strConnectionString As String
        strConnectionString = ConfigurationManager.ConnectionStrings("ODMCVDatabase").ConnectionString

        Dim objSqlConnection As New SqlConnection(strConnectionString)
        objSqlConnection.Open()

        Return objSqlConnection
    End Function

    Public Shared Function OpenTable(ByVal objSqlCommand As SqlCommand) As DataTable
        Dim objSqlConnection As SqlConnection = OpenConnection()
        Dim objSqlDataAdapter As SqlDataAdapter
        Dim objDataTable As New DataTable

        objSqlCommand.Connection = objSqlConnection
        objSqlDataAdapter = New SqlDataAdapter(objSqlCommand)
        objSqlDataAdapter.Fill(objDataTable)
        objSqlConnection.Close()

        Return objDataTable
    End Function

    Public Shared Function OpenTable(ByVal strSQL As String) As DataTable
        Dim objSqlCommand As SqlCommand
        objSqlCommand = New SqlCommand(strSQL)

        Return OpenTable(objSqlCommand)
    End Function

    Public Shared Sub ExecuteNonQuery(ByVal objSqlCommand As SqlCommand)
        Dim objSqlConnection As SqlConnection = OpenConnection()

        objSqlCommand.Connection = objSqlConnection
        objSqlCommand.ExecuteNonQuery()
        objSqlConnection.Close()
    End Sub

    Public Shared Sub ExecuteNonQuery(ByVal strSQL As String)
        Dim objSqlCommand As SqlCommand

        objSqlCommand = New SqlCommand(strSQL)
        ExecuteNonQuery(objSqlCommand)
    End Sub
End Class
