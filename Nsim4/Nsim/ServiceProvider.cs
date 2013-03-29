namespace Nsim
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class ServiceProvider
    {
        private readonly List<xbff48450d40ecc36> _x5fd046377faacc9e = new List<xbff48450d40ecc36>();
        private readonly Dictionary<Type, object> _x851c176e74f1bd5f = new Dictionary<Type, object>();

        public void FairEvent<T>(T parameter) where T: EventBase
        {
            using (List<xbff48450d40ecc36>.Enumerator enumerator = this._x5fd046377faacc9e.GetEnumerator())
            {
                xbff48450d40ecc36 xbffdecc;
                Action<T> action;
                bool flag;
                goto Label_001C;
            Label_0010:
                if (flag)
                {
                    action(parameter);
                }
            Label_001C:
                if (enumerator.MoveNext())
                {
                    goto Label_0053;
                }
                return;
            Label_002F:
                if (!flag)
                {
                    goto Label_001C;
                }
                action = xbffdecc.xa160b1c73a8f9d06 as Action<T>;
                flag = action != null;
                if (-2 == 0)
                {
                    return;
                }
                goto Label_0010;
            Label_0053:
                xbffdecc = enumerator.Current;
                flag = xbffdecc.x8884c63fbd777fd4 == typeof(T);
                if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_002F;
                }
                goto Label_001C;
            }
        }

        public T GetService<T>() where T: class
        {
            try
            {
                return (this._x851c176e74f1bd5f[typeof(T)] as T);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public void RegisterService<T>(T serviceProvider)
        {
            this.RegisterService(serviceProvider, typeof(T));
        }

        public void RegisterService(object serviceProvider, Type type)
        {
            bool flag = !this._x851c176e74f1bd5f.Keys.Contains<Type>(type);
            if (!flag)
            {
                this._x851c176e74f1bd5f[type] = serviceProvider;
            }
            else
            {
                do
                {
                    this._x851c176e74f1bd5f.Add(type, serviceProvider);
                }
                while ((((uint) flag) - ((uint) flag)) > uint.MaxValue);
            }
        }

        public void SubscribeEvent<T>(Action<T> action) where T: EventBase
        {
            this._x5fd046377faacc9e.Add(new xbff48450d40ecc36(typeof(T), action));
        }

        private class xbff48450d40ecc36
        {
            [CompilerGenerated]
            private Type x777dc8c34d5b7661;
            [CompilerGenerated]
            private Delegate xb4b12b442587f260;

            public xbff48450d40ecc36(Type eventType, Delegate action)
            {
                this.x8884c63fbd777fd4 = eventType;
                this.xa160b1c73a8f9d06 = action;
            }

            public Type x8884c63fbd777fd4
            {
                [CompilerGenerated]
                get
                {
                    return this.x777dc8c34d5b7661;
                }
                [CompilerGenerated]
                private set
                {
                    this.x777dc8c34d5b7661 = value;
                }
            }

            public Delegate xa160b1c73a8f9d06
            {
                [CompilerGenerated]
                get
                {
                    return this.xb4b12b442587f260;
                }
                [CompilerGenerated]
                private set
                {
                    this.xb4b12b442587f260 = value;
                }
            }
        }
    }
}

