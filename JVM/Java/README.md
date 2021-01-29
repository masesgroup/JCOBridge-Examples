## Java to .NET Examples
### CSharp Class Use Examples

** Examples related to .NET 5 needs to execute a compilation of CoreCLR.sln (See README.md in CLR\CoreCLR)

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
