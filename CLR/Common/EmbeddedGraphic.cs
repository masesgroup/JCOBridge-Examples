
using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.Specialized;
using System;

namespace WpfWinFormsJavaApplication
{
    class JVMWrapper : SetupJVMWrapper
    {
        public dynamic TextArea { get; private set; }

        public IJCGraphicContainer Container { get; private set; }
        public ICLRListener Listener { get; private set; }

        public void CreateListener(EventHandler<CLRListenerEventArgs<CLRActionEventData>> handler)
        {
            Listener = new CLRActionListener(handler);
            InitializeListener(Listener);
        }

        public object CreateRemoteContent()
        {
            ImportPackage("java.awt");

            var panel = DynJVM.Panel.@new();
            var layout = DynJVM.GridLayout.@new(2, 1);
            panel.setLayout(layout);
            TextArea = DynJVM.TextArea.@new("", 10, 40);
            panel.add(TextArea);
            var button = DynJVM.java.awt.Button.@new("Send TextArea text to Host Application");
            button.setActionCommand("sendData");
            button.addActionListener(Listener.DynListener);
            panel.add(button);
#if WINFORMS
            Container = GetJCGraphicContainer(panel, false);
#else
            Container = GetJCGraphicContainer(panel, true);
#endif
            return Container.GraphicObject;
        }
    }
}