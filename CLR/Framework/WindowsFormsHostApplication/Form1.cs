using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.Specialized;
using System;
using System.Windows.Forms;
using WpfWinFormsJavaApplication;

namespace WindowsFormsHostApplication
{
    public partial class Form1 : Form
    {
        JVMWrapper wrapper = null;

        public Form1()
        {
            InitializeComponent();
            Text = "Main Windows in WinForms .NET Framework";
#if NET_STANDARD
            Text = "Main Windows in WinForms .NET Core WindowsDesktop";
#endif
            wrapper = new JVMWrapper();

            wrapper.CreateListener(ActionDone);
            var javaControlWrapper = wrapper.CreateRemoteContent() as Control;
            javaControlWrapper.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(javaControlWrapper, 1, 0);
        }

        void ActionDone(object sender, CLRListenerEventArgs<CLRActionEventData> args)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new MethodInvoker(delegate { textBox1.Text += wrapper.TextArea.getText() + Environment.NewLine; }));
            }
            else
            {
                textBox1.Text += args.EventData.ActionCommand + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
    }

    //class JVMWrapper : SetupJVMWrapper
    //{
    //    public JVMWrapper()
    //    {
    //        InitializeRemote();
    //    }

    //    public IJCGraphicContainer Container { get; private set; }
    //    public ICLRListener Listener { get; private set; }

    //    public void CreateListener(EventHandler<CLRListenerEventArgs<CLRActionEventData>> handler)
    //    {
    //        Listener = new CLRActionListener(handler);
    //        InitializeListener(Listener);
    //    }

    //    public object CreateRemoteContent(string buttonText)
    //    {
    //        var button = DynJVM.java.awt.Button.@new(buttonText);
    //        button.setActionCommand(buttonText);
    //        button.addActionListener(Listener.DynListener);
    //        Container = GetJCGraphicContainer(button, false);
    //        return Container.GraphicObject;
    //    }
    //}
}
