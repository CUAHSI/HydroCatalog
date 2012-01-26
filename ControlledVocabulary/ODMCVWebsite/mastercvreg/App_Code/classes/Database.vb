Imports System.Data.SqlClient
Imports System.Configuration

Namespace MCVReg

Public Class Database

    Public Shared Sub ExecuteNonQuery(ByVal strSQL As String)
        ExecuteNonQuery("ODM_website", strSQL)
    End Sub

    Public Shared Sub ExecuteNonQuery(ByVal strDatabase As String, ByVal strSQL As String)
        Dim mobjSqlConnection As SqlConnection
        Dim mobjSqlCommand As SqlCommand

        mobjSqlConnection = New SqlConnection(ConnectionString(strDatabase))
        mobjSqlConnection.Open()
        mobjSqlCommand = New SqlCommand(strSQL, mobjSqlConnection)
        mobjSqlCommand.ExecuteNonQuery()
        mobjSqlConnection.Close()
    End Sub
    Public Shared Function OpenTable(ByVal strdatabase As String, ByVal strsql As String) As DataTable
        Dim mobjSqlConnection As SqlConnection
        Dim mobjSqlCommand As SqlCommand
        Dim mobjDataAdapter As SqlDataAdapter
        Dim objDataTable As DataTable

        objDataTable = New DataTable
        mobjSqlConnection = New SqlConnection(ConnectionString(strdatabase))
        mobjSqlConnection.Open()
        mobjSqlCommand = New SqlCommand(strsql, mobjSqlConnection)
        mobjDataAdapter = New SqlDataAdapter(mobjSqlCommand)
        mobjDataAdapter.Fill(objDataTable)

        mobjSqlConnection.Close()

        Return objDataTable
    End Function

    Public Shared Function ConnectionString(ByVal strDatabase As String) As String
        Dim strConnectionString As String

            strConnectionString = ConfigurationManager.ConnectionStrings(strDatabase).ConnectionString
            Return strConnectionString

        End Function
End Class

End Namespace
