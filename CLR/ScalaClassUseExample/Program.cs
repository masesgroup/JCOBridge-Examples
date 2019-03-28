using MASES.JCOBridge.C2JBridge;
using System;
using System.Collections.Generic;
using System.IO;

namespace ScalaClassUseExample
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

        class TestClass : SetupJVMWrapper
        {
            public override string ClassPath
            {
                get
                {
                    string scalaBasePath = @"C:\Program Files (x86)\scala\lib";

                    var basePath = @"C:\Program Files\MASES Group\JCOB\Core;..\..\JVM\Scala\Output;";
                    basePath += Path.Combine(scalaBasePath, "jline -2.14.6.jar") + ";";
                    basePath += Path.Combine(scalaBasePath, "scala-compiler.jar") + ";";
                    basePath += Path.Combine(scalaBasePath, "scala-library.jar") + ";";
                    basePath += Path.Combine(scalaBasePath, "scala-parser-combinators_2.12-1.0.7.jar") + ";";
                    basePath += Path.Combine(scalaBasePath, "scala-reflect.jar") + ";";
                    basePath += Path.Combine(scalaBasePath, "scala-swing_2.12-2.0.3.jar") + ";";
                    basePath += Path.Combine(scalaBasePath, "scala-xml_2.12-1.0.6.jar") + ";";
                    basePath += Path.Combine(scalaBasePath, "scalap-2.12.8.jar") + ";";
                    return basePath;
                }
            }
            public override string JVMPath { get { return null; } }

            public void Execute()
            {
                int a = 10;
                int b = 15;
                var scalaClass = DynJVM.ScalaClass.@new();
                var result = scalaClass.add(a, b);
                Console.WriteLine("{0} + {1} = {2}", a, b, result);

                List<string> strings = new List<string>(new string[] { "One", "Two", "Three" });
                var concatString = scalaClass.stringConcat(strings.ToArray());
                Console.WriteLine("{0} = {1}", strings, concatString);

                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
            }
        }
    }
}
