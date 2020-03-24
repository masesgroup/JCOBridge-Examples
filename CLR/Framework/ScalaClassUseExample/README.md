## .NET to Scala Example
A simple Scala class is defined to be used from CLR in JVM\Scala\scalaclass\src\main\scala\ScalaClass.class
Call compile and execute batch script in JVM\Scala\
Before call compile and execute batch script Scala [binaries](https://downloads.lightbend.com/scala/2.12.8/scala-2.12.8.msi) shall be installed.

```java
import java.lang._

final class ScalaClass(aString: String, val anInteger: Int) {
    def this() {
        this("defaultString", -1)
    }

    def this(aBool: Boolean) {
        this("defaultString", -1)
    }

    val scalaString = "This is a Scala String"

    def add(x: Int, y: Int): Int = x + y

    def stringConcat(args: Array[String]): String = 
    {
        return args.mkString(", ")
    }
}
```

In the \CLR\ScalaClassUseExample\Program.cs we have a simple application that use the defined ScalaClass 

```c
using CommonTest;
using MASES.JCOBridge.C2JBridge;
using MASES.LicenseManager.Common;
using System;
using System.IO;

namespace ScalaClassUseExample
{
    class TestClass : BaseTestClass
    {
        public override string GetProjectClassPath()
        {
#if !JCOBRIDGE_CORE
            return @"..\..\JVM\Scala\Output";
#else
            return @"..\..\..\JVM\Scala\Output";
#endif
        }

        public override string ClassPath
        {
            get
            {
                string scalaBasePath = @"C:\Program Files (x86)\scala\lib";

                var classPath = @"..\..\JVM\Scala\Output;"; // adding scala 2.13.1 libraries
                classPath += Path.Combine(scalaBasePath, "jansi-1.12.jar") + classPathSeparator;
                classPath += Path.Combine(scalaBasePath, "jline-2.14.6.jar") + classPathSeparator;
                classPath += Path.Combine(scalaBasePath, "scala-compiler.jar") + classPathSeparator;
                classPath += Path.Combine(scalaBasePath, "scala-library.jar") + classPathSeparator;
                classPath += Path.Combine(scalaBasePath, "scalap-2.13.1.jar") + classPathSeparator;
                return classPath;
            }
        }

        public override void Execute()
        {
            int a = 10;
            int b = 15;
            var scalaClass = DynJVM.ScalaClass.@new();
            var result = scalaClass.add(a, b);
            Console.WriteLine("{0} + {1} = {2}", a, b, result);

            string[] strings = new string[] { "One", "Two", "Three" };
            var concatString = scalaClass.stringConcat(strings);
            Console.WriteLine("{0} = {1}", string.Concat(strings), concatString);

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                JCOBridge.Initialize();
            }
            catch (FallbackInTrialModeException)
            {
                // nothing to do 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            try
            {
                TestClass Test = new TestClass();
                Test.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key.");
                Console.ReadKey();
            }
        }
    }
}

```
In Scala all the needed libraries shall be explicitly added to the base path.  