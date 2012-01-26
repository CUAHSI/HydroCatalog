Imports System.Data.SqlClient
Imports System.Web.Mail
Imports MCVReg.Database
Imports MCVReg.Functions


Namespace MCVReg

Partial Class edit_cv
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    Protected WithEvents pnl3 As System.Web.UI.WebControls.Panel

    Dim objDataTable As DataTable
    Dim curTable As String
    Dim curTempTable As String
    Dim curTableID As String
    Dim pageAction As String

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        Dim item As ListItem
        Dim strSQL As String

        'Grab all the table names from the database:
        ddlcv.DataSource = OpenTable("ODMCV", "SELECT name, id FROM sysobjects " _
        & "WHERE xtype = 'U' AND (name LIKE '%CV' OR name = 'Units' or name = 'QualityControlLevels' or name = 'SpatialReferences') " _
        & "AND name NOT LIKE 'temp_%' " _
        & "ORDER BY name")
        ddlcv.DataTextField = "name"
        ddlcv.DataValueField = "id"
        ddlcv.DataBind()

        curTable = Request.QueryString("tbl")
        curTempTable = "temp_" & curTable
        curTableID = Request.QueryString("id")
        pageAction = Request.QueryString("act")

        lblTableName.Text = curTable & " Values"

        Select Case curTable
            Case "CensorCodeCV"
                lblTableInformation.Text = "Used to populate the CensorCode field of the DataValues table"
            Case "DataTypeCV"
                lblTableInformation.Text = "Used to populate the DataType field of the Variables table"
            Case "GeneralCategoryCV"
                lblTableInformation.Text = "Used to populate the GeneralCategory field in the Variables table"
            Case "QualityControlLevels"
                lblTableInformation.Text = "Defines QualityControlLevelID used in the DataValues table"
            Case "SampleMediumCV"
                lblTableInformation.Text = "Used to populate the SampleMedium field in the Variables table"
            Case "SampleTypeCV"
                lblTableInformation.Text = "Used to populate the SampleType field in the Samples table"
            Case "SpatialReferences"
                lblTableInformation.Text = "Defines the coordinate systems used in the Sites table"
            Case "TopicCategoryCV"
                lblTableInformation.Text = "Used to populate the TopicCategory field in the ISOMetadata table"
            Case "Units"
                lblTableInformation.Text = "Defines the units used in the Variables and Offset types tables"
            Case "ValueTypeCV"
                lblTableInformation.Text = "Used to populate the ValueType field in the Variables table"
            Case "VariableNameCV"
                lblTableInformation.Text = "Used to populate the VariableName field in the Variables table"
            Case "VerticalDatumCV"
                lblTableInformation.Text = "Used to populate the VerticalDatum field im the Sites table"
        End Select

        For Each item In ddlcv.Items
            If item.Text = curTable Then
                item.Selected = True
            End If
        Next

        strSQL = "SELECT * FROM " & curTable
        Select Case curTable
            Case "QualityControlLevels"
                strSQL &= " ORDER BY QualityControlLevelID"
            Case "SpatialReferences"
                strSQL &= " ORDER BY SpatialReferenceID"
            Case "Units"
                strSQL &= " ORDER BY UnitsID"
            Case Else
                strSQL &= " ORDER BY Term"
        End Select

        BindData(strSQL)

        If pageAction = "add" Then
            AddEdit_CV("add")
        End If
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlMsg.Visible = False
    End Sub
    Private Sub BindData(ByVal sqlString As String)

        Dim curCol As DataColumn
        Dim myBoundCol As BoundColumn
        Dim btnEditCol As ButtonColumn

        dgCV.Columns.Clear()

        dgCV.Attributes.Add("OnItemCommand", "dgCV_ItemCommand")

        btnEditCol = New ButtonColumn

        With btnEditCol
            .CommandName = "edit"
            .ButtonType = ButtonColumnType.LinkButton
                .Text = "<img src='images/btn_edit.gif' border='0'>"
            .ItemStyle.HorizontalAlign = HorizontalAlign.Center
                .HeaderText = "<a href='edit_cv.aspx?act=add&tbl=" & curTable & "&id=" & curTableID & "'><img src='images/btn_new.jpg' border='0'></a>"
        End With

        dgCV.Columns.Add(btnEditCol)

        objDataTable = OpenTable("ODMCV", sqlString)

        For Each curCol In objDataTable.Columns
            myBoundCol = New BoundColumn
            myBoundCol.HeaderText = curCol.ColumnName
            myBoundCol.DataField = curCol.ColumnName
            myBoundCol.SortExpression = curCol.ColumnName
            dgCV.Columns.Add(myBoundCol)
        Next

        dgCV.DataSource = objDataTable
        dgCV.DataBind()
        pnl1.Visible = True
        pnl2.Visible = False
    End Sub
    Public Sub SortCommand_OnClick(ByVal Source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgCV.SortCommand

        BindData("SELECT * FROM " & curTable & " ORDER BY " & e.SortExpression)

    End Sub

    Public Sub dgCV_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCV.ItemCommand

        AddEdit_CV("edit", e.Item.Cells(1).Text)

    End Sub

    Private Sub AddEdit_CV(ByVal commandType As String, Optional ByVal editCell As String = "")
        Dim i_count As Integer
        Dim curRow As DataRow
        Dim curCell As DataColumn
        Dim curCol As DataColumn
        Dim curLbl As Label
        Dim curTxt As TextBox
        Dim curDdl As DropDownList
        Dim mobjDataTable As DataTable
        Dim tempTable As DataTable
        Dim tempRow As DataRow

        lblTable.Text = curTable & " change request"

        objDataTable = OpenTable("ODMCV", "SELECT t1.[name] AS name, t2.[name] AS type, t1.length " _
            & "FROM dbo.syscolumns t1 JOIN dbo.systypes t2 ON t1.xtype = t2.xusertype " _
            & "WHERE id = " & curTableID)

        i_count = 1
        If objDataTable.Rows.Count > 0 Then
            For Each curRow In objDataTable.Rows
                'Data entry section:
                curLbl = pnl2.FindControl("lbl" & Convert.ToString(i_count))
                If curRow.Item("name") = "IsGeographic" Then
                    curDdl = pnl2.FindControl("ddl1")
                    curDdl.Visible = True
                    'We're looking at SpatialReferences, which has an int for its second field.
                    'Force only numeric entry:
                    reg1.Enabled = True
                Else
                    curTxt = pnl2.FindControl("txt" & Convert.ToString(i_count))
                    curTxt.MaxLength = (curRow.Item("length") / 2)
                    'kats - 2008/04/07 - begin
                    If curRow.Item("type") = "int" Then
                        curTxt.MaxLength = 14
                    End If
                    'kats - 2008/04/07 - end
                    If curRow.Item("length") > 100 Then
                        curTxt.TextMode = TextBoxMode.MultiLine
                        curTxt.Rows = 3
                    End If
                    curTxt.Text = ""
                    curTxt.ReadOnly = False
                    curTxt.Visible = True
                    End If
                    curLbl.Text = curRow.Item("name")
                    curLbl.Visible = True
                    'Initialize the ID field:
                    If i_count = 1 And curRow.Item("type") = "int" Then
                        tempTable = OpenTable("ODMCV", "SELECT MAX(" & curRow.Item("name") & ") AS maxVal FROM " & curTable)
                        tempRow = tempTable.Rows(0)
                        curTxt.Text = CLng(tempRow.Item(0)) + 1
                        curTxt.Enabled = False
                        'curTxt.ReadOnly = True
                    End If
                    i_count = i_count + 1
            Next
        End If

        Select Case commandType

            Case "add"
                lblAction.Text = "A"
                chkDelete.Visible = False
            Case "edit"
                objDataTable = OpenTable("ODMCV", "SELECT * FROM " & curTable & " WHERE " & lbl1.Text & " = '" & editCell & "'")
                i_count = 1
                For Each curRow In objDataTable.Rows
                    For Each curCell In objDataTable.Columns
                        If curCell.ColumnName = "IsGeographic" Then
                            curLbl = pnl2.FindControl("lbledit" & Convert.ToString(i_count))
                            If curRow.Item(i_count - 1) = "True" Then
                                ddl1.SelectedIndex = 0
                                curLbl.Text = "True"
                            Else
                                ddl1.SelectedIndex = 1
                                curLbl.Text = "False"
                            End If
                        Else
                            curTxt = pnl2.FindControl("txt" & Convert.ToString(i_count))
                            If Not curRow.Item(i_count - 1) Is System.DBNull.Value Then
                                curTxt.Text = curRow.Item(i_count - 1)
                            End If
                        End If
                        curLbl = pnl2.FindControl("lblEdit" & Convert.ToString(i_count))
                        If Not curRow.Item(i_count - 1) Is System.DBNull.Value Then
                            curLbl.Text = curRow.Item(i_count - 1)
                        End If
                        i_count = i_count + 1
                    Next
                Next
                lblAction.Text = "E"
        End Select

        'set up required field validators:
        req1.Enabled = True
        reqReason.Enabled = True
        reqName.Enabled = True
        reqEmail.Enabled = True
        Select Case curTable
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

        pnl1.Visible = False
        pnl2.Visible = True
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim curControl As Control
        Dim curTxt As TextBox
        Dim curDdl As DropDownList
        Dim curLbl As Label
        Dim i_count As Integer
        Dim updateFields As String, editField As String
        Dim action_flag As String
        Dim time_stamp As DateTime
        Dim changeInfo As String
        Dim submitterInfo As String

        i_count = 1
        updateFields = "" : editField = ""

        If chkDelete.Checked Then
            lblAction.Text = "D"
        End If

        Try
            For Each curControl In pnl2.Controls
                If curControl.GetType.ToString.Equals("System.Web.UI.WebControls.TextBox") _
                    And curControl.Visible = True Then
                    curTxt = curControl.FindControl("txt" & Convert.ToString(i_count))
                    If Not curTxt Is Nothing Then
                        If curTxt.Visible = True Then
                            curLbl = curControl.FindControl("lblEdit" & Convert.ToString(i_count))
                            updateFields = updateFields & "'" & FormatForSQL(curTxt.Text) & "',"
                            editField = editField & "'" & FormatForSQL(curLbl.Text) & "',"
                            i_count = i_count + 1
                        End If
                    End If
                ElseIf curControl.GetType.ToString.Equals("System.Web.UI.WebControls.DropDownList") And curControl.Visible = True Then
                    curDdl = curControl.FindControl("ddl1")
                    curLbl = curControl.FindControl("lblEdit" & Convert.ToString(i_count))
                    updateFields = updateFields & "'" & FormatForSQL(curDdl.SelectedValue) & "',"
                    editField = editField & "'" & FormatForSQL(curLbl.Text) & "',"
                    i_count = i_count + 1
                End If
            Next

            time_stamp = Now

            If lblAction.Text = "D" Then
                editField = editField & "'submitted','" & "D" & "','" & time_stamp & "','" _
                    & FormatForSQL(txtReason.Text) & "','" & FormatForSQL(txtName.Text) & "','" _
                    & FormatForSQL(txtEmail.Text) & "',null"
                ExecuteNonQuery("ODMCV", "INSERT INTO temp_" & curTable & " VALUES (" & editField & ")")
            Else
                updateFields = updateFields & "'submitted','" & lblAction.Text & "','" & time_stamp & "','" _
                    & FormatForSQL(txtReason.Text) & "','" & FormatForSQL(txtName.Text) & "','" _
                    & FormatForSQL(txtEmail.Text) & "',null"
                ExecuteNonQuery("ODMCV", "INSERT INTO temp_" & curTable & " VALUES (" & updateFields & ")")

                If lblAction.Text = "E" Then
                    editField = editField & "'submitted','" & "O" & "','" & time_stamp & "','" _
                    & FormatForSQL(txtReason.Text) & "','" & FormatForSQL(txtName.Text) & "','" _
                    & FormatForSQL(txtEmail.Text) & "',null"
                    ExecuteNonQuery("ODMCV", "INSERT INTO temp_" & curTable & " VALUES (" & editField & ")")
                End If
            End If

            lblMsg.Text = "Your changes have been submitted. An ODM administrator will need to approve these changes before they take affect."
            'lblMsg.ForeColor = Drawing.Color.DarkBlue
            lblMsg.ForeColor = Drawing.Color.FromArgb(&HFF336699)
            pnlMsg.Visible = True
            pnl2.Visible = False
            pnlReturn.Visible = True

            changeInfo = "<br>" & lbl1.Text & ": " & txt1.Text
            changeInfo &= "<br>" & lbl2.Text & ": " & txt2.Text
            Select Case curTable
                Case "SpatialReferences"
                    changeInfo &= "<br>" & lbl3.Text & ": " & txt3.Text
                    changeInfo &= "<br>" & lbl4.Text & ": " & ddl1.SelectedValue
                    changeInfo &= "<br>" & lbl5.Text & ": " & txt5.Text
                Case "Units"
                    changeInfo &= "<br>" & lbl3.Text & ": " & txt3.Text
                    changeInfo &= "<br>" & lbl4.Text & ": " & txt4.Text
                Case "Quality ControlLevels"
                    changeInfo &= "<br>" & lbl3.Text & ": " & txt3.Text
            End Select

            changeInfo &= "<br><br>Reason given for request: " & txtReason.Text

            submitterInfo = txtName.Text & ", " & "<a href='mailto:" & txtEmail.Text & "'>" & txtEmail.Text & "</a>"

            EmailNotifications("submission", "10", curTable, txt1.Text, txtEmail.Text, "jeff.horsburgh@usu.edu,david.tarboton@usu.edu,kim.schreuders@usu.edu", lblAction.Text, "", "", changeInfo, submitterInfo)
        Catch ex As Exception
            pnlMsg.Visible = True
            lblMsg.Text = "An error occured while updating Controlled Vocabularies. Please check entries and try again"
            lblMsg.ForeColor = System.Drawing.Color.Red
            EmailNotifications("error", "10", ex.Message & ", " & ex.StackTrace)
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        regEmail.Enabled = False
        pnl2.Visible = False
        pnl1.Visible = True
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("cv10.aspx")
    End Sub

    Private Sub lnkCV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkCV.Click
        Response.Redirect("cv10.aspx")
    End Sub

    Private Sub lnkODM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkODM.Click
        Response.Redirect("default.aspx")
    End Sub

    Private Sub ddlcv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlcv.SelectedIndexChanged
        Response.Redirect("edit_cv.aspx?tbl=" & ddlcv.SelectedItem.ToString & "&id=" & ddlcv.SelectedValue.ToString)
    End Sub
End Class

End Namespace
