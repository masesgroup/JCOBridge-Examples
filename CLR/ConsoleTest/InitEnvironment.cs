using MASES.JCOBridge.C2JBridge;
using System.Collections.Generic;

namespace ConsoleTest
{
    partial class TestClass : SetupJVMWrapper
    {
        public override string JNIVerbosity { get { return null; } } 

        public override string JNIOutputFile { get { return null; } }

        // uncomment the following line and set the correct JRE if the automatic search system fails
        // public override string JVMPath { get { return @"C:\Program Files\Java\jre1.8.0_121\bin\server\jvm.dll"; } }

        public override string ClassPath
        {
            get
            {
                return @"C:\Program Files\MASES Group\JCOB\Core;..\..\JVM\Java\Output";
            }
        }

        public override IEnumerable<KeyValuePair<string, string>> JVMOptions
        {
            get
            {
                var dict = new Dictionary<string, string>();
                dict.Add("-Xmx128M", null);

                return dict;
            }
        }

        public override IEnumerable<string> JVMPackages
        {
            get
            {
                return null;
            }
        }

        public override string JVMPath
        {
            get
            {
                return null;
            }
        }
    }
}
