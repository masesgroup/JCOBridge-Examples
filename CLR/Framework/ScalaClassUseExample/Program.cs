using CommonTest;
using MASES.JCOBridge.C2JBridge;
using MASES.LicenseManager.Common;
using System;
using System.Collections.Generic;
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
