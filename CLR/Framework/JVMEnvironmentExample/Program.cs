using CommonTest;
using MASES.JCOBridge.C2JBridge;
using MASES.LicenseManager.Common;
using System;
using System.Collections.Generic;

namespace JavaClassUseExample
{
    class TestClass : BaseTestClass
    {
        public override string GetProjectClassPath()
        {
#if !JCOBRIDGE_CORE
            return @"..\..\JVM\Java\Output";
#else
            return @"..\..\..\JVM\Java\Output";
#endif
        }

        public override void Execute()
        {
            var javaClass = DynJVM.JavaClass.@new();
            double a = 2;
            double b = 3;
            double c = Math.PI;
            string hello = javaClass.helloWorld();
            double result = javaClass.add(a, b);
            double sin = javaClass.sin(c);
            Console.WriteLine("{0} {1} + {2} = {3} and sin({4:0.0000000}) = {5:0.00000000}", hello, a, b, result, c, sin);
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

