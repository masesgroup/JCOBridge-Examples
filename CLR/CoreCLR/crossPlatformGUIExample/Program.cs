using CommonTest;
using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.Specialized;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.LicenseManager.Common;
using System;

partial class TestClass : BaseTestClass
{
    bool execute = true;
    int counter = 0;
    IJavaObject textArea;
    dynamic buttonWrite;

    void ActionDone(object sender, CLRListenerEventArgs<CLRActionEventData> args)
    {
        try
        {
            if (args.EventData.ActionCommand == "writeTextAreaToConsole")
            {
                var result = textArea.Invoke("getText");
                Console.WriteLine("Text from from AWT TextArea: {0}", result);
            }
            else if (args.EventData.ActionCommand == "writeToConsole")
            {
                counter++;
                Console.WriteLine("{0} Simple Action from JVM", counter);
                buttonWrite.setLabel(string.Format("Write to console for {0} time", counter + 1));
            }
            else if (args.EventData.ActionCommand == "closeApplication")
            {
                Console.WriteLine("Closing...");
                execute = false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public override void Execute()
    {
        ImportPackage("java.lang");
        ImportPackage("java.util");
        ImportPackage("java.awt");

        var listener = new CLRActionListener(ActionDone);

        JVM.InitializeListener(listener);
        var frame = DynJVM.Frame.@new("AWT GUI");

        frame.setSize(300, 300);

        textArea = DynJVM.TextArea.@new();
        buttonWrite = DynJVM.Button.@new("Write to console");
        buttonWrite.setActionCommand("writeToConsole");
        buttonWrite.addActionListener(listener.DynListener);
        var buttonTextAreaWrite = DynJVM.Button.@new("Write TextArea to console");
        buttonTextAreaWrite.setActionCommand("writeTextAreaToConsole");
        buttonTextAreaWrite.addActionListener(listener.DynListener);
        var buttonClose = DynJVM.Button.@new("Close application");
        buttonClose.setActionCommand("closeApplication");
        buttonClose.addActionListener(listener.DynListener);
        var panel = DynJVM.Panel.@new();
        var layout = DynJVM.GridLayout.@new(2, 2);
        panel.setLayout(layout);

        panel.add(textArea);
        panel.add(buttonTextAreaWrite);
        panel.add(buttonWrite); // Adds Button to content pane of frame
        panel.add(buttonClose); // Adds Button to content pane of frame
        frame.add(panel);
        frame.setVisible(true);
        Console.WriteLine("Waiting for close...");
        while (execute)
        {
            System.Threading.Thread.Sleep(10);
        }

        buttonWrite.removeActionListener(listener.DynListener);
        buttonClose.removeActionListener(listener.DynListener);

        JVM.ReleaseListener(listener);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var testClass = new TestClass();
            testClass.Execute();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
    }
}