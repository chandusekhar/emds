namespace Nsim
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;

    public class ErrorDescriptor
    {
        public static IEnumerable<ErrorDescriptor> All;
        public static ErrorDescriptor TestError;
        public static ErrorDescriptor TrainError;
        [CompilerGenerated]
        private System.Windows.Media.Color x35b894e5709bf798;
        [CompilerGenerated]
        private string x84ae50e55afbb83e;
        [CompilerGenerated]
        private string xc4a21d7f8a6c12f2;

        static ErrorDescriptor()
        {
            ErrorDescriptor descriptor2;
            ErrorDescriptor descriptor = new ErrorDescriptor();
            if (0 == 0)
            {
                goto Label_006D;
            }
        Label_0033:
            descriptor2 = new ErrorDescriptor();
            descriptor2.Id = "TestError";
            descriptor2.Title = "Ошибка тестирования";
            descriptor2.Color = Colors.Blue;
            TestError = descriptor2;
            if (0 != 0)
            {
                goto Label_0097;
            }
            List<ErrorDescriptor> list = new List<ErrorDescriptor> {
                TrainError,
                TestError
            };
            All = list;
            if (0 == 0)
            {
                return;
            }
        Label_006D:
            descriptor.Id = "TrainError";
            do
            {
                descriptor.Title = "Ошибка обучения";
                descriptor.Color = Colors.Red;
            }
            while (2 == 0);
        Label_0097:
            TrainError = descriptor;
            goto Label_0033;
        }

        public System.Windows.Media.Color Color
        {
            [CompilerGenerated]
            get
            {
                return this.x35b894e5709bf798;
            }
            [CompilerGenerated]
            private set
            {
                this.x35b894e5709bf798 = value;
            }
        }

        public string Id
        {
            [CompilerGenerated]
            get
            {
                return this.xc4a21d7f8a6c12f2;
            }
            [CompilerGenerated]
            private set
            {
                this.xc4a21d7f8a6c12f2 = value;
            }
        }

        public string Title
        {
            [CompilerGenerated]
            get
            {
                return this.x84ae50e55afbb83e;
            }
            [CompilerGenerated]
            private set
            {
                this.x84ae50e55afbb83e = value;
            }
        }
    }
}

