namespace Nsim
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime;
    using System.Windows;
    using System.Windows.Threading;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class App : Application
    {
        private bool _x7dc3d9d322900926;
        private static ServiceProvider _xdc2614fb286b7e33;

        public App()
        {
            while (true)
            {
                if (0 == 0)
                {
                    GCSettings.LatencyMode = GCLatencyMode.Batch;
                    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(App.x61d76c7e178c32c4);
                    Services.RegisterService<x63523dbec506f4f5>(new xc478ae75e9f25d3f());
                }
                Services.RegisterService<x1a44f162f55467a5>(new x1a44f162f55467a5());
                Services.RegisterService<x15b8c53ba4818b71>(new Config());
                base.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(this.x80242a3b70091154);
                if (0 == 0)
                {
                    return;
                }
            }
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            Uri uri;
            bool flag = !this._x7dc3d9d322900926;
            if (0 == 0)
            {
                while (!flag)
                {
                    return;
                }
                if ((((uint) flag) | 2) == 0)
                {
                    return;
                }
                this._x7dc3d9d322900926 = true;
                base.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
                uri = new Uri("/Nsim4;component/app.xaml", UriKind.Relative);
            }
            Application.LoadComponent(this, uri);
        }

        [STAThread, DebuggerNonUserCode]
        public static void Main()
        {
            App app = new App();
            app.InitializeComponent();
            app.Run();
        }

        private static Assembly x61d76c7e178c32c4(object xe0292b9ed559da7d, ResolveEventArgs xce8d8c7e3c2c2426)
        {
            Assembly assembly2;
            bool flag;
            AssemblyName name = new AssemblyName(xce8d8c7e3c2c2426.Name);
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            if (4 != 0)
            {
                flag = executingAssembly.GetManifestResourceNames().Contains<string>("Nsim.ThirdParty." + name.Name + ".dll");
                if (0 == 0)
                {
                    if (!flag)
                    {
                        goto Label_00FD;
                    }
                }
                else
                {
                    goto Label_00FD;
                }
            }
            Stream manifestResourceStream = executingAssembly.GetManifestResourceStream("Nsim.ThirdParty." + name.Name + ".dll");
            try
            {
                flag = manifestResourceStream != null;
                while (flag)
                {
                    byte[] buffer = new byte[manifestResourceStream.Length];
                    manifestResourceStream.Read(buffer, 0, buffer.Length);
                    assembly2 = Assembly.Load(buffer);
                    if (8 == 0)
                    {
                        break;
                    }
                    return assembly2;
                }
                return null;
            }
            finally
            {
                flag = manifestResourceStream == null;
                if ((((uint) flag) > uint.MaxValue) || ((((uint) flag) - ((uint) flag)) >= 0))
                {
                    goto Label_00BE;
                }
            Label_00B5:
                manifestResourceStream.Dispose();
                goto Label_00C2;
            Label_00BE:
                if (!flag)
                {
                    goto Label_00B5;
                }
            Label_00C2:;
            }
            return assembly2;
        Label_00FD:
            assembly2 = null;
            if ((((uint) flag) | uint.MaxValue) == 0)
            {
            }
            return assembly2;
        }

        private void x80242a3b70091154(object xe0292b9ed559da7d, DispatcherUnhandledExceptionEventArgs xfbf34718e704c6bc)
        {
            MessageBox.Show(xfbf34718e704c6bc.Exception.ToString());
        }

        public static ServiceProvider Services
        {
            get
            {
                return (_xdc2614fb286b7e33 ?? (_xdc2614fb286b7e33 = new ServiceProvider()));
            }
        }
    }
}

