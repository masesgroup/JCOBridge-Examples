
import java.io.IOException;
import org.mases.jcobridge.*;

public class CSharpClassExtendedUseExample {

	public static String TheField = "";

	public static void main(String[] args) {
		try {
			try {
				try {
					JCOBridge.Initialize();
				} catch (JCException e) {
					e.printStackTrace();
				}
			} catch (IOException e) {
				e.printStackTrace();
			}
			// declare and create JCOBridge instance
			JCOBridge bridge;
			bridge = JCOBridge.CreateNew();
			// adds the path where external assemblies where found
			bridge.AddPath("../../CLR/Output/");
			// add REFERENCES to the .dll file
			bridge.AddReference("CSharpClassExtended");
			// GENERATE Object
			JCObject CSharpObject = (JCObject) bridge.NewObject("MASES.CLRTests.CSharpClassExtended");
			double a = 2;
			double b = 3;
			double c = Math.PI;
			// Invoke the C# class methods
			String hello = (String) CSharpObject.Invoke("HelloWorld");
			double result = (double) CSharpObject.Invoke("Add", a, b);
			double sin = (double) CSharpObject.Invoke("Sin", c);

			TheField = String.format("%s %.0f + %.0f = %.0f and sin(%.8f) = %.8f", hello, a, b, result, c, sin);

			System.out.println(TheField);

			String echoStr = (String) CSharpObject.Invoke("EchoString");

			if (echoStr.equals(TheField)) System.out.println("TheField and echo from CLR are equals.");

		} catch (JCException jce) {
			jce.printStackTrace();
			System.out.println("Exiting");
			return;
		}
	}
}
