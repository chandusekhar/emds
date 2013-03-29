namespace Nsim
{
    using Encog.MathUtil.Randomize;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class RandomConfig : UserControl, IConfigurable, IRandomStruct, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        private IRandomDecorator _xb6b7237a193ea7b0;
        internal ComboBox cbTypeSelect;
        private EventHandler<RandomChangedEventArgs> FunctionChanged;
        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register("Type", typeof(IRandomDecoratorDescriptor), typeof(RandomConfig), new UIPropertyMetadata(null, new PropertyChangedCallback(RandomConfig.xec742bca02015330)));
        internal ScrollViewer xCont;

        public event EventHandler<RandomChangedEventArgs> FunctionChanged
        {
            add
            {
                EventHandler<RandomChangedEventArgs> handler2;
                EventHandler<RandomChangedEventArgs> functionChanged = this.FunctionChanged;
                do
                {
                    handler2 = functionChanged;
                    EventHandler<RandomChangedEventArgs> handler3 = (EventHandler<RandomChangedEventArgs>) Delegate.Combine(handler2, value);
                    functionChanged = Interlocked.CompareExchange<EventHandler<RandomChangedEventArgs>>(ref this.FunctionChanged, handler3, handler2);
                }
                while ((functionChanged != handler2) || (0 != 0));
            }
            remove
            {
                EventHandler<RandomChangedEventArgs> handler2;
                EventHandler<RandomChangedEventArgs> functionChanged = this.FunctionChanged;
                do
                {
                    handler2 = functionChanged;
                    EventHandler<RandomChangedEventArgs> handler3 = (EventHandler<RandomChangedEventArgs>) Delegate.Remove(handler2, value);
                    if (3 != 0)
                    {
                    }
                    functionChanged = Interlocked.CompareExchange<EventHandler<RandomChangedEventArgs>>(ref this.FunctionChanged, handler3, handler2);
                }
                while (functionChanged != handler2);
            }
        }

        public RandomConfig()
        {
            this.InitializeComponent();
            do
            {
                this.Type = RandomDecoratorFactory.RandomDescriptors.First<IRandomDecoratorDescriptor>();
                this._xb6b7237a193ea7b0 = this.Type.GetDecorator();
                this.x6e9c9821bfcbb69d();
            }
            while (0 != 0);
            App.Services.RegisterService<IRandomStruct>(this);
        }

        public IRandomStruct GetCopy()
        {
            return new RandomConfig { Xml = this.Xml };
        }

        public IRandomizer GetRandom()
        {
            return this._xb6b7237a193ea7b0.GetRandom();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                if (flag)
                {
                    this._x7dc3d9d322900926 = true;
                    Uri resourceLocator = new Uri("/Nsim4;component/components/train/random/randomconfig.xaml", UriKind.Relative);
                    Application.LoadComponent(this, resourceLocator);
                    return;
                }
                if ((((uint) flag) & 0) != 0)
                {
                    return;
                }
            }
            if (((uint) flag) <= uint.MaxValue)
            {
            }
        }

        public void OnFunctionChanged()
        {
            EventHandler<RandomChangedEventArgs> functionChanged = this.FunctionChanged;
            bool flag = functionChanged == null;
            if ((-1 == 0) || !flag)
            {
                functionChanged(this, new RandomChangedEventArgs(this));
            }
            else if (-2147483648 != 0)
            {
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            switch (xf3efd21c486a5cce)
            {
                case 1:
                    this.cbTypeSelect = (ComboBox) x11d58b056c032b03;
                    break;

                case 2:
                    this.xCont = (ScrollViewer) x11d58b056c032b03;
                    if ((((uint) xf3efd21c486a5cce) + ((uint) xf3efd21c486a5cce)) >= 0)
                    {
                    }
                    break;

                default:
                    this._x7dc3d9d322900926 = true;
                    break;
            }
        }

        private void x6e9c9821bfcbb69d()
        {
            this.xCont.Content = this._xb6b7237a193ea7b0.GetConfigControl();
        }

        private static void xec742bca02015330(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            bool flag;
            RandomConfig config = x73f821c71fe1e676 as RandomConfig;
        Label_0036:
            flag = config != null;
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
            }
            if (flag)
            {
                config._xb6b7237a193ea7b0 = ((IRandomDecoratorDescriptor) xfbf34718e704c6bc.NewValue).GetDecorator();
                config.OnFunctionChanged();
                config.x6e9c9821bfcbb69d();
                if (3 == 0)
                {
                    goto Label_0036;
                }
            }
        }

        public IRandomDecoratorDescriptor Type
        {
            get
            {
                return (IRandomDecoratorDescriptor) base.GetValue(TypeProperty);
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
                bool flag;
                if ((((uint) flag) | 2) != 0)
                {
                    if (0 == 0)
                    {
                        <>c__DisplayClass1 class2;
                        if (((uint) flag) >= 0)
                        {
                            flag = value != null;
                            if (1 == 0)
                            {
                                if (((uint) flag) < 0)
                                {
                                }
                                return;
                            }
                        }
                        if (!flag)
                        {
                            return;
                        }
                        if (value.Name.LocalName != "RandomConfig")
                        {
                            throw new ArgumentException();
                        }
                        this.Type = Enumerable.FirstOrDefault<IRandomDecoratorDescriptor>(RandomDecoratorFactory.RandomDescriptors, new Func<IRandomDecoratorDescriptor, bool>(class2, (IntPtr) this.<set_Xml>b__0));
                        this._xb6b7237a193ea7b0 = this.Type.GetDecorator(value);
                    }
                }
                else
                {
                    if ((((uint) flag) + ((uint) flag)) < 0)
                    {
                    }
                    return;
                }
                this.x6e9c9821bfcbb69d();
            }
        }
    }
}

