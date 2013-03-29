namespace Nsim
{
    using Encog.Engine.Network.Activation;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class ActivationConfig : UserControl, IConfigurable, System.Windows.Markup.IComponentConnector, IActivationStruct
    {
        private bool _x7dc3d9d322900926;
        private IActivationDecorator _xb6b7237a193ea7b0;
        internal ComboBox cbTypeSelect;
        private EventHandler<ActivationChangedEventArgs> FunctionChanged;
        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register("Type", typeof(IActivationDecoratorDescriptor), typeof(ActivationConfig), new UIPropertyMetadata(null, new PropertyChangedCallback(ActivationConfig.xec742bca02015330)));
        [CompilerGenerated]
        private static Func<IActivationDecoratorDescriptor, bool> x31af784cbc72c68d;

        public event EventHandler<ActivationChangedEventArgs> FunctionChanged
        {
            add
            {
                EventHandler<ActivationChangedEventArgs> handler2;
                EventHandler<ActivationChangedEventArgs> handler3;
                bool flag;
                EventHandler<ActivationChangedEventArgs> functionChanged = this.FunctionChanged;
                if (((uint) flag) > uint.MaxValue)
                {
                    goto Label_001B;
                }
            Label_0019:
                handler2 = functionChanged;
            Label_001B:
                handler3 = (EventHandler<ActivationChangedEventArgs>) Delegate.Combine(handler2, value);
                functionChanged = Interlocked.CompareExchange<EventHandler<ActivationChangedEventArgs>>(ref this.FunctionChanged, handler3, handler2);
                if (functionChanged == handler2)
                {
                    return;
                }
                goto Label_0019;
            }
            remove
            {
                bool flag;
                EventHandler<ActivationChangedEventArgs> functionChanged = this.FunctionChanged;
                do
                {
                    EventHandler<ActivationChangedEventArgs> source = functionChanged;
                    do
                    {
                        EventHandler<ActivationChangedEventArgs> handler3 = (EventHandler<ActivationChangedEventArgs>) Delegate.Remove(source, value);
                        functionChanged = Interlocked.CompareExchange<EventHandler<ActivationChangedEventArgs>>(ref this.FunctionChanged, handler3, source);
                        flag = functionChanged != source;
                    }
                    while (((uint) flag) > uint.MaxValue);
                }
                while (flag);
            }
        }

        public ActivationConfig()
        {
            this.InitializeComponent();
            if (x31af784cbc72c68d == null)
            {
                x31af784cbc72c68d = new Func<IActivationDecoratorDescriptor, bool>(null, (IntPtr) xf29670e286f5562f);
            }
            this.Type = Enumerable.First<IActivationDecoratorDescriptor>(ActivationDecoratorFactory.ActivationDescriptors, x31af784cbc72c68d);
            this._xb6b7237a193ea7b0 = this.Type.GetDecorator();
        }

        public IActivationFunction GetActivation()
        {
            return this._xb6b7237a193ea7b0.GetActivation();
        }

        public IActivationStruct GetCopy()
        {
            return new ActivationConfig { Xml = this.Xml };
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            while (flag)
            {
                if (15 != 0)
                {
                }
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/structure/activations/activationconfig.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
                if (0 == 0)
                {
                    return;
                }
            }
        }

        public void OnFunctionChanged()
        {
            EventHandler<ActivationChangedEventArgs> functionChanged = this.FunctionChanged;
            if (functionChanged != null)
            {
                functionChanged(this, new ActivationChangedEventArgs(this));
            }
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            if (xf3efd21c486a5cce == 1)
            {
                this.cbTypeSelect = (ComboBox) x11d58b056c032b03;
            }
            else
            {
                this._x7dc3d9d322900926 = true;
            }
        }

        private static void xec742bca02015330(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            ActivationConfig config = x73f821c71fe1e676 as ActivationConfig;
            bool flag = config != null;
            while (flag)
            {
                config._xb6b7237a193ea7b0 = ((IActivationDecoratorDescriptor) xfbf34718e704c6bc.NewValue).GetDecorator();
                config.OnFunctionChanged();
                if (-1 != 0)
                {
                    return;
                }
            }
        }

        [CompilerGenerated]
        private static bool xf29670e286f5562f(IActivationDecoratorDescriptor x08db3aeabb253cb1)
        {
            return (x08db3aeabb253cb1.Title == "Тангенс Гиперболический");
        }

        public IActivationDecoratorDescriptor Type
        {
            get
            {
                return (IActivationDecoratorDescriptor) base.GetValue(TypeProperty);
            }
            set
            {
                base.SetValue(TypeProperty, value);
            }
        }

        public XElement Xml
        {
            get
            {
                return this._xb6b7237a193ea7b0.Xml;
            }
            set
            {
                <>c__DisplayClass3 class2;
                bool flag;
                if (0 == 0)
                {
                    if (0 != 0)
                    {
                        goto Label_000C;
                    }
                    flag = !(value.Name.LocalName != "ActivationFunction");
                }
                if (!flag)
                {
                    throw new ArgumentException();
                }
            Label_000C:
                this.Type = Enumerable.FirstOrDefault<IActivationDecoratorDescriptor>(ActivationDecoratorFactory.ActivationDescriptors, new Func<IActivationDecoratorDescriptor, bool>(class2, (IntPtr) this.<set_Xml>b__2));
                this._xb6b7237a193ea7b0 = this.Type.GetDecorator(value);
            }
        }
    }
}

