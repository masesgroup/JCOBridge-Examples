using MASES.JCOBridge.C2JBridge;
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
            public override string ClassPath { get { return @"C:\Program Files\MASES Group\JCOB\Core;..\..\JVM\Java\Output"; } }
            // uncomment the following line and set the correct JRE if the automatic search system fails
            // public override string JVMPath { get { return @"C:\Program Files\Java\jre1.8.0_121\bin\server\jvm.dll"; } }

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
    }
}
