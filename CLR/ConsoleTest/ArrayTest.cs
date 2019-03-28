using System;

namespace ConsoleTest
{
    partial class TestClass
    {
       public void ArrayTest()
        {
            JVM.ImportPackage("java.lang");
            JVM.ImportPackage("java.util");
            int length = 100;
            var array = DynJVM.ArrayList.@new(length);

            for (int i = 0; i < length; i++)
            {
                var str = DynJVM.String.@new("Value is " + i);
                array.add(str);
                str = DynJVM.String.@new("New Value is " + i);
                array.set(i, str);
                var str1 = array.get(i);
                if (i % 10 == 0)
                {
                    Console.WriteLine(string.Format("{0} ", str1));
                }
            }
        }
    }
}
