### CSharp Class Use Examples

This is a basic example where we call the simple class defined in CSharpClass.cs from a Java application.
in the \CLR\CSharpClass\CSharpClass.cs we have a simple class

```c#
using System;

namespace MASES.CLRTests
{
    public class CSharpClass
    {
        /// <summary>The method <c>HelloWorld</c> return the "Hello World!!" string</summary>
        public String HelloWorld()
        {
            return "Hello World from C#!!";
        }

        /// <summary>The method <c>Add</c> return the sum of two double</summary>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>The method <c>Add</c> return the sin of a double</summary>
        public double Sin(double a)
        {
            return Math.Sin(a);
        }
    }
}
```

in the /JVM/src/JavaClass.java we have the simple Java application
```java
import java.io.IOException;
import org.mases.jcobridge.*;

public class CSharpClassUseExample {

	public static void main(String[] args) {
		try {
			try {
				try {
					JCOBridge.Initialize("");
					} catch (JCException e) {
						e.printStackTrace();
					}
				} catch (IOException e) {
					e.printStackTrace();
				}
				//declare and create JCOBridge instance
				JCOBridge bridge;
				bridge = JCOBridge.CreateNew();
				// adds the path where extarnal assemblies where found
				bridge.AddPath("../CLR/Output/");
				// add REFERENCES to the .dll file
				bridge.AddReference("CSharpClass");
				// GENERATE Object
				JCObject CSharpObject = (JCObject) bridge.NewObject("MASES.CLRTests.CSharpClass");
				double a = 2;
	            double b = 3;
	            double c = Math.PI/2;
	            //Invoke the C# class methods
	            String hello = (String) CSharpObject.Invoke("HelloWorld");
	            double result = (double) CSharpObject.Invoke("Add",a, b);
	            double sin = (double) CSharpObject.Invoke("Sin", c);
	            System.out.println(String.format("%s %.0f + %.0f = %.0f and sin(%.8f) = %.8f", hello, a, b, result, c, sin));
            
			} catch (JCException jce) {
			jce.printStackTrace();
			System.out.println("Exiting");
			return;
		}
	}
}
```
Executing the code we have the following output:
```
Hello World from C#!! 2 + 3 = 5 and sin(3,14159265) = 1,00000000
```
