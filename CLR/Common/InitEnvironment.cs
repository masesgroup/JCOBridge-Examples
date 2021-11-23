using MASES.JCOBridge.C2JBridge;
using System.Collections.Generic;

namespace CommonTest
{
    class BaseTestClass : SetupJVMWrapper
    {
        public virtual string GetProjectClassPath()
        {
            return string.Empty;
        }

        public virtual void Execute()
        {

        }

        // change if needed or use command line argument --JNIVerbosity
        public override string JNIVerbosity { get { return base.JNIVerbosity; } }
        // change if needed or use command line argument --JNIOutputFile
        public override string JNIOutputFile { get { return base.JNIOutputFile; } }
        // change if needed or use command line argument --ClassPath

        // the following line setup the classpath where JVM will search for classes
        // during runtime it is possible to dynamically add other path using a call like DynJVM.JVMHelper.addPath(<the path to add>);
        public override string ClassPath
        {
            get
            {
                if (string.IsNullOrEmpty(base.ClassPath)) return GetProjectClassPath();
                else return base.ClassPath + ClassPathBuilder.PathSeparator + GetProjectClassPath();
            }
        }

        // change if needed or use command line argument --JVMOptions
        // the following code or commandline switch --JVMOptions adds all possible switch to the starting JVM.
        // for a complete list see Oracle documentation: https://docs.oracle.com/javase/8/docs/technotes/tools/windows/java.html
        public override IEnumerable<KeyValuePair<string, string>> JVMOptions
        {
            get
            {
                var dict = new Dictionary<string, string>();
                if (base.JVMOptions != null)
                {
                    foreach (var item in base.JVMOptions)
                    {
                        dict.Add(item.Key, item.Value);
                    }
                }

                dict.Add("-Xmx128M", null);
                return dict;
            }
        }

        // change if needed or use command line argument --JVMPackages
        public override IEnumerable<string> JVMPackages
        {
            get
            {
                var list = new List<string>();
                if (base.JVMPackages != null)
                {
                    list.AddRange(base.JVMPackages);
                }
                list.Add("java.lang"); // this line adds java.lang.* like you do with "import java.lang.*" in Java
                return list;
            }
        }

        // change if needed or use command line argument --JVMPath
        public override string JVMPath
        {
            get
            {
                return base.JVMPath;
            }
        }
    }
}
