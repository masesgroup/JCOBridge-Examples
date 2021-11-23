using CommonTest;
using MASES.JCOBridge.C2JBridge;
using System;

namespace ScalaClassUseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new TestClass().Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key.");
                Console.ReadKey();
            }
        }
    }

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
                return new ClassPathBuilder(GetProjectClassPath() + @"\*", @"C:\Program Files (x86)\scala\lib\*.jar").Build();
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
}
