' WcfDemoClient.vb
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports WcfDemoClient.WcfDemoServiceReference

Module WcfDemoClient

    Sub Main()
        ' Step 1: Create an instance of the WCF proxy.   
        Dim client As WcfDemoServiceReference.WcfDemoClient = New WcfDemoServiceReference.WcfDemoClient()

        ' Step 2: Call the service operations.
        Dim strResponse As String = client.SendEmail()
        Console.WriteLine(strResponse)
        Console.ReadLine()

        ' Step 3: Closing the client gracefully closes the connection and cleans up resources.   
        client.Close()

    End Sub

End Module