Imports MCVReg.Database


Namespace MCVReg

Partial Class admindefault
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgAdmin As System.Web.UI.WebControls.DataGrid


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        If Session.Item("login") <> "true" Then
            Response.Redirect("login.aspx")
        End If

        Dim tableNames As DataTable
        Dim myTable As DataTable
        Dim curRow As DataRow
        Dim curCol As DataColumn
        Dim myBoundCol As BoundColumn
        Dim tblRow As TableRow
        Dim tblCol As TableCell
        Dim i_count As Integer
        Dim myLbl As Label
        Dim strColumns As String
        Dim columnTable As DataTable
        Dim curColRow As DataRow

        tableNames = OpenTable("ODMCV", "SELECT name, id FROM sysobjects " _
            & "WHERE xtype = 'U' AND name LIKE 'temp_%' AND name <> 'temp_CVTESTER'")

        i_count = 1
        If tableNames.Rows.Count > 0 Then
            For Each curRow In tableNames.Rows
                Dim tempDG As DataGrid
                columnTable = OpenTable("ODMCV", "SELECT name FROM syscolumns WHERE id = " & CStr(curRow.Item(1)) _
                    & " AND name <> 'status' AND name <> 'action_flag' AND name <> 'time_stamp'")

                strColumns = "status"
                For Each curColRow In columnTable.Rows
                    strColumns = strColumns & "," & CStr(curColRow.Item(0))
                Next
                curColRow = columnTable.Rows(0)

                myTable = OpenTable("ODMCV", "SELECT " _
                    & "'<a href=" & Chr(34) & "viewCV.aspx?act=' + action_flag + '&tbl=" _
                        & CStr(curRow.Item(0)) & "&tblid=" & CStr(curRow.Item(1)) _
                        & "&id=' + convert(varchar," & CStr(curColRow.Item(0)) & ") + '&time=' + " _
                        & "convert(varchar,time_stamp,109) + '" & Chr(34) & ">' + convert(varchar,time_stamp,109) " _
                        & "+ '</a>' as [&nbsp;], " _
                    & "name as Submitter, '<a href=" & Chr(34) & "mailto:'+email+'" & Chr(34) & ">'+email+'</a>' AS [Email Address], reason as Reason, " _
                    & "CASE action_flag " _
                        & "WHEN 'A' THEN 'Add' " _
                        & "WHEN 'O' THEN 'Edit' " _
                        & "WHEN 'D' THEN 'Delete' END AS [Requested Change], " _
                        & curColRow.Item(0) & " AS [ID/Term Affected] " _
                        & "FROM " & CStr(curRow.Item(0)) & " WHERE status = 'submitted' AND action_flag <> 'E'")

                If myTable.Rows.Count > 0 Then
                    tempDG = New DataGrid
                    tempDG.ID = "dg" & Convert.ToString(i_count)
                    tempDG.CellPadding = 8
                    tempDG.CssClass = "CVDataGridStyle"
                    tempDG.HeaderStyle.CssClass = "DGHeader"
                    tempDG.AlternatingItemStyle.CssClass = "DGAltItem"
                    tempDG.AutoGenerateColumns = False

                    myLbl = New Label
                    myLbl.Text = "<h4>" & Right(CStr(curRow.Item(0)), Len(CStr(curRow.Item(0))) - 5) & "</h4>"

                    For Each curCol In myTable.Columns
                        If curCol.ColumnName <> "status" Then
                            myBoundCol = New BoundColumn
                            myBoundCol.HeaderText = curCol.ColumnName
                            myBoundCol.DataField = curCol.ColumnName
                            tempDG.Columns.Add(myBoundCol)
                        End If
                    Next

                    tempDG.DataSource = myTable
                    tempDG.DataBind()

                    'CV table name:
                    tblRow = New TableRow
                    tblCol = New TableCell
                    tblCol.Controls.Add(myLbl)
                    tblRow.Cells.Add(tblCol)
                    tbl1.Rows.Add(tblRow)

                    'CV datagrid:
                    tblRow = New TableRow
                    tblCol = New TableCell
                    tblCol.Controls.Add(tempDG)
                    tblRow.Cells.Add(tblCol)
                    tbl1.Rows.Add(tblRow)

                    'Space between tables:
                    tblRow = New TableRow
                    tblCol = New TableCell
                    tblCol.Text = "&nbsp;"
                    tblRow.Cells.Add(tblCol)
                    tbl1.Rows.Add(tblRow)

                    i_count = i_count + 1
                End If
            Next
        End If

    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

End Namespace
