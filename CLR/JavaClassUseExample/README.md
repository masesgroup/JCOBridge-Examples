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