using CommonTest;
using MASES.JCOBridge.C2JBridge;
using MASES.LicenseManager.Common;
using System;

namespace ConsoleTest
{
    partial class TestClass : BaseTestClass
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
            ArrayTest();
#if !JCOBRIDGE_CORE
            try
            {
                InitializeRemote();
            }
            catch (FallbackInTrialModeException) { }

            SharedObjectsTest();
#endif
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
                var testClass = new TestClass();
                testClass.Execute();
                Console.WriteLine("Enter a key to exit.");
                Console.ReadKey();
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
