namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Microsoft.CSharp.RuntimeBinder;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class ExcelDataExport
    {
        public static void ExportToExcel(BasicMLDataSet data, DataSetEditMode mode)
        {
            object obj2;
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            bool flag;
            Application application2 = (Application) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
            goto Label_0FE4;
        Label_0028:
            num2++;
            using (IEnumerator<IMLDataPair> enumerator = data.GetEnumerator())
            {
                IMLDataPair pair;
                goto Label_0040;
            Label_0039:
                num2++;
            Label_0040:
                flag = enumerator.MoveNext();
                if (flag)
                {
                    goto Label_0796;
                }
                if (((uint) flag) < 0)
                {
                    goto Label_01D4;
                }
                return;
            Label_006A:
                num++;
                num4++;
            Label_0075:
                flag = num4 <= pair.ErrorArray.Length;
            Label_0087:
                if (flag)
                {
                    goto Label_01DC;
                }
                if (((uint) num4) >= 0)
                {
                    goto Label_07CA;
                }
                goto Label_01FF;
            Label_00A8:;
                <ExportToExcel>o__SiteContainer1.<>p__Site17 = CallSite<Func<CallSite, object, double, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Value2", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
            Label_00E9:
                if (<ExportToExcel>o__SiteContainer1.<>p__Site18 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site18 = CallSite<Func<CallSite, object, int, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetIndex(CSharpBinderFlags.None, typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                }
                if (<ExportToExcel>o__SiteContainer1.<>p__Site19 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site19 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Cells", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
                }
                <ExportToExcel>o__SiteContainer1.<>p__Site17.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site17, <ExportToExcel>o__SiteContainer1.<>p__Site18.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site18, <ExportToExcel>o__SiteContainer1.<>p__Site19.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site19, obj2), num2, num), pair.ErrorArray[num4 - 1]);
                goto Label_006A;
            Label_01C4:
                if (mode != DataSetEditMode.CheckData)
                {
                    goto Label_0039;
                }
            Label_01D4:
                num4 = 1;
                goto Label_0075;
            Label_01DC:
                if (<ExportToExcel>o__SiteContainer1.<>p__Site17 != null)
                {
                    goto Label_00E9;
                }
                if ((((uint) num2) + ((uint) num4)) >= 0)
                {
                    goto Label_00A8;
                }
            Label_01FF:
                if (flag)
                {
                    goto Label_037C;
                }
                goto Label_01C4;
            Label_0208:
                if (!flag)
                {
                    goto Label_03F0;
                }
                goto Label_01C4;
            Label_021D:
                num++;
                num4++;
            Label_0228:
                flag = num4 <= pair.CalcedArray.Length;
                if ((((uint) num) + ((uint) num4)) > uint.MaxValue)
                {
                    goto Label_060D;
                }
                goto Label_01FF;
            Label_025E:
                if (<ExportToExcel>o__SiteContainer1.<>p__Site15 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site15 = CallSite<Func<CallSite, object, int, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetIndex(CSharpBinderFlags.None, typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                }
                if (<ExportToExcel>o__SiteContainer1.<>p__Site16 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site16 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Cells", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
                }
                <ExportToExcel>o__SiteContainer1.<>p__Site14.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site14, <ExportToExcel>o__SiteContainer1.<>p__Site15.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site15, <ExportToExcel>o__SiteContainer1.<>p__Site16.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site16, obj2), num2, num), pair.CalcedArray[num4 - 1]);
                if (0 == 0)
                {
                    goto Label_021D;
                }
                goto Label_0410;
            Label_0342:
                if ((((uint) flag) | 2) == 0)
                {
                    goto Label_0506;
                }
                if (((uint) num5) < 0)
                {
                    goto Label_0729;
                }
                goto Label_0449;
            Label_037C:
                if (<ExportToExcel>o__SiteContainer1.<>p__Site14 != null)
                {
                    goto Label_025E;
                }
                <ExportToExcel>o__SiteContainer1.<>p__Site14 = CallSite<Func<CallSite, object, double, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Value2", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                if ((((uint) num3) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_043F;
                }
            Label_03DE:
                if (flag)
                {
                    goto Label_04BD;
                }
            Label_03E5:
                flag = mode == DataSetEditMode.TrainData;
                goto Label_0208;
            Label_03F0:
                num4 = 1;
                if ((((uint) num) | 8) != 0)
                {
                    goto Label_0228;
                }
                goto Label_043F;
            Label_0410:
                if ((((uint) num5) - ((uint) num3)) > uint.MaxValue)
                {
                    goto Label_0087;
                }
                if ((((uint) num5) & 0) == 0)
                {
                    goto Label_03DE;
                }
            Label_043F:
                if (2 != 0)
                {
                    goto Label_0342;
                }
            Label_0449:
                if ((((uint) flag) - ((uint) num3)) <= uint.MaxValue)
                {
                    goto Label_025E;
                }
                goto Label_021D;
            Label_0466:
                num4++;
            Label_046D:
                flag = num4 <= data.IdealSize;
                if ((((uint) num2) | 4) == 0)
                {
                    goto Label_01C4;
                }
                if ((((uint) flag) & 0) == 0)
                {
                    goto Label_0410;
                }
                goto Label_021D;
            Label_04B0:
                num++;
                goto Label_0466;
            Label_04BD:
                if (<ExportToExcel>o__SiteContainer1.<>p__Site11 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site11 = CallSite<Func<CallSite, object, double, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Value2", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                }
            Label_0506:
                if (<ExportToExcel>o__SiteContainer1.<>p__Site12 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site12 = CallSite<Func<CallSite, object, int, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetIndex(CSharpBinderFlags.None, typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                }
                if (<ExportToExcel>o__SiteContainer1.<>p__Site13 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site13 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Cells", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
                }
                <ExportToExcel>o__SiteContainer1.<>p__Site11.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site11, <ExportToExcel>o__SiteContainer1.<>p__Site12.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site12, <ExportToExcel>o__SiteContainer1.<>p__Site13.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site13, obj2), num2, num), pair.IdealArray[num4 - 1]);
                goto Label_04B0;
            Label_05EB:
                if (((uint) num5) < 0)
                {
                    goto Label_0208;
                }
                if (mode == DataSetEditMode.CalcData)
                {
                    goto Label_03E5;
                }
            Label_060D:
                num4 = 1;
                goto Label_046D;
            Label_061A:
                if (!flag)
                {
                    if ((((uint) num) & 0) != 0)
                    {
                        goto Label_0228;
                    }
                    goto Label_05EB;
                }
                if (<ExportToExcel>o__SiteContainer1.<>p__Sitee == null)
                {
                    goto Label_0750;
                }
            Label_0645:
                if (<ExportToExcel>o__SiteContainer1.<>p__Sitef == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Sitef = CallSite<Func<CallSite, object, int, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetIndex(CSharpBinderFlags.None, typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                }
                if (<ExportToExcel>o__SiteContainer1.<>p__Site10 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site10 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Cells", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
                }
                <ExportToExcel>o__SiteContainer1.<>p__Sitee.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Sitee, <ExportToExcel>o__SiteContainer1.<>p__Sitef.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Sitef, <ExportToExcel>o__SiteContainer1.<>p__Site10.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site10, obj2), num2, num), pair.InputArray[num3 - 1]);
                num++;
                num3++;
            Label_0729:
                flag = num3 <= data.InputSize;
                if ((((uint) flag) - ((uint) num3)) >= 0)
                {
                    goto Label_07AA;
                }
            Label_0750:;
                <ExportToExcel>o__SiteContainer1.<>p__Sitee = CallSite<Func<CallSite, object, double, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Value2", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                goto Label_0645;
            Label_0796:
                pair = enumerator.Current;
                num = 1;
                num3 = 1;
                goto Label_0729;
            Label_07AA:
                if ((((uint) num) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_061A;
                }
                goto Label_05EB;
            Label_07CA:
                if (0xff != 0)
                {
                    goto Label_0039;
                }
            }
            return;
        Label_07F9:
            flag = num6 <= data.ErrorSize;
            if ((((uint) num3) - ((uint) flag)) < 0)
            {
                goto Label_0FB5;
            }
            if (!flag)
            {
                goto Label_0028;
            }
        Label_087B:
            if (<ExportToExcel>o__SiteContainer1.<>p__Siteb == null)
            {
                <ExportToExcel>o__SiteContainer1.<>p__Siteb = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Value2", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
            }
            if (<ExportToExcel>o__SiteContainer1.<>p__Sitec == null)
            {
                <ExportToExcel>o__SiteContainer1.<>p__Sitec = CallSite<Func<CallSite, object, int, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetIndex(CSharpBinderFlags.None, typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
            }
            if (<ExportToExcel>o__SiteContainer1.<>p__Sited == null)
            {
                <ExportToExcel>o__SiteContainer1.<>p__Sited = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Cells", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
            }
            <ExportToExcel>o__SiteContainer1.<>p__Siteb.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Siteb, <ExportToExcel>o__SiteContainer1.<>p__Sitec.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Sitec, <ExportToExcel>o__SiteContainer1.<>p__Sited.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Sited, obj2), num2, num), "E" + num6);
            num++;
            if ((((uint) num3) - ((uint) flag)) > uint.MaxValue)
            {
                goto Label_0E6A;
            }
            num6++;
            goto Label_07F9;
        Label_09F2:
            flag = mode != DataSetEditMode.CheckData;
            if (((uint) num6) > uint.MaxValue)
            {
                if ((((uint) num2) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0BAC;
                }
                if (((uint) num6) > uint.MaxValue)
                {
                    goto Label_087B;
                }
            }
            if (!flag)
            {
                num6 = 1;
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_07F9;
                }
                if ((((uint) num) + ((uint) num4)) <= uint.MaxValue)
                {
                    if ((((uint) flag) + ((uint) num6)) >= 0)
                    {
                        if ((((uint) num3) - ((uint) num2)) >= 0)
                        {
                            if (3 == 0)
                            {
                                return;
                            }
                            goto Label_087B;
                        }
                        goto Label_0C38;
                    }
                    goto Label_0BF7;
                }
                goto Label_09F2;
            }
            goto Label_0028;
        Label_0A17:
            flag = num5 <= data.CalcedSize;
        Label_0A26:
            if (flag)
            {
                if (<ExportToExcel>o__SiteContainer1.<>p__Site8 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site8 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Value2", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                }
                if (<ExportToExcel>o__SiteContainer1.<>p__Site9 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site9 = CallSite<Func<CallSite, object, int, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetIndex(CSharpBinderFlags.None, typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                }
                if (<ExportToExcel>o__SiteContainer1.<>p__Sitea == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Sitea = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Cells", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
                }
                <ExportToExcel>o__SiteContainer1.<>p__Site8.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site8, <ExportToExcel>o__SiteContainer1.<>p__Site9.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site9, <ExportToExcel>o__SiteContainer1.<>p__Sitea.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Sitea, obj2), num2, num), "Y" + num5);
                num++;
                num5++;
                goto Label_0A17;
            }
            if ((((uint) num2) + ((uint) num)) >= 0)
            {
                goto Label_09F2;
            }
        Label_0A2C:
            if (!flag)
            {
                goto Label_0BCD;
            }
            goto Label_09F2;
        Label_0BAC:
            flag = mode == DataSetEditMode.TrainData;
            if ((((uint) num5) - ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_0A2C;
            }
        Label_0BCD:
            num5 = 1;
            goto Label_0A17;
        Label_0BF7:
            if ((((uint) num2) - ((uint) num3)) < 0)
            {
                goto Label_0F73;
            }
            if ((((uint) num) & 0) == 0)
            {
                goto Label_0BAC;
            }
        Label_0C17:
            if (!flag)
            {
                num4 = 1;
                if (((uint) num6) > uint.MaxValue)
                {
                    goto Label_0D90;
                }
                goto Label_0C43;
            }
            goto Label_0BAC;
        Label_0C38:
            num++;
            num4++;
        Label_0C43:
            flag = num4 <= data.IdealSize;
            if (flag)
            {
                if (<ExportToExcel>o__SiteContainer1.<>p__Site5 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site5 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Value2", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                }
                if (<ExportToExcel>o__SiteContainer1.<>p__Site6 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site6 = CallSite<Func<CallSite, object, int, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetIndex(CSharpBinderFlags.None, typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                }
                if (<ExportToExcel>o__SiteContainer1.<>p__Site7 == null)
                {
                    <ExportToExcel>o__SiteContainer1.<>p__Site7 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Cells", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
                }
                <ExportToExcel>o__SiteContainer1.<>p__Site5.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site5, <ExportToExcel>o__SiteContainer1.<>p__Site6.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site6, <ExportToExcel>o__SiteContainer1.<>p__Site7.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site7, obj2), num2, num), "D" + num4);
                goto Label_0C38;
            }
            goto Label_0BF7;
        Label_0D90:
            if (flag)
            {
                goto Label_0F4E;
            }
            flag = mode == DataSetEditMode.CalcData;
            goto Label_0C17;
        Label_0DC8:
            flag = num3 <= data.InputSize;
            if ((((uint) num3) + ((uint) num5)) >= 0)
            {
                goto Label_0D90;
            }
            goto Label_0FE4;
        Label_0E6A:
            if (<ExportToExcel>o__SiteContainer1.<>p__Site3 == null)
            {
                <ExportToExcel>o__SiteContainer1.<>p__Site3 = CallSite<Func<CallSite, object, int, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetIndex(CSharpBinderFlags.None, typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
            }
            if (<ExportToExcel>o__SiteContainer1.<>p__Site4 == null)
            {
                <ExportToExcel>o__SiteContainer1.<>p__Site4 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Cells", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
            }
            <ExportToExcel>o__SiteContainer1.<>p__Site2.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site2, <ExportToExcel>o__SiteContainer1.<>p__Site3.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site3, <ExportToExcel>o__SiteContainer1.<>p__Site4.Target.Invoke(<ExportToExcel>o__SiteContainer1.<>p__Site4, obj2), num2, num), "X" + num3);
            num++;
            goto Label_0FF7;
        Label_0F4E:
            if (<ExportToExcel>o__SiteContainer1.<>p__Site2 != null)
            {
                goto Label_0E6A;
            }
            if (((uint) num4) <= uint.MaxValue)
            {
                <ExportToExcel>o__SiteContainer1.<>p__Site2 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Value2", typeof(ExcelDataExport), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                if ((((uint) num) + ((uint) num2)) < 0)
                {
                    goto Label_0C43;
                }
                if ((((uint) num5) & 0) != 0)
                {
                    goto Label_0A26;
                }
                goto Label_0E6A;
            }
            goto Label_0FF7;
        Label_0F73:
            num2 = 1;
            if ((((uint) num4) - ((uint) num5)) > uint.MaxValue)
            {
                goto Label_0028;
            }
            if (4 == 0)
            {
                goto Label_0E6A;
            }
            num3 = 1;
            goto Label_0DC8;
        Label_0FB5:
            num = 1;
            goto Label_0F73;
        Label_0FE4:
            application2.Visible = true;
            Application application = application2;
            Workbook workbook = application.Workbooks.Add(Missing.Value);
            if ((((uint) num4) + ((uint) num5)) <= uint.MaxValue)
            {
                obj2 = workbook.Sheets[1];
                goto Label_0FB5;
            }
            goto Label_0F4E;
        Label_0FF7:
            if ((((uint) num5) & 0) == 0)
            {
                num3++;
                goto Label_0DC8;
            }
            goto Label_0D90;
        }
    }
}

