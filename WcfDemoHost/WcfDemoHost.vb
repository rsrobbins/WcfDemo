' WcfDemoHost.vb
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ServiceModel
Imports WcfDemo
Imports System.ServiceModel.Description

Module WcfDemoHost

    Sub Main()
        ' Step 1 Create a URI to serve as the base address. 
        Dim baseAddress As Uri = New Uri("http://localhost:8000/WcfDemo/")

        ' Step 2 Create a ServiceHost instance 
        Dim selfHost As New ServiceHost(GetType(WcfDemo.WcfDemo), baseAddress)

        Try
            ' Step 3 Add a service endpoint.   
            selfHost.AddServiceEndpoint(GetType(IWcfDemo), New WSHttpBinding(), "WcfDemo")

            ' Step 4 Enable metadata exchange.   
            Dim smb As New ServiceMetadataBehavior()
            smb.HttpGetEnabled = True
            selfHost.Description.Behaviors.Add(smb)

            ' Step 5 Start the service.   
            selfHost.Open()
            Console.WriteLine("The service is ready.")
            Console.WriteLine("Press <ENTER> to terminate service.")
            Console.WriteLine()
            Console.ReadLine()

            ' Close the ServiceHostBase to shutdown the service.   
            selfHost.Close()

        Catch ex As Exception
            Console.WriteLine("An exception occurred: {0}", ex.ToString())
            selfHost.Abort()
        End Try


    End Sub

End Module