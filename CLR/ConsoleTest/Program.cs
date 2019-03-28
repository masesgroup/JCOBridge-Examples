using MASES.JCOBridge.C2JBridge;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                JCOBridge.Initialize("");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                var testClass = new TestClass();
                testClass.ArrayTest();
                testClass.SharedObjectsTest();
                Console.WriteLine("Enter a key to exit.");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key.");
                Console.ReadKey();
            }
        }
    }
}
