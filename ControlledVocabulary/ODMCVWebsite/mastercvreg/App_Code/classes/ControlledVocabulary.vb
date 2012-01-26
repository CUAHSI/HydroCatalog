Option Strict On
Imports MCVReg.Database


Namespace MCVReg

Public Class ControlledVocabulary

    Private mstrTerm_ID As String
    Private mstrTableName As String
    Private mstrTempTableName As String
    Private mstrStatus As String
    Private mstrActionFlag As String
    Private mstrTimeStamp As String
    Private mstrReason As String
    Private mstrSubmitterName As String
    Private mstrSubmitterEmail As String
    Private mstrAdminNotes As String
    Private mstrColumns As String

    Public Sub New()
        mstrTerm_ID = Nothing
        mstrTableName = Nothing
        mstrTempTableName = Nothing
        mstrStatus = Nothing
        mstrActionFlag = Nothing
        mstrTimeStamp = Nothing
        mstrReason = Nothing
        mstrSubmitterName = Nothing
        mstrSubmitterEmail = Nothing
        mstrAdminNotes = Nothing
        mstrColumns = Nothing
    End Sub

    Public Sub New(ByVal tableName As String, ByVal timeStamp As String)

        Dim i_count As Integer

        Dim myCVTable As DataTable
        Dim curCol As DataColumn
        Dim curRow As DataRow

        myCVTable = OpenTable("ODMCV", "SELECT time_stamp, " _
        & "CASE action_flag " _
        & "WHEN 'A' THEN 'Add' " _
        & "WHEN 'E' THEN 'Edit' " _
        & "WHEN 'D' THEN 'Delete' END AS action_flag, " _
        & "name, email, reason, admin_notes " _
        & "FROM " & tableName & " " _
        & "WHERE status = 'submitted' AND action_flag <> 'O' AND convert(varchar,time_stamp,109) = '" & timeStamp & "' " _
        & "ORDER BY action_flag DESC")

        If myCVTable.Rows.Count > 0 Then
            curRow = myCVTable.Rows(0)
            mstrTimeStamp = CStr(curRow.Item("time_stamp"))
            mstrActionFlag = CStr(curRow.Item("action_flag"))
            mstrSubmitterName = CStr(curRow.Item("name"))
            mstrSubmitterEmail = CStr(curRow.Item("email"))
            mstrReason = CStr(curRow.Item("reason"))
        End If

        mstrTempTableName = tableName
        mstrTableName = Right(tableName, Len(tableName) - 5)
    End Sub

    Property Term_ID() As String
        Get
            Return mstrTerm_ID
        End Get
        Set(ByVal strTerm_ID As String)
            mstrTerm_ID = strTerm_ID
        End Set
    End Property

    Property TableName() As String
        Get
            Return mstrTableName
        End Get
        Set(ByVal strTableName As String)
            mstrTableName = strTableName
        End Set
    End Property

    Property TempTableName() As String
        Get
            Return mstrTempTableName
        End Get
        Set(ByVal strTempTableName As String)
            mstrTempTableName = strTempTableName
        End Set
    End Property

    Property Status() As String
        Get
            Return mstrStatus
        End Get
        Set(ByVal strStatus As String)
            mstrStatus = strStatus
        End Set
    End Property

    Property ActionFlag() As String
        Get
            Return mstrActionFlag
        End Get
        Set(ByVal strActionFlag As String)
            mstrActionFlag = strActionFlag
        End Set
    End Property

    Property TimeStamp() As String
        Get
            Return mstrTimeStamp
        End Get
        Set(ByVal strTimeStamp As String)
            mstrTimeStamp = strTimeStamp
        End Set
    End Property

    Property Reason() As String
        Get
            Return mstrReason
        End Get
        Set(ByVal strReason As String)
            mstrReason = strReason
        End Set
    End Property

    Property SubmitterName() As String
        Get
            Return mstrSubmitterName
        End Get
        Set(ByVal strSubmitterName As String)
            mstrSubmitterName = strSubmitterName
        End Set
    End Property

    Property SubmitterEmail() As String
        Get
            Return mstrSubmitterEmail
        End Get
        Set(ByVal strSubmitterEmail As String)
            mstrSubmitterEmail = strSubmitterEmail
        End Set
    End Property

    Property AdminNotes() As String
        Get
            Return mstrAdminNotes
        End Get
        Set(ByVal strAdminNotes As String)
            mstrAdminNotes = strAdminNotes
        End Set
    End Property

    Property Columns() As String
        Get
            Return mstrColumns
        End Get
        Set(ByVal strColumns As String)
            mstrColumns = strColumns
        End Set
    End Property
End Class

End Namespace
