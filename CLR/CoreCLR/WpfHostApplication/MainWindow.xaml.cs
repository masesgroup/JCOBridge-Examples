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
}
