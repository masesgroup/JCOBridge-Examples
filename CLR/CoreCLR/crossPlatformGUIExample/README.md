## .NET Core Linux/Windows GUI

The example is an evolution of the template available on [JCOBridge Templates](https://www.nuget.org/packages/JCOBridge.Examples.Templates/) and demonstrate how is it possible to use AWT to build a cross platform GUI usable from .NET Core.
The same code can be invoked on all supported platforms.
The example also adds some little code stub which demostrate how it is simple to interact with AWT GUI elements from .NET code.

### Example use

> Windows environment
> 
> *dotnet run --framework netcoreapp3.1 --JVMPath:"C:/Program Files/Java/jre1.8.0_241/bin/server/jvm.dll"*
>
> Linux environment
>
> *dotnet run --framework netcoreapp3.1 --JVMPath:/usr/lib/jvm/default-jvm/lib/server/libjvm.so*
>

where framework can any of netcoreapp3.1, net5.0, net6.0.

Here the execution on a Linux operating systems of the original template:

![Alt text](images/execution.gif?raw=true "Linux Execution")

Here the execution on a Windows operating systems of the original template:

![Alt text](images/AWTAppExample.png?raw=true "Windows Execution 1")


