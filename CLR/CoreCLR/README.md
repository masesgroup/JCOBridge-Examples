## .NET Core to Java Examples
These examples demonstrate the use of JCOBridge from Nuget package. All examples follows the one in Framework version.

### Java Class Use Example

See [CLR Framework version](../Framework/README.md)

### Example use
The examples are made to run on .NET Core 3.1, .NET 5 and .NET 6. You need to download it from website.

> dotnet build sln CoreCLR.sln

> dotnet run --framework netcoreapp3.1 --project **project-name** 

> dotnet run --framework net5.0 --project **project-name**

> dotnet run --framework net6.0 --project **project-name**

replace **project-name** with any name within the folder (e.g. ConsoleTest). Add _--JVMPath:_ switch to force JVM library (e.g. --JVMPath:"C:/Program Files/Java/jre1.8.0_241/bin/server/jvm.dll")