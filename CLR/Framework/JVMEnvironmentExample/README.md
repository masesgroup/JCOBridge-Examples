### JVM Environment Example

This example is an extension of the _Java Class Use Example_ where Environment parameters are configured in the .NET _TestClass_ class.

```c

class TestClass : SetupJVMWrapper
{
    // the following line setup the classpath where JVM will search for classes
    // during runtime it is possible to dynamically add other path using a call like DynJVM.JVMHelper.addPath(<the path to add>);
    public override string ClassPath { get { return @"C:\Program Files\MASES Group\JCOB\Core;..\..\JVM\Java\Output"; } }

    // uncomment the following line and set the correct JRE if the automatic search system fails
    // public override string JVMPath { get { return @"C:\Program Files\Java\jre1.8.0_121\bin\server\jvm.dll"; } }

    // the following code adds all possible switch to the starting JVM.
    // for a complete list see Oracle documentation: https://docs.oracle.com/javase/8/docs/technotes/tools/windows/java.html
    public override IEnumerable<KeyValuePair<string, string>> JVMOptions
    {
        get
        {
            var dict = new Dictionary<string, string>();
            dict.Add("-Xmx128M", null); // this line adds a complete argument
            // dict.Add(property, value); // this line adds an argument like -Dproperty = value

            return dict;
        }
    }

    // the following code adds initial packages to the import statement.
    public override IEnumerable<string> JVMPackages
    {
        get
        {
            var list = new List<string>();
            list.Add("java.lang"); // this line adds java.lang.* like you do with "import java.lang.*" in Java
            return list;
        }
    }

    // uncomment and set the following line when you need features of JDK like the use of the compiler
    // public override string JDKHome { get { return @"C:\Program Files\Java\jdk1.8.0_121\"; } }

    public void Execute()
    {
        double a = 2;
        double b = 3;
        double c = Math.PI/2;
        var javaClass = DynJVM.JavaClass.@new();
        string hello = javaClass.helloWorld();
        double result = javaClass.add(a, b);
        double sin = javaClass.sin(c);
        Console.WriteLine("{0} {1} + {2} = {3} and sin({4:0.0000000}) = {5:0.00000000}", hello, a, b, result, c, sin);
        Console.WriteLine("Press Enter to exit");
        Console.ReadLine();
    }
}

```