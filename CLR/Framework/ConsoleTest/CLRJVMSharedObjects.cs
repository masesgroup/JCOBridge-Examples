using CommonTest;
using System;

namespace ConsoleTest
{
    partial class TestClass
    {
        public class MyCLRClass
        {
            public int Result { get; private set; }

            public void Add(int a, int b)
            {
                Result = a + b;
            }
        }

        public void SharedObjectsTest()
        {
            /*
            // initilize JCOBridge in JVM context
            dynamic javaBridge;
            try
            {
                this.InitializeRemote();
            }
            catch { }
            javaBridge = RemoteJCOBridge.CreateNew();
            */
            MyCLRClass clrClass = new MyCLRClass();
            RegisterCLRGlobal("MyCLRClass", clrClass);
            var isEqual = GetCLRGlobal("MyCLRClass").Equals(clrClass);
            Console.WriteLine("Objects are equal: {0}", isEqual);

            // we call JVM which will use the shared object to invoke the Add method defined in CLR
            DynJVM.GlobalVariableTest.testMyCLRClass(1, 2);
            // The result of the operation is reflected into CLR Object
            Console.WriteLine("New Result is {0}", clrClass.Result);

            DynJVM.GlobalVariableTest.createGlobal();
            var resultSharedDialog = GetJVMGlobal("SharedDialog");
            resultSharedDialog.Invoke("setVisible", true);
            resultSharedDialog.Invoke("setTitle", "SharedObjectsTest");
        }
    }
}
