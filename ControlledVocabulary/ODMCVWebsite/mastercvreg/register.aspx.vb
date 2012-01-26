Imports MCVReg.Database


Namespace MCVReg

Partial Class register
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub btn_submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        Dim register_name As String, organization As String, email_address As String
        Dim strSQL As String

        register_name = Trim(txt_name.Text)
        organization = Trim(txt_organization.Text)
        email_address = Trim(txt_email.Text)

        strSQL = "EXEC usp_register_download '" & register_name & "','" & organization & "','" & email_address & "'"

        ExecuteNonQuery(strSQL)

        Response.Redirect("ODM_downloads.aspx?reg=true")
    End Sub
End Class

End Namespace
