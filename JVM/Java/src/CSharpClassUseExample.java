
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
			// declare and create JCOBridge instance
			JCOBridge bridge;
			bridge = JCOBridge.CreateNew();
			// adds the path where extarnal assemblies where found
			bridge.AddPath("../../CLR/Output/");
			// add REFERENCES to the .dll file
			bridge.AddReference("CSharpClass");
			// GENERATE Object
			JCObject CSharpObject = (JCObject) bridge.NewObject("MASES.CLRTests.CSharpClass");
			double a = 2;
			double b = 3;
			double c = Math.PI;
			// Invoke the C# class methods
			String hello = (String) CSharpObject.Invoke("HelloWorld");
			double result = (double) CSharpObject.Invoke("Add", a, b);
			double sin = (double) CSharpObject.Invoke("Sin", c);
			System.out
					.println(String.format("%s %.0f + %.0f = %.0f and sin(%.8f) = %.8f", hello, a, b, result, c, sin));

		} catch (JCException jce) {
			jce.printStackTrace();
			System.out.println("Exiting");
			return;
		}
	}
}
