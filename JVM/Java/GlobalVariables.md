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
