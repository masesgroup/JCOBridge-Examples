using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASES.CLRTests.WinFormsTestControl
{
    public class WinFormsTestControlEventArgs : EventArgs
    {
        public WinFormsTestControlEventArgs(string content)
        {
            Content = content;
        }

        public string Content { get; private set; }
    }

}
