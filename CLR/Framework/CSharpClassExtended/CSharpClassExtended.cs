using MASES.JCOBridge.C2JBridge;
using System;

namespace MASES.CLRTests
{
    public class CSharpClassExtended
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

        public String EchoString()
        {
            // Returns the field from the JVM - This method in this example will be called from JVM itself to create an echo loop
            return new JVMWrapperApp().GetStringField();
        }
    }

    class JVMWrapperApp : SetupJVMWrapper
    {
        public string GetStringField()
        {
            ImportPackage("java.lang");
            ImportPackage("java.util");

            // Ask JVM for the static field TheField of the class JavaNativeApp
            var str = DynJVM.CSharpClassExtendedUseExample.TheField;
            Console.WriteLine("Output from JVM: {0}", str);
            return str;
        }
    }
}
