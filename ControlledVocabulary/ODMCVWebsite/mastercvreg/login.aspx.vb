Namespace MCVReg

Partial Class login
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

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Select Case UCase(Trim(txtName.Text))
            Case "ADMINISTRATOR"
                If Trim(txtPass.Text) = "omega360" Then
                    Session.Add("login", "true")
                    Session.Add("admin", "administrator")
                    Response.Redirect("admindefault.aspx")
                End If
            Case "DTARB"
                If Trim(txtPass.Text) = "run4fun" Then
                    Session.Add("login", "true")
                    Session.Add("admin", "tarboton")
                    Response.Redirect("admindefault.aspx")
                End If
            'Case "MPIASECKI"
            '    If Trim(txtPass.Text) = "beta9027" Then
            '        Session.Add("login", "true")
            '        Session.Add("admin", "piasecki")
            '        Response.Redirect("admindefault.aspx")
            '    End If
            Case "JEFFH"
                If Trim(txtPass.Text) = "horsburgh67" Then
                    Session.Add("login", "true")
                    Session.Add("admin", "horsburgh")
                    Response.Redirect("admindefault.aspx")
                End If
            'Case "KIMS"
            '    If Trim(txtPass.Text) = "sca1066" Then
            '        Session.Add("login", "true")
            '        Session.Add("admin", "schreuders")
            '        Response.Redirect("admindefault.aspx")
            '        End If
            Case "JARRIGO"
                If Trim(txtPass.Text) = "cuahsi@123" Then
                    Session.Add("login", "true")
                    Session.Add("admin", "arrigo")
                    Response.Redirect("admindefault.aspx")
                End If
            Case "JPOLLAK"
                If Trim(txtPass.Text) = "cuahsi@123" Then
                    Session.Add("login", "true")
                    Session.Add("admin", "pollak")
                    Response.Redirect("admindefault.aspx")
                End If
        End Select
    End Sub
End Class

End Namespace
