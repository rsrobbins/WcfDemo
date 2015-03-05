' IWcfDemo.vb
<ServiceContract()>
Public Interface IWcfDemo

    <OperationContract()>
    Function SendEmail() As String

End Interface