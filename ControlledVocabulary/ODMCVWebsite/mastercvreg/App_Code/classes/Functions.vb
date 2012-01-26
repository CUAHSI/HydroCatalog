Imports MCVReg.Database
Imports System.Text.RegularExpressions
Imports System.Web.Mail
Imports MCVReg.ControlledVocabulary


Namespace MCVReg

Public Class Functions
    Public Shared Function FormatForSQL(ByVal strText As String) As String
        Dim strReturn As String
        If strText <> String.Empty Then
            strReturn = Regex.Replace(strText, "^[\s]+|[\s]+$", "")
            strReturn = Replace(strReturn, "'", "''")
        End If
        Return strReturn
    End Function

    Public Shared Function FormatSQLString(ByVal strText As String) As String
        If Not IsNumeric(strText) Then
            strText = "'" & strText & "'"
        End If
        Return strText
    End Function

    Public Shared Sub EmailNotifications(ByVal msgType As String, _
                                        Optional ByVal version As String = "", _
                                        Optional ByVal tableName As String = "", _
                                        Optional ByVal tableID As String = "", _
                                        Optional ByVal msgTo As String = "", _
                                        Optional ByVal msgModerators As String = "", _
                                        Optional ByVal actionFlag As String = "", _
                                        Optional ByVal approvedFlag As String = "", _
                                        Optional ByVal adminReason As String = "", _
                                        Optional ByVal changeInfo As String = "", _
                                        Optional ByVal submitterInfo As String = "")

        Dim objMailMessage As New MailMessage
        Dim time_stamp As Date
        Dim strSignature As String

        Select Case actionFlag
            Case "D"
                actionFlag = "Delete"
            Case "A"
                actionFlag = "Add New Entry"
            Case "E"
                actionFlag = "Edit Entry"
            Case "O"
                actionFlag = "Edit Entry"
        End Select

        If msgType <> "error" Then
            If Left(tableName, 5) = "temp_" Then
                tableName = Right(tableName, (Len(tableName) - 5))
            End If
        End If

        strSignature = "David Tarboton<br>Utah State University<br>" _
                    & "<a href='mailto:david.tarboton@usu.edu'>david.tarboton@usu.edu</a>"

        Select Case msgModerators
            Case "tarboton"
                msgModerators = "david.tarboton@usu.edu"
                strSignature = "David Tarboton<br>Utah State University<br>" _
                    & "<a href='mailto:david.tarboton@usu.edu'>david.tarboton@usu.edu</a>"
            Case "administrator"
                ' msgModerators = "halcyongoddess@gmail.com"
                'msgModerators = "jeff.horsburgh@usu.edu"
                'strSignature = "Jeff Horsburgh<br>Utah State University<br>" _
                '    & "<a href='mailto:jeff.horsburgh@usu.edu'>jeff.horsburgh@usu.edu</a>"
                msgModerators = "kim.schreuders@usu.edu"
                strSignature = "Kim Schreuders<br>Utah State University<br>" _
                    & "<a href='mailto:kim.schreuders@usu.edu'>kim.schreuders@usu.edu</a>"
            Case "horsburgh"
                msgModerators = "jeff.horsburgh@usu.edu"
                strSignature = "Jeff Horsburgh<br>Utah State University<br>" _
                    & "<a href='mailto:jeff.horsburgh@usu.edu'>jeff.horsburgh@usu.edu</a>"
            Case "schreuders"
                msgModerators = "kim.schreuders@usu.edu"
                strSignature = "Kim Schreuders<br>Utah State University<br>" _
                    & "<a href='mailto:kim.schreuders@usu.edu'>kim.schreuders@usu.edu</a>"

        End Select

        'if we get an error, tablename contains the error message

        time_stamp = Now

        objMailMessage.BodyFormat = MailFormat.Html
        Select Case msgType
            Case "approval"
                objMailMessage.From = msgModerators
            Case "error"
                objMailMessage.From = "CUAHSIhiswebsite@cuahsi.org"
            Case Else
                objMailMessage.From = "david.tarboton@usu.edu"
        End Select

        objMailMessage.Body = "<div style=""font-family:Verdana,Arial,sans-serif; font-size:13px; width:600px"">"

        Select Case msgType
            Case "approval"
                Select Case approvedFlag
                    Case "app"
                        objMailMessage.To = msgModerators
                        objMailMessage.Cc = msgTo
                        objMailMessage.Subject = "Master Controlled Vocabularies Update"
                        objMailMessage.Body = "Thank you for submitting a Master Controlled Vocabulary change request.  In response to your request the master controlled vocabulary at http://his.cuahsi.org/mastercvreg/ has been updated."
                        objMailMessage.Body &= "<p>Table: " & tableName & "<br>Request: " & actionFlag & "<br>ID/Term Affected: " & tableID & "<br>"
                        objMailMessage.Body &= changeInfo

                        objMailMessage.Body &= "<p>Administrator notes: " & adminReason
                        Select Case version
                            Case "10"
                                objMailMessage.Body &= "<p>You may update your version of ODM with the latest terms by following the instructions at <a href='http://his.cuahsi.org/mastercvreg/cv10.aspx'>http://his.cuahsi.org/mastercvreg/cv10.aspx</a>."
                            Case "11"
                                objMailMessage.Body &= "<p>You may update your version of ODM with the latest terms by following the instructions at <a href='http://his.cuahsi.org/mastercvreg/cv11.aspx'>http://his.cuahsi.org/mastercvreg/cv11.aspx</a>."
                        End Select
                        objMailMessage.Body &= "<br><br><p>" & strSignature
                        objMailMessage.Body &= "</div>"
                    Case "rej"
                        objMailMessage.To = msgModerators
                        objMailMessage.Cc = msgTo
                        objMailMessage.Subject = "ODM Controlled Vocabularies Update"
                        objMailMessage.Body = "Thank you for submitting an ODM Controlled vocabulary change request."
                        objMailMessage.Body &= "<p>Table: " & tableName & "<br>Request: " & actionFlag & "<br>ID/Term Affected: " & tableID & "<br>"
                        objMailMessage.Body &= changeInfo

                        objMailMessage.Body &= "<p>We are unable to accommodate your request for the following reason:<br>"
                        objMailMessage.Body &= adminReason
                        Select Case version
                            Case "10"
                                objMailMessage.Body &= "<p>You may update your version of ODM with the latest terms by following the instructions at <a href='http://his.cuahsi.org/mastercvreg/cv10.aspx'>http://his.cuahsi.org/mastercvreg/cv10.aspx</a>."
                            Case "11"
                                objMailMessage.Body &= "<p>You may update your version of ODM with the latest terms by following the instructions at <a href='http://his.cuahsi.org/mastercvreg/cv11.aspx'>http://his.cuahsi.org/mastercvreg/cv11.aspx</a>."
                        End Select
                        objMailMessage.Body &= "<br><br><p>" & strSignature
                        objMailMessage.Body &= "</div>"
                    Case "duplicate"
                        objMailMessage.To = msgModerators
                        objMailMessage.Subject = "ODM Controlled Vocabularies Update"
                        objMailMessage.Body = "A controlled vocabulary change has been found to have a duplicate Term/ID in the database. Please make any necessary changes to the controlled vocabulary submission on the administration page."
                        objMailMessage.Body &= "<p>Table: " & tableName & "<br>Request: " & actionFlag & "<br>ID/Term Affected: " & tableID & "<br>"
                        objMailMessage.Body &= changeInfo
                        Select Case version
                            Case "10"
                                objMailMessage.Body &= "<p><a href='http://his.cuahsi.org/mastercvreg/login.aspx'>http://his.cuahsi.org/mastercvreg/login.aspx</a>"
                            Case "11"
                                objMailMessage.Body &= "<p><a href='http://his.cuahsi.org/mastercvreg/login11.aspx'>http://his.cuahsi.org/mastercvreg/login11.aspx</a>"
                        End Select
                        objMailMessage.Body &= "<br><br><p>" & strSignature
                        objMailMessage.Body &= "</div>"
                End Select
                Try
                    'SmtpMail.SmtpServer = "cc.usu.edu"
                    'SmtpMail.SmtpServer = "lhotse.uwrl.usu.edu"
                    SmtpMail.SmtpServer = "mail.usu.edu"
                    SmtpMail.Send(objMailMessage)
                Catch ex As Exception
                    Dim ex2 As Exception = ex
                    Dim errorMessage As String = String.Empty
                    While Not (ex2 Is Nothing)
                        errorMessage &= ex2.ToString()
                        ex2 = ex2.InnerException
                    End While
                    'objMailMessage.To = "halcyongoddess@gmail.com"
                    objMailMessage.To = "kim.schreuders@usu.edu"
                    objMailMessage.Subject = "ODM Controlled Vocabularies Email Error"

                    objMailMessage.Body &= "<p>An error occured on the ODM CV submission page:</p>"
                    objMailMessage.Body &= "<p>" & errorMessage & "</p>"
                    objMailMessage.Body &= "</div>"

                    'SmtpMail.SmtpServer = "cc.usu.edu"
                    SmtpMail.SmtpServer = "mail.usu.edu"

                    SmtpMail.Send(objMailMessage)
                End Try
            Case "submission"
                objMailMessage.To = msgModerators
                objMailMessage.Subject = "ODM Controlled Vocabularies Submission"

                objMailMessage.Body &= "<p>" & time_stamp & ": A user has submitted a change to ODM Controlled Vocabulary.</p>"
                objMailMessage.Body &= "<p>Table: " & tableName & "<br>Request: " & actionFlag & "<br>ID/Term Affected: " & tableID & "<br>"
                objMailMessage.Body &= "<p>Submitter: " & submitterInfo & "<br>"
                objMailMessage.Body &= changeInfo
                Select Case version
                    Case "10"
                        objMailMessage.Body &= "<p>Please click <a href='http://his.cuahsi.org/mastercvreg/login.aspx'>HERE</a> to view the pending submissions page.</p>"
                    Case "11"
                        objMailMessage.Body &= "<p>Please click <a href='http://his.cuahsi.org/mastercvreg/login11.aspx'>HERE</a> to view the pending submissions page.</p>"
                End Select
                objMailMessage.Body &= "</div>"

                'SmtpMail.SmtpServer = "cc.usu.edu"
                SmtpMail.SmtpServer = "mail.usu.edu"
                SmtpMail.Send(objMailMessage)

                objMailMessage.To = msgTo
                objMailMessage.Body = "<div style=""font-family:Verdana,Arial,sans-serif; font-size:13px; width:600px"">"
                objMailMessage.Body &= "<p>Thank you for your submission to ODM Controlled Vocabularies. "
                objMailMessage.Body &= "<p>Table: " & tableName & "<br>Request: " & actionFlag & "<br>ID/Term Affected: " & tableID & "<br>"
                objMailMessage.Body &= changeInfo

                objMailMessage.Body &= "<p>This request will be reviewed by a moderator and you will be notified once the status of the submission changes."

                objMailMessage.Body &= "<br><br><p>" & strSignature
                objMailMessage.Body &= "</div>"

                'SmtpMail.SmtpServer = "cc.usu.edu"
                SmtpMail.SmtpServer = "mail.usu.edu"
                SmtpMail.Send(objMailMessage)
            Case "error"
                ' objMailMessage.To = "halcyongoddess@gmail.com"
                objMailMessage.To = "kim.schreuders@usu.edu"
                objMailMessage.Subject = "ODM Controlled Vocabularies Error"

                objMailMessage.Body &= "<p>An error occured on the ODM CV submission page:</p>"
                objMailMessage.Body &= "<p>" & tableName & "</p>"
                objMailMessage.Body &= "</div>"

                'SmtpMail.SmtpServer = "cc.usu.edu"
                SmtpMail.SmtpServer = "mail.usu.edu"
                SmtpMail.Send(objMailMessage)
        End Select
    End Sub
End Class

End Namespace
