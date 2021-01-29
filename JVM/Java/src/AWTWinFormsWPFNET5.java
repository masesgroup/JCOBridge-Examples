import java.awt.Frame;
import java.io.IOException;
import org.mases.jcobridge.*;

public class AWTWinFormsWPFNET5 implements IJCVoidEventEmit {
	public static void main(String args[]) {
		new AWTWinFormsWPFNET5().createAndShow(args);
	}

	int cycle = 0;
	java.awt.TextArea gTextArea;

	// WPF
	JCControl gControlWpfControl = null;

	// FORMS
	JCControl gControlFormsControl = null;

	void createAndShow(String args[]) {
		try {
			// LOGGER
			IJCEventLog logger = null;
			try {
				try {
					JCOBridge.Initialize(args);
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
			bridge.AddPath("../../CLR/OutputCore/net5.0-windows/");

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