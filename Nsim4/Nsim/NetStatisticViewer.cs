namespace Nsim
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class NetStatisticViewer : UserControl, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        internal TextBlock tbLinksCount;
        internal TextBlock tbNeuronsCount;
        [CompilerGenerated]
        private static Func<ILayerStruct, int> x31af784cbc72c68d;

        public NetStatisticViewer()
        {
            this.InitializeComponent();
            App.Services.SubscribeEvent<xa443afcc736e1f3e>(new Action<xa443afcc736e1f3e>(this.x2c196582986b2b4d));
            this.RebuldView();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            while (flag)
            {
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/structure/statistics/netstatisticviewer.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
                if ((0 != 0) || (((uint) flag) <= uint.MaxValue))
                {
                    return;
                }
                if (8 == 0)
                {
                }
            }
        }

        public void RebuldView()
        {
            ILayerStruct[] structArray;
            int num4;
            INetStruct service = App.Services.GetService<INetStruct>();
            if (x31af784cbc72c68d == null)
            {
                x31af784cbc72c68d = new Func<ILayerStruct, int>(null, (IntPtr) xff77519d643268a0);
            }
            int num = (service.InputLayer.Size + service.OutputLayer.Size) + Enumerable.Sum<ILayerStruct>(service.HiddenLayers.Layers, x31af784cbc72c68d);
            List<ILayerStruct> list = new List<ILayerStruct>();
            do
            {
                list.Add(service.InputLayer);
                list.AddRange(service.HiddenLayers.Layers);
                list.Add(service.OutputLayer);
            }
            while (0 != 0);
            int num2 = 0;
        Label_00D6:
            structArray = list.ToArray();
            int index = 0;
        Label_0011:
            if (index >= (structArray.Length - 1))
            {
                num4 = num - service.InputLayer.Size;
                this.tbLinksCount.Text = num2.ToString() + " (+ " + num4.ToString() + " смещений)";
                this.tbNeuronsCount.Text = num.ToString();
                if ((((uint) num4) - ((uint) num4)) <= uint.MaxValue)
                {
                    return;
                }
            }
            else
            {
                num2 += structArray[index].Size * structArray[index + 1].Size;
                index++;
                if ((((uint) num4) & 0) == 0)
                {
                    goto Label_0011;
                }
                return;
            }
            goto Label_00D6;
        }

        private void x2c196582986b2b4d(xa443afcc736e1f3e x0f2e289ed0560f6a)
        {
            this.RebuldView();
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            switch (xf3efd21c486a5cce)
            {
                case 1:
                    this.tbNeuronsCount = (TextBlock) x11d58b056c032b03;
                    if (0x7fffffff != 0)
                    {
                        return;
                    }
                    break;

                case 2:
                    this.tbLinksCount = (TextBlock) x11d58b056c032b03;
                    return;
            }
            this._x7dc3d9d322900926 = true;
        }

        [CompilerGenerated]
        private static int xff77519d643268a0(ILayerStruct x98da6ccbcd45ba73)
        {
            return x98da6ccbcd45ba73.Size;
        }
    }
}

