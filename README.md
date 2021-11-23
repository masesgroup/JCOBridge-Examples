# JCOBridge Examples

## JCOBridge main features

### Field proven

Built on top of the field proven DLR plugin available in the [Sinapse platform](https://www.sinapsesystem.com), JCOBridge guarantees the best performance in JVM and CLR worlds integration.

### JVM ( Available only for .NET Framework on https://www.jcobridge.com, .NET Core available on supported OS and Architectures)
>- Retrieve CLR Type
>- Instantiate CLR object
>- Invoke static methods
>- Invoke instance methods
>- Get/Set static properties
>- Get/Set instance properties
>- Set Delegates
>- Subscribe/Unsubscribe events
>- Integrates WPF controls into AWT/Swing window
>- Integrate WinForms controls into AWT/Swing window
>- Integrate complex .NET Graphical user interfaces objects into AWT/Swing window
>- User interface Controls, properties and events management

### CLR ( Available for .NET Framework on Windows and .NET Core on Windows and Linux, other platforms available on demand )
>- Retrieve JVM class
>- Instantiate JVM objects
>- Invoke static methods
>- Invoke instance methods
>- Get/Set static fields
>- Get/Set instance fields
>- Use dynamic access to write code in a seamless way as it is done in Java language
>- Use specific interface to direct manages methods and fields

# JCOBridge Examples

JCOBridge (JVM-CLR Object Bridge) allows the execution of JVM native languages, like java and scala, from CLR/.NET languages and vice-versa, it allows to import and use libraries, components and also to manage graphical user interface from one programming world to the other.
More information on [www.jcobridge.com](https://www.jcobridge.com)

## The Short way

To explore the examples you need to perform the following steps:
1. Download the last trial release from this [link](https://www.jcobridge.com/wpdownloads/)
2. Install it following the wizard
3. Clone this repository
4. Use directly the executables ready into Output directories, or
5. Enjoy the jcobridge with your preferred development tools

## Repository Content

In this repository it is possible to find example code for the different programming language supported by JCObridge. 
The examples are organized in two main folder, JVM and CLR that contains the relative projects. Before execute the code is needed that examples of both world are compiled, because no runtime compilation of foreign code is done, only execution. 

## .NET to Java Examples

### .NET Core Linux/Windows Graphical User Interface example

The project [Cross Platform GUI](/CLR/CoreCLR/crossPlatformGUIExample/README.md) shows how to use AWT to create a cross-platform graphical user interface for .NET Core on Windows and Linux hosts. To use Swing simply change the controls within the code to your preferred ones.

### Java Class Use Example

This is a basic example where we call the simple class defined in JavaClass.java from a .NET application.
in the /JVM/java/src/JavaClass.java we have a simple class

```Java
public class JavaClass {
    /**
     * This simple method return the "Hello World!!" string
     * * @return "Hello World!!" string
     */
    public String helloWorld()
    {
        return "Hello World from Java!!";
    }
    
    /**
     * This simple method return the sum of two double
     * @param a
     * @param b
     * @return a + b
     */
    public double add(double a, double b)
    {
        return a+b;
    }
    
    /**
     * This simple method return the sin of a double
     * @param a
     * @return sin of a
     */
    public double sin(double a)
    {
        return Math.sin(a);
    }
}
```
in the \CLR\JavaClassUseExample\program.cs we have the simple .NET C# application

```c#
using MASES.LicenseManager.Common;
using MASES.JCBridge.C2JBridge;
using System;

namespace JavaClassUseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestClass().Execute();
        }

        class TestClass : SetupJVMWrapper
        {
            public override string ClassPath { get { return @"..\..\JVM\Output"; } }

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
            }
        }
    }
}

```
Executing the code we have the following output:
```
Hello World from Java!! 2 + 3 = 5 and sin(3,1415927) = 1,00000000
```

### JVM Environment Example

This example is an extension of the _Java Class Use Example_ where Environment parameters are configured in the .NET _TestClass_ class.

```c#

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
### ConsoleTest

This is a more complex application that explores the ability of JCOBridge doing the following operations:
-Execute java code in the .NET environment using the _Dynamic JVM wrapper_
-Manage shared object
-Register CLR object in the Java Virtual Machine side
-Use the registered object from the JVM side
-Call Methods on the JVM registered class and have the operation reflected to the CLR object
-Create dialog in the JVM side and use it from the .NET code

## .NET Libraries for use within the _Java to .NET Examples_

### CSharpClass

This library contain a single class that provide double and string operations to be called from JVM.

### WinFormsTestControl

A Windows Form panel with his complete logic that will be used to demonstrate _User Interface Integration_ in a Java Graphical application.

### WPFTestControl

A WPF panel with his complete logic that will be used to demonstrate _User Interface Integration_ in a Java Graphical application.

## Java to .NET Examples

### CSharp Class Use Examples

This is a basic example where we call the simple class defined in CSharpClass.cs from a Java application.
in the \CLR\CSharpClass\CSharpClass.cs we have a simple class

```c#
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
```

in the /JVM/src/JavaClass.java we have the simple Java application
```java
import java.io.IOException;
import org.mases.jcobridge.*;

public class CSharpClassUseExample {

    public static void main(String[] args) {
        try {
            try {
                try {
                    JCOBridge.Initialize("");
                    } catch (JCException e) {
                        e.printStackTrace();
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
                //declare and create JCOBridge instance
                JCOBridge bridge;
                bridge = JCOBridge.CreateNew();
                // adds the path where extarnal assemblies where found
                bridge.AddPath("../CLR/Output/");
                // add REFERENCES to the .dll file
                bridge.AddReference("CSharpClass");
                // GENERATE Object
                JCObject CSharpObject = (JCObject) bridge.NewObject("MASES.CLRTests.CSharpClass");
                double a = 2;
                double b = 3;
                double c = Math.PI/2;
                //Invoke the C# class methods
                String hello = (String) CSharpObject.Invoke("HelloWorld");
                double result = (double) CSharpObject.Invoke("Add",a, b);
                double sin = (double) CSharpObject.Invoke("Sin", c);
                System.out.println(String.format("%s %.0f + %.0f = %.0f and sin(%.8f) = %.8f", hello, a, b, result, c, sin));
            
            } catch (JCException jce) {
            jce.printStackTrace();
            System.out.println("Exiting");
            return;
        }
    }
}
```
Executing the code we have the following output:
```
Hello World from C#!! 2 + 3 = 5 and sin(3,14159265) = 1,00000000
```

### Windows Forms and WPF User Interface Integration

In this little more complex example we integrate into an awt java user interface two different complex control, taken from two .NET library. 
The first control is a Windows Form, the second one is a WPF object. 
The application in \JVM\Java\srcAWTWinFormsWPF.java expose the complete process from the control reference and generation to the .NET event listener registration to the .NET events callback management.

```java
import java.awt.Frame;
import java.io.IOException;
import org.mases.jcobridge.*;

public class AWTWinFormsWPF implements IJCVoidEventEmit {
    public static void main(String args[]) {
        new AWTWinFormsWPF().createAndShow();
    }

    int cycle = 0;
    java.awt.TextArea gTextArea;

    // WPF
    JCControl gControlWpfControl = null;

    // FORMS
    JCControl gControlFormsControl = null;

    void createAndShow() {
        try {
            // LOGGER
            IJCEventLog logger = null;
            try {
                try {
                    JCOBridge.Initialize("");
                } catch (JCException e) {
                    e.printStackTrace();
                }

                logger = new JCFileEventLog("WinFormsWPF.txt");
            } catch (IOException e) {
                e.printStackTrace();
            }

            JCOBridge bridge;

            bridge = JCOBridge.CreateNew();
            bridge.RegisterEventLog(logger);
            // adds the path where extarnal assemblies where found
            bridge.AddPath("../../CLR/Output/");

            // add REFERENCES
            bridge.AddReference("WPFTestControl");
            bridge.AddReference("WinFormsTestControl");

            // GENERATE CONTROLS
            gControlWpfControl = bridge.GetControl("MASES.CLRTests.WPFTestControl.TestControl");
            gControlFormsControl = bridge.GetControl("MASES.CLRTests.WinFormsTestControl.TestControl");

            // CONFIGURE CONTROLS
            gControlWpfControl.RegisterEventListener("FromComboBox", this);
            gControlWpfControl.RegisterEventListener("FromTextBox", this);

            gControlFormsControl.RegisterEventListener("FromComboBox", this);
            gControlFormsControl.RegisterEventListener("FromTextBox", this);

            Frame dialog = new Frame();
            gTextArea = new java.awt.TextArea();
            gTextArea.setText("This is an AWT TextArea");

            java.awt.GridLayout layout = new java.awt.GridLayout(2, 2);

            dialog.setLayout(layout);
            dialog.add(gControlWpfControl);
            dialog.add(gControlFormsControl);
            dialog.add(gTextArea);
            dialog.validate();
            dialog.setTitle("WinForms-WPF AWT integration");
            dialog.setVisible(true);
            dialog.setSize(200, 200);

        } catch (JCException jce) {
            jce.printStackTrace();
            System.console().readLine("Please press enter");

            System.out.println("Exiting");
            return;
        }
    }

    @Override
    public void EventRaised(Object... args) {
        System.out.println("EventRaised");
        if (args[1] instanceof JCObject) {
            JCObject obj = (JCObject) args[1];
            System.out.println();
            try {
                if (obj != null) {
                    gTextArea.setText("Text area: event: " + obj.toString() + " Content: " + obj.Get("Content"));
                }
            } catch (JCException e) {
                e.printStackTrace();
            }
        }
    }
}
```
## Classes to be used from the CLR test applications

### JavaClass

A single class that provide double and string operations to be called from the .NET CLR.

### GlobalVariableTest

A class that contains two methods and display how to register and use Shared global variables and object

```java
import org.mases.jcobridge.*;
import java.awt.*;

public class GlobalVariableTest
{
    public static void createGlobal() throws JCException
    {
        Dialog dialog = new Dialog((Dialog)null);
        JCOBridge.RegisterJVMGlobal("SharedDialog", dialog);
    }
    
    public static void testMyCLRClass(Integer a, Integer b) throws JCException
    {
        JCObject resultGetCLRObject = (JCObject)JCOBridge.GetCLRGlobal("MyCLRClass");
        resultGetCLRObject.Invoke("Add", a, b);
    }
}
```
The createGlobal method create a global awt dialog and register it to be used seamlessly from the CLR side.
The testMyCLRClass show how to use a registered CLR global object, in the CLR example we create this object from the .NET side and we call this function to use it and demonstrate hot operations are reflected between JVM and CLR in a transparent manner. 

## .NET to Scala Example

A simple Scala class is defined to be used from CLR in JVM\Scala\scalaclass\src\main\scala\ScalaClass.class
Call compile and execute batch script in JVM\Scala\
Before call compile and execute batch script Scala [binaries](https://downloads.lightbend.com/scala/2.12.8/scala-2.12.8.msi) shall be installed.

```java
import java.lang._

final class ScalaClass(aString: String, val anInteger: Int) {
    def this() {
        this("defaultString", -1)
    }

    def this(aBool: Boolean) {
        this("defaultString", -1)
    }

    val scalaString = "This is a Scala String"

    def add(x: Int, y: Int): Int = x + y

    def stringConcat(args: Array[String]): String = 
    {
        return args.mkString(", ")
    }
}
```

In the \CLR\ScalaClassUseExample\Program.cs we have a simple application that use the defined ScalaClass 

```c#
using CommonTest;
using MASES.JCOBridge.C2JBridge;
using MASES.LicenseManager.Common;
using System;
using System.IO;

namespace ScalaClassUseExample
{
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
}

```
In Scala all the needed libraries shall be explicitly added to the base path.  

## Scala to .NET Example

In this example we call .NET object from Scala language via JCOBridge.
Before call compile and execute batch script Scala [binaries](https://downloads.lightbend.com/scala/2.12.8/scala-2.12.8.msi) shall be installed.


```java
import java.util.Iterator
import org.mases.jcobridge._

object Main extends App {
  try
  {
    JCOBridge.Initialize();
  }
  catch
  {
    // catch to avoid problem with Trial mode of JCOBridge
    case jce: JCException => System.out.println(jce.getMessage)
  }

  val bridge = JCOBridge.CreateNew()

  // adds a new reference to WPF 
  bridge.AddReference("PresentationFramework")
  // get MessageBox type
  val msgType = bridge.GetType("System.Windows.MessageBox")
  // invoke static method to show a message box on the screen
    msgType.Invoke("Show", "Please press enter to continue")

  // get .NET type
  val enumType = bridge.GetType("System.Environment")
  // invokes static method
    val genObj = enumType.Invoke("GetLogicalDrives")
  // retrieve the iterator
  val iteratorObj = genObj.asInstanceOf[JCObject].iterator
  // iterate on all object and print the value
  while (iteratorObj.hasNext) println(iteratorObj.next)

  // invoke static method to show a message box on the screen
    msgType.Invoke("Show", "Please press enter")

  // event callback example
  val tObj = bridge.NewObject("System.Timers.Timer"); // create the timer object
  val timerObj = tObj.asInstanceOf[JCObject];
  // register an event handler when the Timer elaps
  timerObj.RegisterEventListener("Elapsed", new ScalaJCVoidEventEmit()); 
  // set Interval property
  timerObj.Set("Interval", 1000); // set properties
  // enable the Timer
  timerObj.Set("Enabled", true); // start timer

  // invoke static method to show a message box on the screen
    msgType.Invoke("Show", "Please press enter")
}

final class ScalaJCVoidEventEmit() extends JCVoidEventEmit {
  override def EventRaised(args: Object*) : Unit =
  {
        // scala seems to have a problem to translate var args argument into JVM bytecode. This method is needed to avoid compilation problems
  }
  // this method defines exactly the signature expected from the event
  def EventRaised(sender: Object, arg: Object) : Unit =
  {
        println("Timer Elapsed")
  }
}
```
