# WcfDemo
Windows Communication Foundation demo project which creates a new process to send emails.

There are four Visual Studio 2013 projects in this solution:

* **WcfDemo** - the service that spawns processes to send the email
* **WcfDemoClient** - the console application. Run multiple instances of this executable to spawn the processes
* **WcfDemoHost** - another console application that serves as the host for the service.
* **WcfEmailer** - another console application that does the actual work of sending the email, i.e. the processes

How To Run The Demo
-------------------
In WcfDemoHost\bin\Debug run the WcfDemoHost.exe program which displays the messsage below. Do not close this program!

```
The service is ready.
Press <ENTER> to terminate service.
```

In WcfDemoClient\bin\Debug run the WcfDemoClient.exe program which will display "Email sent.". Run multiple instances of this program to spawn new processes.

Things to Edit in the Code
--------------------------
You probably have to change some things in the code to get this to work on your system. First, in the WcfDemo project edit the **WcfDemo.vb** file to change the file path for the WcfEmailer.exe appliciation. The **WcfEmailer.exe** program is located in the WcfEmailer\bin\Debug folder. 

In the **WcfEmailer.vb** file in the WcfEmailer project, you will want to change the Email To address and the objSMTP.Host value to your mail server. Remember to recompile these projects before doing your testing.

The **WcfDemoHost.exe** console application window will display something like this if it is working:

```
The service is ready.
Press <ENTER> to terminate service.

Started WcfEmailer.exe process Id = 7344
Started WcfEmailer.exe process Id = 1044
Started WcfEmailer.exe process Id = 7448
Started WcfEmailer.exe process Id = 7268
```

Troubleshooting
-------------------------
The WcfDemoHost project requires a reference to the **WcfDemo.dll** compiled by the WcfDemo project. You may need to recreate this reference if it cannot be found.
