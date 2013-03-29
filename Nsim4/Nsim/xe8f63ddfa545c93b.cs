namespace Nsim
{
    using Encog.ML.Data.Basic;
    using Microsoft.CSharp.RuntimeBinder;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows;

    internal static class xe8f63ddfa545c93b
    {
        [CompilerGenerated]
        private static Func<_Worksheet, string> x1db2b4a534698fc5;
        [CompilerGenerated]
        private static Func<_Worksheet, string> xa2b4e58885d871d0;

        [CompilerGenerated]
        private static string x29ba3a61709e6ab1(_Worksheet x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.Name;
        }

        [CompilerGenerated]
        private static string x5e07203ad7b24b66(_Worksheet x08db3aeabb253cb1)
        {
            return x08db3aeabb253cb1.Name;
        }

        internal static BasicMLDataSet xba08e03b3c6894f3(string xafe2f3653ee64ebc)
        {
            Workbook workbook;
            ImportExcelFileDialog dialog;
            INetStruct service;
            Range usedRange;
            BasicMLDataSet set;
            List<double> list;
            int row;
            int num2;
            BasicMLDataSet set2;
            bool? nullable;
            bool flag;
            Microsoft.Office.Interop.Excel.Application application2 = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
            application2.Visible = false;
            Microsoft.Office.Interop.Excel.Application application = application2;
            if ((((uint) flag) & 0) == 0)
            {
                workbook = application.Workbooks.Open(xafe2f3653ee64ebc, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                if (x1db2b4a534698fc5 == null)
                {
                    x1db2b4a534698fc5 = new Func<_Worksheet, string>(null, (IntPtr) x29ba3a61709e6ab1);
                }
                ImportExcelFileDialog dialog2 = new ImportExcelFileDialog(Enumerable.Select<_Worksheet, string>(workbook.Sheets.OfType<_Worksheet>(), x1db2b4a534698fc5));
                if (((uint) flag) > uint.MaxValue)
                {
                    return set2;
                }
                if ((((uint) row) | 0xfffffffe) != 0)
                {
                    dialog2.Owner = System.Windows.Application.Current.MainWindow;
                    dialog = dialog2;
                }
                nullable = dialog.ShowDialog();
                if (!nullable.GetValueOrDefault())
                {
                }
            }
            flag = !((15 != 0) && nullable.HasValue);
            if (!flag)
            {
                application.Quit();
                return null;
            }
            _Worksheet worksheet = workbook.Sheets[dialog.cbDataSets.SelectedItem] as _Worksheet;
            if ((((uint) row) | 1) != 0)
            {
                service = App.Services.GetService<INetStruct>();
                if ((((uint) flag) + ((uint) flag)) < 0)
                {
                    goto Label_00D3;
                }
                usedRange = worksheet.UsedRange;
                flag = usedRange.Columns.Count < service.InputLayer.Size;
            }
            else
            {
                return set2;
            }
        Label_00CA:
            if (!flag)
            {
                set = new BasicMLDataSet();
                list = new List<double>();
                row = usedRange.Row;
                if ((((uint) num2) | 4) != 0)
                {
                    goto Label_025C;
                }
            }
            goto Label_030B;
        Label_00D3:
            if (!flag)
            {
                application.Quit();
                if ((((uint) flag) & 0) == 0)
                {
                    if ((((uint) flag) & 0) != 0)
                    {
                        return set2;
                    }
                    return set;
                }
                goto Label_030B;
            }
            try
            {
                list.Clear();
                goto Label_017A;
            Label_0106:
                flag = num2 < (usedRange.Column + service.InputLayer.Size);
                do
                {
                    if (flag)
                    {
                        goto Label_0189;
                    }
                    set.Add(new BasicMLDataPair(new BasicMLData(list.ToArray()), new BasicMLData(new double[0]), new BasicMLData(new double[0]), new BasicMLData(new double[0])));
                }
                while ((((uint) flag) | uint.MaxValue) == 0);
                goto Label_0254;
            Label_017A:
                num2 = usedRange.Column;
                goto Label_0106;
            Label_0189:
                if (<ImportInputs>o__SiteContainer14.<>p__Site15 == null)
                {
                    <ImportInputs>o__SiteContainer14.<>p__Site15 = CallSite<Func<CallSite, object, double>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(double), typeof(xe8f63ddfa545c93b)));
                }
                if (<ImportInputs>o__SiteContainer14.<>p__Site16 == null)
                {
                    <ImportInputs>o__SiteContainer14.<>p__Site16 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Value2", typeof(xe8f63ddfa545c93b), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
                }
                list.Add(<ImportInputs>o__SiteContainer14.<>p__Site15.Target.Invoke(<ImportInputs>o__SiteContainer14.<>p__Site15, <ImportInputs>o__SiteContainer14.<>p__Site16.Target.Invoke(<ImportInputs>o__SiteContainer14.<>p__Site16, worksheet.Cells[row, num2])));
                num2++;
                goto Label_0106;
            }
            catch
            {
            }
        Label_0254:
            row++;
        Label_025C:
            flag = row <= (usedRange.Row + usedRange.Rows.Count);
            goto Label_00D3;
        Label_030B:
            if (((uint) flag) >= 0)
            {
            Label_002A:
                if ((((uint) num2) - ((uint) flag)) < 0)
                {
                    if ((((uint) row) - ((uint) num2)) < 0)
                    {
                        goto Label_002A;
                    }
                    if (((uint) flag) > uint.MaxValue)
                    {
                        goto Label_00CA;
                    }
                }
                MessageBox.Show(string.Format("Количество столбцов ({0}) меньше, чем количество входных параметров ({1}).", usedRange.Columns.Count, service.InputLayer.Size));
                application.Quit();
                return null;
            }
            return set2;
        }

        internal static BasicMLDataSet xd1ea1a5a88cfd758(string xafe2f3653ee64ebc)
        {
            // This item is obfuscated and can not be translated.
        }

        internal static KeyValuePair<string, BasicMLDataSet> xebaf754dad416a25(_Worksheet x99ecbc7e3ae0e29b)
        {
            Range usedRange;
            int num;
            int num2;
            int num3;
            int num4;
            string str;
            Dictionary<string, List<int>> dictionary;
            Dictionary<string, List<double>> dictionary2;
            int num5;
            Dictionary<string, List<int>> dictionary3;
            Dictionary<string, List<double>> dictionary4;
            KeyValuePair<string, BasicMLDataSet> pair3;
            bool flag;
            KeyValuePair<string, BasicMLDataSet> pair = new KeyValuePair<string, BasicMLDataSet>(x99ecbc7e3ae0e29b.Name, new BasicMLDataSet());
            goto Label_072B;
        Label_02D0:
            dictionary4.Add("E", new List<double>());
            if (((uint) flag) >= 0)
            {
                dictionary2 = dictionary4;
                num3 = num + 1;
            }
        Label_0054:
            flag = num3 <= usedRange.Rows.Count;
            if ((((uint) num) & 0) == 0)
            {
                if (((uint) num4) >= 0)
                {
                    if ((((uint) num5) - ((uint) num)) >= 0)
                    {
                        if (!flag)
                        {
                            return pair;
                        }
                        try
                        {
                            using (Dictionary<string, List<double>>.Enumerator enumerator2 = dictionary2.GetEnumerator())
                            {
                                goto Label_0202;
                            Label_009C:
                                if (!flag && (((uint) num) <= uint.MaxValue))
                                {
                                    goto Label_0237;
                                }
                                KeyValuePair<string, List<double>> current = enumerator2.Current;
                                current.Value.Clear();
                                using (List<int>.Enumerator enumerator3 = dictionary[current.Key].GetEnumerator())
                                {
                                    goto Label_01A9;
                                Label_00E7:
                                    num5 = enumerator3.Current;
                                    if (<SheetGetData>o__SiteContainer2.<>p__Site5 == null)
                                    {
                                        <SheetGetData>o__SiteContainer2.<>p__Site5 = CallSite<Func<CallSite, object, double>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(double), typeof(xe8f63ddfa545c93b)));
                                    }
                                    if (<SheetGetData>o__SiteContainer2.<>p__Site6 == null)
                                    {
                                        <SheetGetData>o__SiteContainer2.<>p__Site6 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Value2", typeof(xe8f63ddfa545c93b), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
                                    }
                                    current.Value.Add(<SheetGetData>o__SiteContainer2.<>p__Site5.Target.Invoke(<SheetGetData>o__SiteContainer2.<>p__Site5, <SheetGetData>o__SiteContainer2.<>p__Site6.Target.Invoke(<SheetGetData>o__SiteContainer2.<>p__Site6, x99ecbc7e3ae0e29b.Cells[num3, num5])));
                                Label_01A9:
                                    flag = enumerator3.MoveNext();
                                    if (((((uint) num5) + ((uint) flag)) < 0) || flag)
                                    {
                                        goto Label_00E7;
                                    }
                                }
                            Label_0202:
                                flag = enumerator2.MoveNext();
                                if ((((uint) num4) + ((uint) num5)) >= 0)
                                {
                                    goto Label_009C;
                                }
                            }
                        Label_0237:
                            pair.Value.Add(new BasicMLDataPair(new BasicMLData(dictionary2["X"].ToArray()), new BasicMLData(dictionary2["D"].ToArray()), new BasicMLData(dictionary2["Y"].ToArray()), new BasicMLData(dictionary2["E"].ToArray())));
                        }
                        catch
                        {
                        }
                        num3++;
                        goto Label_0054;
                    }
                    goto Label_071B;
                }
            }
            else
            {
                return pair3;
            }
            goto Label_02D0;
        Label_03C7:
            str = <SheetGetData>o__SiteContainer2.<>p__Site4.Target.Invoke(<SheetGetData>o__SiteContainer2.<>p__Site4, x99ecbc7e3ae0e29b.Cells[num, num4]).ToString();
            using (Dictionary<string, List<int>>.KeyCollection.Enumerator enumerator = dictionary.Keys.GetEnumerator())
            {
                string str2;
                char ch;
                goto Label_0410;
            Label_040B:
                if (!flag)
                {
                    goto Label_041F;
                }
            Label_0410:
                if (enumerator.MoveNext())
                {
                    goto Label_0484;
                }
                goto Label_04A7;
            Label_041F:
                dictionary[str2].Add(num4);
                if (((uint) num3) <= uint.MaxValue)
                {
                }
                goto Label_0410;
            Label_0446:
                ch = str.ToUpper()[0];
                flag = !(ch.ToString() == str2);
                if ((((uint) num2) & 0) == 0)
                {
                    goto Label_040B;
                }
                goto Label_041F;
            Label_0484:
                str2 = enumerator.Current;
                if (8 == 0)
                {
                    goto Label_0484;
                }
                goto Label_0446;
            }
        Label_04A7:
            num4++;
        Label_04AF:
            flag = num4 <= usedRange.Columns.Count;
            if (!flag)
            {
                dictionary4 = new Dictionary<string, List<double>>();
                if ((((uint) num) + ((uint) flag)) < 0)
                {
                    goto Label_04DC;
                }
                dictionary4.Add("X", new List<double>());
                if ((((uint) flag) & 0) != 0)
                {
                    goto Label_061C;
                }
                dictionary4.Add("D", new List<double>());
                if ((((uint) num4) - ((uint) num5)) > uint.MaxValue)
                {
                    if ((((uint) num4) - ((uint) num3)) > uint.MaxValue)
                    {
                        goto Label_04CF;
                    }
                }
                else
                {
                    if (((uint) num2) > uint.MaxValue)
                    {
                        goto Label_066F;
                    }
                    dictionary4.Add("Y", new List<double>());
                    goto Label_02D0;
                }
                goto Label_03C7;
            }
        Label_04CF:
            if (<SheetGetData>o__SiteContainer2.<>p__Site4 == null)
            {
                <SheetGetData>o__SiteContainer2.<>p__Site4 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Value2", typeof(xe8f63ddfa545c93b), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
            }
            goto Label_03C7;
        Label_04DC:
            dictionary = dictionary3;
            num4 = num2;
            goto Label_04AF;
        Label_0551:
            flag = num3 <= usedRange.Rows.Count;
        Label_0565:
            if (flag)
            {
                num4 = 1;
                goto Label_05FE;
            }
            dictionary3 = new Dictionary<string, List<int>>();
            dictionary3.Add("X", new List<int>());
            dictionary3.Add("D", new List<int>());
            if ((((uint) num5) | 15) != 0)
            {
                if ((((uint) flag) + ((uint) num3)) >= 0)
                {
                    dictionary3.Add("Y", new List<int>());
                }
                goto Label_0631;
            }
        Label_05AE:
            if (flag)
            {
                goto Label_0667;
            }
            if ((((uint) num2) - ((uint) flag)) > uint.MaxValue)
            {
                return pair3;
            }
            num3++;
            goto Label_0551;
        Label_05F8:
            num4++;
        Label_05FE:
            flag = num4 <= usedRange.Columns.Count;
            goto Label_05AE;
        Label_061C:
            if ((((uint) num4) & 0) == 0)
            {
                goto Label_05F8;
            }
        Label_0631:
            if (0xff != 0)
            {
                dictionary3.Add("E", new List<int>());
                goto Label_04DC;
            }
            return pair3;
        Label_0667:
            if (<SheetGetData>o__SiteContainer2.<>p__Site3 == null)
            {
                goto Label_06D8;
            }
        Label_066F:
            str = <SheetGetData>o__SiteContainer2.<>p__Site3.Target.Invoke(<SheetGetData>o__SiteContainer2.<>p__Site3, x99ecbc7e3ae0e29b.Cells[num3, num4]).ToString();
            flag = !(str.ToUpper() != "X1");
            if (!flag)
            {
                goto Label_05F8;
            }
            if (0 == 0)
            {
                goto Label_077F;
            }
            goto Label_072B;
        Label_06D8:;
            <SheetGetData>o__SiteContainer2.<>p__Site3 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Value2", typeof(xe8f63ddfa545c93b), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
            goto Label_066F;
        Label_071B:
            num3 = 1;
            goto Label_0551;
        Label_072B:
            if ((((uint) num2) + ((uint) num)) < 0)
            {
                goto Label_066F;
            }
            usedRange = x99ecbc7e3ae0e29b.UsedRange;
            num = 0;
            num2 = 0;
            if ((((uint) num5) - ((uint) flag)) >= 0)
            {
                goto Label_071B;
            }
            if (((uint) num) <= uint.MaxValue)
            {
                if ((((uint) num4) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0565;
                }
                if ((((uint) num2) - ((uint) num5)) >= 0)
                {
                    goto Label_0667;
                }
                goto Label_06D8;
            }
        Label_077F:
            if ((((uint) num4) | 0x7fffffff) != 0)
            {
                num = num3;
                num2 = num4;
                goto Label_061C;
            }
            return pair3;
        }
    }
}

