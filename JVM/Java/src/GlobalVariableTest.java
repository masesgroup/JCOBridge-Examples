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