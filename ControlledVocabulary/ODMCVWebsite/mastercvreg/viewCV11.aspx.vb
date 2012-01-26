Imports System.Web.Mail
Imports MCVReg.Database
Imports MCVReg.Functions


Namespace MCVReg

Partial Class viewCV11
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Dim strTable As String
    Dim strTableID As String
    Dim strID As String
    Dim strDate As String
    Dim strAction As String
    Dim strUpdateQuery As String
    Dim strChangeInfo As String
    Public Shared myCV11 As ControlledVocabulary11

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        If Session.Item("login") <> "true" Then
            Response.Redirect("login11.aspx")
        End If

        Dim i_count As Integer
        Dim curRow As DataRow
        Dim curCell As DataColumn
        Dim curCol As DataColumn
        Dim curLbl As Label
        Dim curTxt As TextBox
        Dim curEditTxt As TextBox
        Dim curDdl As DropDownList
        Dim mobjDataTable As DataTable
        Dim tempTable As DataTable
        Dim tempRow As DataRow

        Dim columnTable As DataTable
        Dim curColRow As DataRow
        Dim myCV11Table As DataTable

        Dim strColumns As String
        Dim myBoundCol As BoundColumn

        strTable = Request.QueryString("tbl")
        strTableID = Request.QueryString("tblid")
        strID = Request.QueryString("id")
        strDate = Request.QueryString("time")
        strAction = Request.QueryString("act")

        myCV11 = New ControlledVocabulary11(strTable, strDate)

        'Retrieve all of the rows that will update the controlled vocabulary:
        columnTable = OpenTable("ODMCV_1_1", "SELECT t1.[name] AS name, t2.[name] AS type, t1.length " _
            & "FROM dbo.syscolumns t1 JOIN dbo.systypes t2 ON t1.xtype = t2.xusertype " _
            & "WHERE ID = " & strTableID _
            & " AND t1.[name] <> 'status' AND t1.[name] <> 'action_flag' AND t1.[name] <> 'time_stamp' " _
            & "AND t1.[name] <> 'reason' AND t1.[name] <> 'name' AND t1.[name] <> 'email' AND t1.[name] <> 'admin_notes'")

        curColRow = columnTable.Rows(0)

        myCV11.Term_ID = CStr(curColRow.Item(0))
        myCV11.Columns = CStr(curColRow.Item(0))
        myCV11.TableName = Right(strTable, Len(strTable) - 5)
        myCV11.TempTableName = strTable
        myCV11.Status = "submitted"

        i_count = 1
        For Each curColRow In columnTable.Rows
            If i_count <> 1 Then
                myCV11.Columns &= "," & CStr(curColRow.Item(0))
            End If
            i_count = 2
        Next
        curColRow = columnTable.Rows(0)

        myCV11Table = OpenTable("ODMCV_1_1", "SELECT " _
                                        & myCV11.Columns & " " _
                                        & "FROM " _
                                        & myCV11.TempTableName & " " _
                                        & "WHERE status = 'submitted' " _
                                            & "AND convert(varchar,time_stamp,109) = '" & strDate & "' " _
                                        & "ORDER BY action_flag DESC")

        Select Case strAction
            Case "A"
                lblTableName.Text = "Add controlled vocabulary to " & myCV11.TableName
                i_count = 1
                If columnTable.Rows.Count > 0 Then
                    For Each curRow In columnTable.Rows
                        'Data entry section:
                        curLbl = Form1.FindControl("lbl" & Convert.ToString(i_count))
                        If curRow.Item("name") = "IsGeographic" Then
                            ddl2.Visible = True
                            reg1.Enabled = True
                        Else
                            curEditTxt = Form1.FindControl("txtEdit" & Convert.ToString(i_count))

                            'kats
                            'curEditTxt.MaxLength = curRow.Item("length")
                            curEditTxt.MaxLength = (curRow.Item("length") / 2)
                            If curRow.Item("name") = "Definition" Or curRow.Item("name") = "Notes" Then
                                'curEditTxt.MaxLength = 1000
                                curEditTxt.TextMode = TextBoxMode.MultiLine
                                curEditTxt.Rows = 3

                            Else
                                'curEditTxt.MaxLength = curRow.Item("length")
                                If curRow.Item("length") > 100 Then
                                    curEditTxt.TextMode = TextBoxMode.MultiLine
                                    curEditTxt.Rows = 3
                                End If
                            End If

                            If curRow.Item("type") = "int" And i_count = 1 Then
                                ' curEditTxt.ReadOnly = True
                                curEditTxt.Enabled = False
                            End If
                            curEditTxt.Text = ""
                            curEditTxt.Visible = True
                        End If
                        curLbl.Text = curRow.Item("name")
                        curLbl.Visible = True
                        i_count = i_count + 1

                    Next
                End If

                i_count = 1
                curRow = myCV11Table.Rows(0)
                For Each curCell In myCV11Table.Columns
                    If curCell.ColumnName = "IsGeographic" Then
                        If curRow.Item(i_count - 1) = "True" Then
                            ddl2.SelectedIndex = 0
                        Else
                            ddl2.SelectedIndex = 1
                        End If
                        ddl2.Visible = True
                    Else
                        curEditTxt = Form1.FindControl("txtEdit" & Convert.ToString(i_count))
                        If Not curRow.Item(i_count - 1) Is System.DBNull.Value Then
                            curEditTxt.Text = curRow.Item(i_count - 1)
                        End If
                    End If
                    i_count = i_count + 1
                Next

            Case "O"
                lblTableName.Text = "Edit controlled vocabulary in " & myCV11.TableName
                lblHeader1.Text = "Original"
                lblHeader2.Text = "New"
                i_count = 1
                If columnTable.Rows.Count > 0 Then
                    For Each curRow In columnTable.Rows
                        'Data entry section:
                        curLbl = Form1.FindControl("lbl" & Convert.ToString(i_count))
                        If curRow.Item("name") = "IsGeographic" Then
                            ddl1.Visible = True
                            ddl2.Visible = True
                            reg1.Enabled = True
                        Else
                            curTxt = Form1.FindControl("txt" & Convert.ToString(i_count))
                            curEditTxt = Form1.FindControl("txtEdit" & Convert.ToString(i_count))
                            'kats
                            'curEditTxt.MaxLength = curRow.Item("length")
                            'curTxt.MaxLength = curRow.Item("length")
                            curEditTxt.MaxLength = (curRow.Item("length") / 2)
                            curTxt.MaxLength = (curRow.Item("length") / 2)
                            If curRow.Item("name") = "Definition" Or curRow.Item("name") = "Notes" Then
                                'curEditTxt.MaxLength = 1000
                                'curTxt.MaxLength = 1000
                                curTxt.TextMode = TextBoxMode.MultiLine
                                curTxt.Rows = 3
                                curEditTxt.TextMode = TextBoxMode.MultiLine
                                curEditTxt.Rows = 3
                            Else
                                'curEditTxt.MaxLength = curRow.Item("length")
                                'curTxt.MaxLength = curRow.Item("length")
                                If curRow.Item("length") > 100 Then
                                    curTxt.TextMode = TextBoxMode.MultiLine
                                    curTxt.Rows = 3
                                    curEditTxt.TextMode = TextBoxMode.MultiLine
                                    curEditTxt.Rows = 3
                                End If
                            End If

                            curTxt.Text = ""
                            curTxt.ReadOnly = True
                            curTxt.Visible = True
                        End If
                        curLbl.Text = curRow.Item("name")
                        curLbl.Visible = True

                        i_count = i_count + 1
                    Next
                End If
                i_count = 1
                For Each curRow In myCV11Table.Rows
                    If i_count = 1 Then
                        For Each curCell In myCV11Table.Columns
                            If curCell.ColumnName = "IsGeographic" Then
                                If curRow.Item(i_count - 1) = "True" Then
                                    ddl1.SelectedIndex = 0
                                Else
                                    ddl1.SelectedIndex = 1
                                End If
                            Else
                                curTxt = Form1.FindControl("txt" & Convert.ToString(i_count))
                                If Not curRow.Item(i_count - 1) Is System.DBNull.Value Then
                                    curTxt.Text = curRow.Item(i_count - 1)
                                End If
                            End If
                            i_count = i_count + 1
                        Next
                    Else
                        i_count = 1
                        For Each curCell In myCV11Table.Columns
                            If curCell.ColumnName = "IsGeographic" Then
                                If curRow.Item(i_count - 1) = "True" Then
                                    ddl2.SelectedIndex = 0
                                Else
                                    ddl2.SelectedIndex = 1
                                End If
                            Else
                                curEditTxt = Form1.FindControl("txtEdit" & Convert.ToString(i_count))
                                If Not curRow.Item(i_count - 1) Is System.DBNull.Value Then
                                    curEditTxt.Text = curRow.Item(i_count - 1)
                                    curEditTxt.Visible = True
                                    If IsNumeric(curRow.Item(i_count - 1)) And i_count = 1 Then
                                        curEditTxt.ReadOnly = True
                                    End If
                                End If
                            End If
                            i_count = i_count + 1
                        Next
                    End If
                Next

            Case "D"
                lblTableName.Text = "Delete controlled vocabulary from " & myCV11.TableName
                i_count = 1
                If columnTable.Rows.Count > 0 Then
                    For Each curRow In columnTable.Rows
                        'Data entry section:
                        curLbl = Form1.FindControl("lbl" & Convert.ToString(i_count))
                        If curRow.Item("name") = "IsGeographic" Then
                            ddl1.Visible = True
                        Else
                            curTxt = Form1.FindControl("txt" & Convert.ToString(i_count))

                            'kats
                            'curTxt.MaxLength = curRow.Item("length")
                            curTxt.MaxLength = (curRow.Item("length") / 2)
                            If curRow.Item("name") = "Definition" Or curRow.Item("name") = "Notes" Then
                                'curTxt.MaxLength = 1000
                                curTxt.TextMode = TextBoxMode.MultiLine
                                curTxt.Rows = 3
                            Else
                                'curTxt.MaxLength = curRow.Item("length")
                                If curRow.Item("length") > 100 Then
                                    curTxt.TextMode = TextBoxMode.MultiLine
                                    curTxt.Rows = 3
                                End If
                            End If

                            curTxt.Text = ""
                            curTxt.ReadOnly = True
                            curTxt.Visible = True
                        End If
                        curLbl.Text = curRow.Item("name")
                        curLbl.Visible = True

                        i_count = i_count + 1
                    Next
                End If
                i_count = 1
                For Each curRow In myCV11Table.Rows
                    For Each curCell In myCV11Table.Columns
                        If curCell.ColumnName = "IsGeographic" Then
                            If curRow.Item(i_count - 1) = "True" Then
                                ddl1.SelectedIndex = 0
                            Else
                                ddl1.SelectedIndex = 1
                            End If
                        Else
                            curTxt = Form1.FindControl("txt" & Convert.ToString(i_count))
                            If Not curRow.Item(i_count - 1) Is System.DBNull.Value Then
                                curTxt.Text = curRow.Item(i_count - 1)
                            End If
                        End If
                        i_count = i_count + 1
                    Next
                Next
        End Select

        req1.Enabled = True
        Select Case myCV11.TableName
            Case "QualityControlLevels"
                req3.Enabled = True
            Case "SpatialReferences"
                req2.Enabled = True
                req3.Enabled = True
            Case "Units"
                req2.Enabled = True
                req3.Enabled = True
                req4.Enabled = True
        End Select

        lblAction.Text = myCV11.ActionFlag
        lblSubmitter.Text = myCV11.SubmitterName
        lblEmail.Text = "<a href='mailto:" & myCV11.SubmitterEmail & "'>" & myCV11.SubmitterEmail & "</a>"
        lblEmailAddress.Text = myCV11.SubmitterEmail
        lblReason.Text = myCV11.Reason

    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        Dim item As DataGridItem
        Dim item2 As DataGridItem
        Dim strItem As String
        Dim i_count As Integer
        Dim checkTable As DataTable
        Dim strConflict As String

        Dim curControl As Control
        Dim curTxt As TextBox
        Dim curEditTxt As TextBox
        Dim curLbl As Label
        Dim updateFields As String, editField As String
        Dim action_flag As String
        Dim time_stamp As DateTime
        Dim strValues As String
        Dim strID As String

        If strAction = "A" Then
            strID = txtEdit1.Text
        Else
            strID = txt1.Text
        End If

        i_count = 1

        Try
            For Each curControl In pnl1.Controls
                If curControl.GetType.ToString.Equals("System.Web.UI.WebControls.TextBox") And curControl.Visible = True Then
                    If strAction = "D" Then
                        curTxt = curControl.FindControl("txt" & Convert.ToString(i_count))
                    Else
                        curTxt = curControl.FindControl("txtEdit" & Convert.ToString(i_count))
                        curEditTxt = curControl.FindControl("txt" & Convert.ToString(i_count))
                    End If
                    curLbl = curControl.FindControl("lbl" & Convert.ToString(i_count))
                    If Not curTxt Is Nothing Then
                        If curTxt.Visible = True Then
                            If (myCV11.TableName = "Units" Or myCV11.TableName = "SpatialReferences" Or myCV11.TableName = "QualityControlLevels") And i_count = 1 Then
                                updateFields = updateFields & FormatForSQL(curTxt.Text) & ","
                                editField = editField & FormatForSQL(curTxt.Text) & ","
                                strValues = strValues & curLbl.Text & " = " & FormatForSQL(curTxt.Text) & ","
                            Else
                                updateFields = updateFields & "'" & FormatForSQL(curTxt.Text) & "',"
                                editField = editField & "'" & FormatForSQL(curTxt.Text) & "',"
                                strValues = strValues & curLbl.Text & " = '" & FormatForSQL(curTxt.Text) & "',"
                            End If
                            i_count = i_count + 1
                        End If
                    End If
                ElseIf curControl.GetType.ToString.Equals("System.Web.UI.WebControls.DropDownList") And curControl.Visible = True Then
                    If curControl.ID <> "ddl1" Then
                        curLbl = curControl.FindControl("lbl" & Convert.ToString(i_count))
                        updateFields = updateFields & "'" & FormatForSQL(ddl2.SelectedValue) & "',"
                        editField = editField & "'" & FormatForSQL(ddl2.SelectedValue) & "',"
                        strValues = strValues & curLbl.Text & " = " & FormatSQLString(ddl2.SelectedValue) & ","
                        i_count = i_count + 1
                    End If
                End If
            Next
        Catch ex As Exception
            EmailNotifications("error", "11", ex.Message & ", " & ex.StackTrace)
        End Try

        updateFields = Left(updateFields, (Len(updateFields) - 1))
        editField = Left(editField, (Len(editField) - 1))
        strValues = Left(strValues, (Len(strValues) - 1))

        strConflict = strID

        Build_Change_Info_String()

        Select Case strAction
            Case "A"
                strUpdateQuery = "INSERT INTO " & Right(strTable, Len(strTable) - 5) & " VALUES (" _
                    & updateFields & ")"
            Case "D"
                strUpdateQuery = "DELETE FROM " & Right(strTable, Len(strTable) - 5) _
                    & " WHERE " & lbl1.Text & " = " & FormatSQLString(strID)
            Case "E"
                strUpdateQuery = "UPDATE " & Right(strTable, Len(strTable) - 5) & " SET " & strValues _
                    & " WHERE " & lbl1.Text & " = " & FormatSQLString(strID)
            Case "O"
                strUpdateQuery = "UPDATE " & Right(strTable, Len(strTable) - 5) & " SET " & strValues _
                    & " WHERE " & lbl1.Text & " = " & FormatSQLString(strID)
        End Select

        ExecuteNonQuery("ODMCV_1_1", "INSERT INTO temp_CVTESTER VALUES ('" & FormatForSQL(strUpdateQuery) & "','" & Now & "')")

        'had this term/id already been deleted (are they trying to add one that existed
        'at some point)
        checkTable = OpenTable("ODMCV_1_1", "SELECT " & lbl1.Text & " FROM " & strTable _
            & " WHERE status = 'approved' AND action_flag = 'D' AND " & lbl1.Text _
            & " = " & FormatSQLString(strConflict))

        If checkTable.Rows.Count > 0 And strAction = "A" And _
             strTable <> "temp_Units" And strTable <> "temp_SpatialReferences" And _
             strTable <> "temp_QualityControlLevels" Then
            EmailNotifications("approval", "11", myCV11.TableName, myCV11.Term_ID, lblEmailAddress.Text, Session.Item("admin"), myCV11.ActionFlag, "duplicate", "", strChangeInfo)

            lblMsg.Text = "The change to ODM Controlled Vocabulary " & myCV11.TableName & " is on hold because of an apparent conflict with another Term/ID. You will receive an email explaining further action."
            'lblMsg.ForeColor = Drawing.Color.DarkBlue
            lblMsg.ForeColor = Drawing.Color.FromArgb(&HFF336699)
            pnlMsg.Visible = True
            pnl1.Visible = False
            pnlReturn.Visible = True
        Else
            'are they attempting to add a term/id that conflicts with one already
            'existing in the table?
            checkTable = OpenTable("ODMCV_1_1", "SELECT " & lbl1.Text & " FROM " & Right(strTable, Len(strTable) - 5) _
                                            & " WHERE " & lbl1.Text & " = " & FormatSQLString(strConflict))
            If checkTable.Rows.Count > 0 And strAction = "A" Then
                EmailNotifications("approval", "11", strTable, strID, lblEmailAddress.Text, Session.Item("admin"), myCV11.ActionFlag, "duplicate", "", strChangeInfo)

                lblMsg.Text = "The change to ODM Controlled Vocabulary " & myCV11.TableName & " is on hold because of an apparent conflict with another Term/ID. You will receive an email explaining further action."
                'lblMsg.ForeColor = Drawing.Color.DarkBlue
                lblMsg.ForeColor = Drawing.Color.FromArgb(&HFF336699)
                pnlMsg.Visible = True
                pnl1.Visible = False
                pnlReturn.Visible = True
            Else
                ExecuteNonQuery("ODMCV_1_1", strUpdateQuery)

                strUpdateQuery = "UPDATE " & strTable & " SET status = 'approved', admin_notes = '" & FormatForSQL(txtReason.Text) & "' WHERE convert(varchar,time_stamp,109) = '" & strDate & "'"
                ExecuteNonQuery("ODMCV_1_1", "INSERT INTO temp_CVTESTER VALUES ('" & FormatForSQL(strUpdateQuery) & "','" & Now & "')")
                ExecuteNonQuery("ODMCV_1_1", strUpdateQuery)

                EmailNotifications("approval", "11", strTable, strID, lblEmailAddress.Text, Session.Item("admin"), myCV11.ActionFlag, "app", txtReason.Text, strChangeInfo)

                lblMsg.Text = "The change to ODM Controlled Vocabulary " & myCV11.TableName & " has been made. You will receive a confirmation email shortly."
                'lblMsg.ForeColor = Drawing.Color.DarkBlue
                lblMsg.ForeColor = Drawing.Color.FromArgb(&HFF336699)
                pnlMsg.Visible = True
                pnl1.Visible = False
                pnlReturn.Visible = True
            End If
        End If

    End Sub
    Private Function Build_Change_Info_String() As String
        Select Case myCV11.ActionFlag
            Case "Add"
                strChangeInfo = "<br>" & lbl1.Text & ": " & txtEdit1.Text
                strChangeInfo &= "<br>" & lbl2.Text & ": " & txtEdit2.Text
                Select Case strTable
                    Case "temp_SpatialReferences"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txtEdit3.Text
                        strChangeInfo &= "<br>" & lbl4.Text & ": " & ddl2.SelectedValue
                        strChangeInfo &= "<br>" & lbl5.Text & ": " & txtEdit5.Text
                    Case "temp_Units"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txtEdit3.Text
                        strChangeInfo &= "<br>" & lbl4.Text & ": " & txtEdit4.Text
                    Case "temp_QualityControlLevels"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txtEdit3.Text
                End Select
            Case "Delete"
                strChangeInfo = "<br>" & lbl2.Text & ": " & txt2.Text
                Select Case strTable
                    Case "temp_SpatialReferences"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txt3.Text
                        strChangeInfo &= "<br>" & lbl4.Text & ": " & ddl1.SelectedValue
                        strChangeInfo &= "<br>" & lbl5.Text & ": " & txt5.Text
                    Case "temp_Units"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txt3.Text
                        strChangeInfo &= "<br>" & lbl4.Text & ": " & txt4.Text
                    Case "temp_QualityControlLevels"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txt3.Text
                End Select
            Case "Edit"
                strChangeInfo = "<br>Original:"
                strChangeInfo &= "<br>" & lbl1.Text & ": " & txt1.Text
                strChangeInfo &= "<br>" & lbl2.Text & ": " & txt2.Text
                Select Case strTable
                    Case "temp_SpatialReferences"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txt3.Text
                        strChangeInfo &= "<br>" & lbl4.Text & ": " & ddl1.SelectedValue
                        strChangeInfo &= "<br>" & lbl5.Text & ": " & txt5.Text
                    Case "temp_Units"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txt3.Text
                        strChangeInfo &= "<br>" & lbl4.Text & ": " & txt4.Text
                    Case "temp_QualityControlLevels"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txt3.Text
                End Select
                strChangeInfo &= "<br>New:"
                strChangeInfo &= "<br>" & lbl1.Text & ": " & txtEdit1.Text
                strChangeInfo &= "<br>" & lbl2.Text & ": " & txtEdit2.Text
                Select Case strTable
                    Case "temp_SpatialReferences"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txtEdit3.Text
                        strChangeInfo &= "<br>" & lbl4.Text & ": " & ddl2.SelectedValue
                        strChangeInfo &= "<br>" & lbl5.Text & ": " & txtEdit5.Text
                    Case "temp_Units"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txtEdit3.Text
                        strChangeInfo &= "<br>" & lbl4.Text & ": " & txtEdit4.Text
                    Case "temp_QualityControlLevels"
                        strChangeInfo &= "<br>" & lbl3.Text & ": " & txtEdit3.Text
                End Select
        End Select
    End Function
    Private Sub btnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReject.Click

        Build_Change_Info_String()

        strUpdateQuery = "UPDATE " & strTable & " SET status = 'rejected', admin_notes = '" & FormatForSQL(txtReason.Text) & "' WHERE convert(varchar,time_stamp,109) = '" & strDate & "'"
        ExecuteNonQuery("ODMCV_1_1", "INSERT INTO temp_CVTESTER VALUES ('" & FormatForSQL(strUpdateQuery) & "','" & Now & "')")
        ExecuteNonQuery("ODMCV_1_1", strUpdateQuery)

        EmailNotifications("approval", "11", strTable, strID, lblEmailAddress.Text, Session.Item("admin"), myCV11.ActionFlag, "rej", txtReason.Text, strChangeInfo)

        lblMsg.Text = "The change to ODM Controlled Vocabulary " & myCV11.TableName & " has been withdrawn. You will receive a confirmation email shortly."
        'lblMsg.ForeColor = Drawing.Color.DarkBlue
        lblMsg.ForeColor = Drawing.Color.FromArgb(&HFF336699)
        pnlMsg.Visible = True
        pnl1.Visible = False
        pnlReturn.Visible = True
    End Sub
    Private Sub btnReturn_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("admindefault11.aspx")
    End Sub
End Class

End Namespace
