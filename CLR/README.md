## .NET to Java Examples
### Java Class Use Example
This is a basic example where we call the simple class defined in JavaClass.java from a .NET application.
in the /JVM/java/src/JavaClass.java we have a simple class

```Java
public class JavaClass {
	/**
	 * This simple method return the "Hello World!!" string
	 * * @return "Hello World!!" string
	 */
	public String helloWorld()
	{
		return "Hello World from Java!!";
	}
	
	/**
	 * This simple method return the sum of two double
	 * @param a
	 * @param b
	 * @return a + b
	 */
	public double add(double a, double b)
	{
		return a+b;
	}
	
	/**
	 * This simple method return the sin of a double
	 * @param a
	 * @return sin of a
	 */
	public double sin(double a)
	{
		return Math.sin(a);
	}
}
```
in the \CLR\JavaClassUseExample\program.cs we have the simple .NET C# application

```c
using MASES.JCBridge.C2JBridge;
using System;

namespace JavaClassUseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                JCOBridge.Initialize("");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            TestClass Test = new TestClass();
            Test.Execute();
        }

        class TestClass : SetupJVMWrapper
        {
            public override string ClassPath { get { return @"C:\Program Files\MASES Group\JCOB\Core;..\..\JVM\Output"; } }

            public void Execute()
            {
                double a = 2;
                double b = 3;
                double c = Math.PI/2;
                string hello = DynJVM.JavaClass.helloWorld();
                double result = DynJVM.JavaClass.add(a, b);
                double sin = DynJVM.JavaClass.sin(c);
                Console.WriteLine("{0} {1} + {2} = {3} and sin({4:0.0000000}) = {5:0.00000000}", hello, a, b, result, c, sin);
            }
        }
    }
}

```
Executing the code we have the following output:
```
Hello World from Java!! 2 + 3 = 5 and sin(3,1415927) = 1,00000000
```
### JVM Environment Example

This example is an extension of the _Java Class Use Example_ where Environment parameters are configured in the .NET _TestClass_ class.

```c

class TestClass : SetupJVMWrapper
{
	// the following line setup the classpath where JVM will search for classes
	// during runtime it is possible to dynamically add other path using a call like DynJVM.JVMHelper.addPath(<the path to add>);
	public override string ClassPath { get { return @"C:\Program Files\MASES Group\JCOB\Core;..\..\JVM\Java\Output"; } }

	// uncomment the following line and set the correct JRE if the automatic search system fails
	// public override string JVMPath { get { return @"C:\Program Files\Java\jre1.8.0_121\bin\server\jvm.dll"; } }

	// the following code adds all possible switch to the starting JVM.
	// for a complete list see Oracle documentation: https://docs.oracle.com/javase/8/docs/technotes/tools/windows/java.html
	public override IEnumerable<KeyValuePair<string, string>> JVMOptions
	{
		get
		{
			var dict = new Dictionary<string, string>();
			dict.Add("-Xmx128M", null); // this line adds a complete argument
			// dict.Add(property, value); // this line adds an argument like -Dproperty = value

			return dict;
		}
	}

	// the following code adds initial packages to the import statement.
	public override IEnumerable<string> JVMPackages
	{
		get
		{
			var list = new List<string>();
			list.Add("java.lang"); // this line adds java.lang.* like you do with "import java.lang.*" in Java
			return list;
		}
	}

	// uncomment and set the following line when you need features of JDK like the use of the compiler
	// public override string JDKHome { get { return @"C:\Program Files\Java\jdk1.8.0_121\"; } }

	public void Execute()
	{
		double a = 2;
		double b = 3;
		double c = Math.PI/2;
		string hello = DynJVM.JavaClass.helloWorld();
		double result = DynJVM.JavaClass.add(a, b);
		double sin = DynJVM.JavaClass.sin(c);
		Console.WriteLine("{0} {1} + {2} = {3} and sin({4:0.0000000}) = {5:0.00000000}", hello, a, b, result, c, sin);
		Console.WriteLine("Press Enter to exit");
		Console.ReadLine();
	}
}

```
### ConsoleTest
This is a more complex application that explores the ability of JCOBridge doing the following operations:
-Execute java code in the .NET environment using the _Dynamic JVM wrapper_
-Manage shared object
-Register CLR object in the Java Virtual Machine side
-Use the registered object from the JVM side
-Call Methods on the JVM registered class and have the operation reflected to the CLR object
-Create dialog in the JVM side and use it from the .NET code

## .NET Libraries for use within the _Java to .NET Examples_

### CSharpClass
This library contain a single class that provide double and string operations to be called from JVM.
### VBClass
This library contain a single class that provide double and string operations to be called from JVM.
### WinFormsTestControl
A Windows Form panel with his complete logic that will be used to demonstrate _User Interface Integration_ in a Java Graphical application.
### WPFTestControl
A WPF panel with his complete logic that will be used to demonstrate _User Interface Integration_ in a Java Graphical application.

## .NET to Scala examples
[Documentation here](ScalaClassUseExample/README.md)