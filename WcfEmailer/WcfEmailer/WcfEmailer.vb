Imports System.Net.Mail
Imports System.Diagnostics

Module WcfEmailer

    Sub Main(ByVal sArgs() As String)
        Try
            Dim strMessageBody As String = ""

            ' Get the arguments
            If sArgs.Length = 0 Then
                'If there are no arguments
                Console.WriteLine("Error! <-no arguments passed->")
            Else
                'We have some arguments 
                Dim i As Integer = 0

                While i < sArgs.Length
                    strMessageBody &= "Argument: " & sArgs(i) & vbCrLf
                    i = i + 1
                End While
            End If

            ' Get process id and name   
            Dim intProcessID As Integer = Process.GetCurrentProcess().Id
            Dim strProcessName As String = Process.GetCurrentProcess().ProcessName

            Dim objMM As New MailMessage
            Dim objSMTP As New SmtpClient
            Dim toAddress As New MailAddress("rsrobbins@stepcorp.org", "Robert S. Robbins")
            objMM.To.Add(toAddress)

            Dim fromAddress As New MailAddress("robert_robbins@verizon.net", "Robert S. Robbins")
            objMM.From = fromAddress

            objMM.IsBodyHtml = True
            objMM.Priority = MailPriority.Normal
            objMM.Subject = "WCF Demo"
            strMessageBody &= "PID: " & intProcessID.ToString() & vbCrLf
            strMessageBody &= "Process Name: " & strProcessName & vbCrLf
            objMM.BodyEncoding = System.Text.Encoding.ASCII
            Dim plainView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(strMessageBody, Nothing, "text/plain")
            plainView.TransferEncoding = Net.Mime.TransferEncoding.Base64
            objMM.AlternateViews.Add(plainView)
            objSMTP.Host = "mail-2010.step.local"
            objMM.Body = strMessageBody
            ' Send the email      
            objSMTP.Send(objMM)
            Console.WriteLine("Email sent.")

        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        End Try
    End Sub

End Module
