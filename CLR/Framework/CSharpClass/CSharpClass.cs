using System;

namespace MASES.CLRTests
{
    public class CSharpClass
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
    }
}
