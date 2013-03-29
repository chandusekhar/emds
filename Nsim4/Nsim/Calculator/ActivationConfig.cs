namespace Nsim.Calculator
{
    using Encog.Engine.Network.Activation;
    using Nsim;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Xml.Linq;

    public class ActivationConfig : IConfigurable, IActivationStruct
    {
        private IActivationDecorator _xb6b7237a193ea7b0;
        private EventHandler<ActivationChangedEventArgs> FunctionChanged;
        [CompilerGenerated]
        private static Func<IActivationDecoratorDescriptor, bool> x31af784cbc72c68d;
        [CompilerGenerated]
        private IActivationDecoratorDescriptor xe0bd931f5d48821f;

        public event EventHandler<ActivationChangedEventArgs> FunctionChanged
        {
            add
            {
                EventHandler<ActivationChangedEventArgs> handler2;
                EventHandler<ActivationChangedEventArgs> functionChanged = this.FunctionChanged;
                do
                {
                    handler2 = functionChanged;
                    EventHandler<ActivationChangedEventArgs> handler3 = (EventHandler<ActivationChangedEventArgs>) Delegate.Combine(handler2, value);
                    if (15 == 0)
                    {
                        break;
                    }
                    functionChanged = Interlocked.CompareExchange<EventHandler<ActivationChangedEventArgs>>(ref this.FunctionChanged, handler3, handler2);
                }
                while (functionChanged != handler2);
            }
            remove
            {
                EventHandler<ActivationChangedEventArgs> handler2;
                bool flag;
                EventHandler<ActivationChangedEventArgs> functionChanged = this.FunctionChanged;
                if ((((uint) flag) + ((uint) flag)) < 0)
                {
                    goto Label_003C;
                }
            Label_001F:
                handler2 = functionChanged;
                EventHandler<ActivationChangedEventArgs> handler3 = (EventHandler<ActivationChangedEventArgs>) Delegate.Remove(handler2, value);
                functionChanged = Interlocked.CompareExchange<EventHandler<ActivationChangedEventArgs>>(ref this.FunctionChanged, handler3, handler2);
            Label_003C:
                if (functionChanged != handler2)
                {
                    goto Label_001F;
                }
            }
        }

        public ActivationConfig()
        {
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
            return new Nsim.Calculator.ActivationConfig { Xml = this.Xml };
        }

        public void OnFunctionChanged()
        {
            EventHandler<ActivationChangedEventArgs> functionChanged = this.FunctionChanged;
            if (4 != 0)
            {
                if (0x7fffffff != 0)
                {
                    if (3 == 0)
                    {
                        return;
                    }
                }
                else
                {
                    goto Label_0019;
                }
            }
            bool flag = functionChanged == null;
        Label_0014:
            if (!flag)
            {
                functionChanged(this, new ActivationChangedEventArgs(this));
            }
            else
            {
                return;
            }
        Label_0019:
            if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
            {
                goto Label_0014;
            }
        }

        [CompilerGenerated]
        private static bool xf29670e286f5562f(IActivationDecoratorDescriptor x08db3aeabb253cb1)
        {
            return (x08db3aeabb253cb1.Title == "Тангенс Гиперболический");
        }

        public IActivationDecoratorDescriptor Type
        {
            [CompilerGenerated]
            get
            {
                return this.xe0bd931f5d48821f;
            }
            [CompilerGenerated]
            set
            {
                this.xe0bd931f5d48821f = value;
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
                bool flag = !(value.Name.LocalName != "ActivationFunction");
                if ((((uint) flag) + ((uint) flag)) >= 0)
                {
                    if (((uint) flag) <= uint.MaxValue)
                    {
                        if (!flag)
                        {
                            goto Label_0050;
                        }
                    }
                    else
                    {
                        goto Label_0050;
                    }
                }
                this.Type = Enumerable.FirstOrDefault<IActivationDecoratorDescriptor>(ActivationDecoratorFactory.ActivationDescriptors, new Func<IActivationDecoratorDescriptor, bool>(class2, (IntPtr) this.<set_Xml>b__2));
                this._xb6b7237a193ea7b0 = this.Type.GetDecorator(value);
                return;
            Label_0050:
                throw new ArgumentException();
            }
        }
    }
}

