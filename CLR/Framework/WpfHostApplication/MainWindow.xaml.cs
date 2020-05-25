using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.Specialized;
using System;
using System.Windows;
using WpfWinFormsJavaApplication;

namespace WpfHostApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JVMWrapper wrapper = null;

        public MainWindow()
        {
            InitializeComponent();
            Title = "Main Windows in WPF .NET Framework";
#if NET_STANDARD
            Title = "Main Windows in WPF .NET Core WindowsDesktop";
#endif
            wrapper = new JVMWrapper();

            wrapper.CreateListener(ActionDone);
            contentCtl1.Content = wrapper.CreateRemoteContent();
        }

        void ActionDone(object sender, CLRListenerEventArgs<CLRActionEventData> args)
        {
           tbOutput.Dispatcher.Invoke(() => tbOutput.Text += wrapper.TextArea.getText() + Environment.NewLine);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbOutput.Text = string.Empty;
        }
    }

    //class JVMWrapper : SetupJVMWrapper
    //{
    //    public JVMWrapper()
    //    {
    //        InitializeRemote();
    //    }

    //    public dynamic TextArea { get; private set; }

    //    public IJCGraphicContainer Container { get; private set; }
    //    public ICLRListener Listener { get; private set; }

    //    public void CreateListener(EventHandler<CLRListenerEventArgs<CLRActionEventData>> handler)
    //    {
    //        Listener = new CLRActionListener(handler);
    //        InitializeListener(Listener);
    //    }

    //    public object CreateRemoteContent()
    //    {
    //        ImportPackage("java.awt");

    //        var panel = DynJVM.Panel.@new();
    //        var layout = DynJVM.GridLayout.@new(2, 1);
    //        panel.setLayout(layout);
    //        TextArea = DynJVM.TextArea.@new("", 10, 40);
    //        panel.add(TextArea);
    //        var button = DynJVM.java.awt.Button.@new("Send TextArea text to Host Application");
    //        button.setActionCommand("sendData");
    //        button.addActionListener(Listener.DynListener);
    //        panel.add(button);
    //        Container = GetJCGraphicContainer(panel, true);
    //        return Container.GraphicObject;
    //    }
    //}
}
