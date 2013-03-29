namespace Nsim
{
    using Microsoft.Win32;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class MainWindow : Window, System.Windows.Markup.IComponentConnector, x759d1c29622e3303
    {
        private bool _x7dc3d9d322900926;
        internal Button btnLoadProject;
        internal Button btnResetProject;
        internal Button btnSaveProject;
        internal Button btnTest;
        internal DataSetEditor checkDataEditor;
        internal ErrorGraphControl errCtl;
        internal DataSetEditor prognozDataEditor;
        internal TabItem tabItem1;
        internal TabItem tabItem2;
        internal TabItem tabItem3;
        internal TabItem tabItem4;
        internal DataSetEditor testDataEditor;
        internal DataSetEditor trainDataEditor;
        internal TabItem trainGraphTab;
        internal TabControl trainTabControl;

        public MainWindow()
        {
            RoutedEventHandler handler = null;
            this.InitializeComponent();
            if (handler == null)
            {
                handler = new RoutedEventHandler(this.xf29670e286f5562f);
            }
            base.Loaded += handler;
            App.Services.RegisterService<x759d1c29622e3303>(this);
        }

        [DebuggerNonUserCode]
        internal Delegate _x11287467a5422d1c(Type x127370c996b87499, string xa1b13fd4a6c07a01)
        {
            return Delegate.CreateDelegate(x127370c996b87499, this, xa1b13fd4a6c07a01);
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            while (flag)
            {
                this._x7dc3d9d322900926 = true;
                do
                {
                    Uri resourceLocator = new Uri("/Nsim4;component/mainwindow.xaml", UriKind.Relative);
                    Application.LoadComponent(this, resourceLocator);
                }
                while ((((uint) flag) - ((uint) flag)) < 0);
                if ((((uint) flag) & 0) == 0)
                {
                    break;
                }
            }
        }

        public void LoadFromFile(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                x0273dd79e8d1b120(stream);
            }
            finally
            {
                bool flag = stream == null;
                if ((((uint) flag) & 0) != 0)
                {
                    goto Label_0037;
                }
            Label_0032:
                if (!flag)
                {
                    goto Label_0041;
                }
                goto Label_0049;
            Label_0037:
                if (0 != 0)
                {
                    goto Label_0032;
                }
                if (0 == 0)
                {
                }
                goto Label_0049;
            Label_0041:
                stream.Dispose();
                goto Label_0037;
            Label_0049:;
            }
        }

        public void SaveToFile(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            try
            {
                xa2e0b7f7da663553(stream);
            }
            finally
            {
                bool flag = stream == null;
                while (!flag)
                {
                    stream.Dispose();
                    break;
                }
            }
        }

        private static void x0273dd79e8d1b120(Stream xcf18e5243f8d5fd3)
        {
            App.Services.GetService<x1a44f162f55467a5>().Xml = XDocument.Load(xcf18e5243f8d5fd3).Element("NeuroProject");
        }

        private void x111eefcd91d0be4c()
        {
            Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Nsim.default.np4");
            try
            {
                x0273dd79e8d1b120(manifestResourceStream);
            }
            finally
            {
                bool flag = manifestResourceStream == null;
                while (!flag)
                {
                    manifestResourceStream.Dispose();
                    break;
                }
            }
        }

        private FrameworkElement x27e59b8f83742ff6(string xfaae2e7b9ce18346)
        {
            return (base.FindName(xfaae2e7b9ce18346) as FrameworkElement);
        }

        private void x3bfd9579f67e8a28(object xe0292b9ed559da7d, RoutedEventArgs xfbf34718e704c6bc)
        {
            this.x111eefcd91d0be4c();
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
        Label_01FC:
            switch (num)
            {
                case 1:
                    this.btnSaveProject = (Button) x11d58b056c032b03;
                    this.btnSaveProject.Click += new RoutedEventHandler(this.xa50cb9ae13c06d8a);
                    return;

                case 2:
                    this.btnLoadProject = (Button) x11d58b056c032b03;
                    if ((((uint) xf3efd21c486a5cce) - ((uint) xf3efd21c486a5cce)) >= 0)
                    {
                        if ((((uint) num) - ((uint) num)) >= 0)
                        {
                            this.btnLoadProject.Click += new RoutedEventHandler(this.x825b45ff6339d640);
                            return;
                        }
                        goto Label_011B;
                    }
                    goto Label_01FC;

                case 3:
                    this.btnResetProject = (Button) x11d58b056c032b03;
                    this.btnResetProject.Click += new RoutedEventHandler(this.x3bfd9579f67e8a28);
                    if ((((uint) xf3efd21c486a5cce) + ((uint) xf3efd21c486a5cce)) < 0)
                    {
                        break;
                    }
                    return;

                case 4:
                    this.btnTest = (Button) x11d58b056c032b03;
                    if ((((uint) num) | 0x80000000) != 0)
                    {
                    }
                    return;

                case 5:
                    this.tabItem1 = (TabItem) x11d58b056c032b03;
                    return;

                case 6:
                    this.tabItem2 = (TabItem) x11d58b056c032b03;
                    return;

                case 7:
                    goto Label_011B;

                case 8:
                    goto Label_00E8;

                case 9:
                    this.testDataEditor = (DataSetEditor) x11d58b056c032b03;
                    return;

                case 10:
                    this.trainGraphTab = (TabItem) x11d58b056c032b03;
                    return;

                case 11:
                    this.errCtl = (ErrorGraphControl) x11d58b056c032b03;
                    return;

                case 12:
                    goto Label_0080;

                case 13:
                    this.checkDataEditor = (DataSetEditor) x11d58b056c032b03;
                    if ((((uint) num) - ((uint) xf3efd21c486a5cce)) >= 0)
                    {
                        return;
                    }
                    break;

                case 14:
                    this.tabItem4 = (TabItem) x11d58b056c032b03;
                    return;

                case 15:
                    this.prognozDataEditor = (DataSetEditor) x11d58b056c032b03;
                    return;
            }
            this._x7dc3d9d322900926 = true;
            if ((((uint) num) - ((uint) xf3efd21c486a5cce)) < 0)
            {
            }
            return;
        Label_0080:
            this.tabItem3 = (TabItem) x11d58b056c032b03;
            if (15 != 0)
            {
                return;
            }
            if ((((uint) xf3efd21c486a5cce) + ((uint) xf3efd21c486a5cce)) < 0)
            {
                return;
            }
        Label_00E8:
            this.trainDataEditor = (DataSetEditor) x11d58b056c032b03;
            if ((((uint) xf3efd21c486a5cce) - ((uint) xf3efd21c486a5cce)) >= 0)
            {
                return;
            }
            goto Label_0080;
        Label_011B:
            this.trainTabControl = (TabControl) x11d58b056c032b03;
        }

        private void x825b45ff6339d640(object xe0292b9ed559da7d, RoutedEventArgs xfbf34718e704c6bc)
        {
            bool flag;
            OpenFileDialog dialog2 = new OpenFileDialog();
        Label_0044:
            dialog2.Filter = "Файлы нейросимулятора 4|*.np4";
            OpenFileDialog dialog = dialog2;
            bool? nullable = dialog.ShowDialog(this);
            if (((uint) flag) <= uint.MaxValue)
            {
                flag = !(nullable.GetValueOrDefault() && nullable.HasValue);
                if (!flag)
                {
                    this.LoadFromFile(dialog.FileName);
                    if (((uint) flag) < 0)
                    {
                        goto Label_0044;
                    }
                }
            }
        }

        private static void xa2e0b7f7da663553(Stream xcf18e5243f8d5fd3)
        {
            XDocument document = new XDocument();
            document.Add(App.Services.GetService<x1a44f162f55467a5>().Xml);
            document.Save(xcf18e5243f8d5fd3);
        }

        private void xa50cb9ae13c06d8a(object xe0292b9ed559da7d, RoutedEventArgs xfbf34718e704c6bc)
        {
            // This item is obfuscated and can not be translated.
        }

        [CompilerGenerated]
        private void xf29670e286f5562f(object x08db3aeabb253cb1, RoutedEventArgs xfbf34718e704c6bc)
        {
            this.x111eefcd91d0be4c();
        }
    }
}

