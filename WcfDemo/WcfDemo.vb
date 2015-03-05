' WcfDemo.vb
Imports System.Net.Mail
Imports System.Diagnostics

Public Class WcfDemo
    Implements IWcfDemo

    Public Function SendEmail() As String Implements IWcfDemo.SendEmail
        Try

            ' New ProcessStartInfo created   
            Dim objProcessStartInfo As New ProcessStartInfo

            ' Specify the location of the binary   
            objProcessStartInfo.FileName = "\\step-profile\profile\rsrobbins\My Documents\Visual Studio 2013\Projects\WcfDemo\WcfEmailer\WcfEmailer\bin\Debug\WcfEmailer.exe"

            ' Specify the program arguments   
            Dim objDate As DateTime = DateTime.Now
            objProcessStartInfo.Arguments = objDate.ToString()

            ' Specify the window style, can be hidden   
            objProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden

            ' Start a process   
            Dim objApplication As Process = Process.Start(objProcessStartInfo)
            Console.WriteLine("Started WcfEmailer.exe process Id = " + objApplication.Id.ToString())


            '' Get process id and name
            'Dim intProcessID As Integer = Process.GetCurrentProcess().Id
            'Dim strProcessName As String = Process.GetCurrentProcess().ProcessName

            'Dim objMM As New MailMessage
            'Dim objSMTP As New SmtpClient
            'Dim toAddress As New MailAddress("rsrobbins@stepcorp.org", "Robert S. Robbins")
            'objMM.To.Add(toAddress)

            'Dim fromAddress As New MailAddress("robert_robbins@verizon.net", "Robert S. Robbins")
            'objMM.From = fromAddress

            'objMM.IsBodyHtml = True
            'objMM.Priority = MailPriority.Normal
            'objMM.Subject = "WCF Demo"
            'Dim strMessageBody As String = ""
            'strMessageBody = "PID: " & intProcessID.ToString() & vbCrLf
            'strMessageBody &= "Process Name: " & strProcessName & vbCrLf
            'objMM.BodyEncoding = System.Text.Encoding.ASCII
            'Dim plainView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(strMessageBody, Nothing, "text/plain")
            'plainView.TransferEncoding = Net.Mime.TransferEncoding.Base64
            'objMM.AlternateViews.Add(plainView)
            'objSMTP.Host = "mail-2010.step.local"
            'objMM.Body = strMessageBody
            '' Send the email   
            'objSMTP.Send(objMM)

            Return "Email sent"
        Catch ex As Exception
            Return ex.ToString()
        End Try

    End Function
End Class