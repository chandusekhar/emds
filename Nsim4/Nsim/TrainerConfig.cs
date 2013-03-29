namespace Nsim
{
    using Encog.ML.Train;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class TrainerConfig : UserControl, ITrainerStruct, IConfigurable, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        private ITrainerDecorator _xb6b7237a193ea7b0;
        internal ComboBox cbTypeSelect;
        private EventHandler<TrainerChangedEventArgs> FunctionChanged;
        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register("Type", typeof(ITrainerDecoratorDescriptor), typeof(TrainerConfig), new UIPropertyMetadata(null, new PropertyChangedCallback(TrainerConfig.xec742bca02015330)));
        internal ScrollViewer xCont;

        public event EventHandler<TrainerChangedEventArgs> FunctionChanged
        {
            add
            {
                bool flag;
                EventHandler<TrainerChangedEventArgs> functionChanged = this.FunctionChanged;
                do
                {
                    EventHandler<TrainerChangedEventArgs> handler3;
                    EventHandler<TrainerChangedEventArgs> a = functionChanged;
                    do
                    {
                        handler3 = (EventHandler<TrainerChangedEventArgs>) Delegate.Combine(a, value);
                    }
                    while ((((uint) flag) + ((uint) flag)) < 0);
                    functionChanged = Interlocked.CompareExchange<EventHandler<TrainerChangedEventArgs>>(ref this.FunctionChanged, handler3, a);
                    flag = functionChanged != a;
                }
                while (flag);
            }
            remove
            {
                bool flag;
                EventHandler<TrainerChangedEventArgs> functionChanged = this.FunctionChanged;
                do
                {
                    EventHandler<TrainerChangedEventArgs> source = functionChanged;
                    EventHandler<TrainerChangedEventArgs> handler3 = (EventHandler<TrainerChangedEventArgs>) Delegate.Remove(source, value);
                    functionChanged = Interlocked.CompareExchange<EventHandler<TrainerChangedEventArgs>>(ref this.FunctionChanged, handler3, source);
                    flag = functionChanged != source;
                }
                while (((((uint) flag) + ((uint) flag)) > uint.MaxValue) || flag);
            }
        }

        public TrainerConfig()
        {
            this.InitializeComponent();
            this.Type = TrainerDecoratorFactory.TrainerDescriptors.First<ITrainerDecoratorDescriptor>();
            if (-1 != 0)
            {
                this._xb6b7237a193ea7b0 = this.Type.GetDecorator();
            }
            this.x6e9c9821bfcbb69d();
            App.Services.RegisterService<ITrainerStruct>(this);
        }

        public ITrainerStruct GetCopy()
        {
            return new TrainerConfig { Xml = this.Xml };
        }

        public IMLTrain GetTrainer([Optional, DefaultParameterValue(false)] bool forceNew)
        {
            return this._xb6b7237a193ea7b0.GetTrainer(forceNew);
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            Uri uri;
            bool flag = !this._x7dc3d9d322900926;
            goto Label_0061;
        Label_0033:
            uri = new Uri("/Nsim4;component/components/train/trainers/trainerconfig.xaml", UriKind.Relative);
            goto Label_007E;
        Label_0061:
            if (!flag)
            {
                return;
            }
            this._x7dc3d9d322900926 = true;
            if (((uint) flag) <= uint.MaxValue)
            {
                if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_0033;
                }
            }
            else
            {
                goto Label_0061;
            }
        Label_007E:
            if (0xff != 0)
            {
                Application.LoadComponent(this, uri);
                if (0 == 0)
                {
                    return;
                }
                if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_0061;
                }
                goto Label_0033;
            }
        }

        public void OnFunctionChanged()
        {
            EventHandler<TrainerChangedEventArgs> functionChanged = this.FunctionChanged;
            if (functionChanged != null)
            {
                functionChanged(this, new TrainerChangedEventArgs(this));
            }
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
        Label_0042:
            switch (num)
            {
                case 1:
                    this.cbTypeSelect = (ComboBox) x11d58b056c032b03;
                    break;

                case 2:
                    this.xCont = (ScrollViewer) x11d58b056c032b03;
                    break;

                default:
                    if ((((uint) num) + ((uint) xf3efd21c486a5cce)) >= 0)
                    {
                        this._x7dc3d9d322900926 = true;
                        if ((((uint) xf3efd21c486a5cce) + ((uint) num)) >= 0)
                        {
                            break;
                        }
                    }
                    goto Label_0042;
            }
        }

        private void x6e9c9821bfcbb69d()
        {
            this.xCont.Content = this._xb6b7237a193ea7b0.GetConfigControl();
        }

        private static void xec742bca02015330(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            TrainerConfig config = x73f821c71fe1e676 as TrainerConfig;
            bool flag = config != null;
            if ((((uint) flag) | uint.MaxValue) != 0)
            {
                if (!flag)
                {
                    return;
                }
                config._xb6b7237a193ea7b0 = ((ITrainerDecoratorDescriptor) xfbf34718e704c6bc.NewValue).GetDecorator();
            }
            else
            {
                if ((((uint) flag) | 15) != 0)
                {
                }
                return;
            }
            config.OnFunctionChanged();
            config.x6e9c9821bfcbb69d();
        }

        public ITrainerDecoratorDescriptor Type
        {
            get
            {
                return (ITrainerDecoratorDescriptor) base.GetValue(TypeProperty);
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
                <>c__DisplayClass1 class2;
                bool flag;
                if (((uint) flag) <= uint.MaxValue)
                {
                    if (value == null)
                    {
                        return;
                    }
                    goto Label_0072;
                }
            Label_003F:
                this.x6e9c9821bfcbb69d();
                if (15 != 0)
                {
                    return;
                }
            Label_0072:
                if (value.Name.LocalName != "TrainerConfig")
                {
                    throw new ArgumentException();
                }
                this.Type = Enumerable.FirstOrDefault<ITrainerDecoratorDescriptor>(TrainerDecoratorFactory.TrainerDescriptors, new Func<ITrainerDecoratorDescriptor, bool>(class2, (IntPtr) this.<set_Xml>b__0));
                this._xb6b7237a193ea7b0 = this.Type.GetDecorator(value);
                goto Label_003F;
            }
        }
    }
}

