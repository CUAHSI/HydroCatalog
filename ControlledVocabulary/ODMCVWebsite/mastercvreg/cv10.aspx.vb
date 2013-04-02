Imports MCVReg.Database
Imports System.Data.SqlClient


Namespace MCVReg

Partial Class cv10
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        'ddlcv.DataSource = OpenTable("ODMCV", "SELECT name, id FROM sysobjects " _
        '    & "WHERE xtype = 'U' AND (name LIKE '%CV' OR name = 'Units' or name = 'QualityControlLevels' or name = 'SpatialReferences') " _
        '    & "AND name NOT LIKE 'temp_%' " _
        '    & "ORDER BY name")
        'ddlcv.DataTextField = "name"
        'ddlcv.DataValueField = "id"
        'ddlcv.DataBind()

    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    'Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

    '    Response.Redirect("edit_cv.aspx?tbl=" & ddlcv.SelectedItem.ToString & "&id=" & ddlcv.SelectedValue.ToString)

    'End Sub
End Class

End Namespace
