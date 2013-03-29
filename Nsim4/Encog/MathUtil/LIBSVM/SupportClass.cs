namespace Encog.MathUtil.LIBSVM
{
    using System;
    using System.Collections;

    public class SupportClass
    {
        public static System.Random Random = new System.Random();

        public class Tokenizer : IEnumerator
        {
            private string x2724c2f362cdd798;
            private long x435f9bb16d7cfd84;
            private readonly char[] x80de18ecf198e7a3;
            private readonly bool xc46d8d32f194400a;

            public Tokenizer(string source)
            {
                this.x2724c2f362cdd798 = " \t\n\r\f";
                this.x80de18ecf198e7a3 = source.ToCharArray();
            }

            public Tokenizer(string source, string delimiters) : this(source)
            {
                this.x2724c2f362cdd798 = delimiters;
            }

            public Tokenizer(string source, string delimiters, bool includeDelims) : this(source, delimiters)
            {
                this.xc46d8d32f194400a = includeDelims;
            }

            public bool HasMoreTokens()
            {
                long num = this.x435f9bb16d7cfd84;
                try
                {
                    this.NextToken();
                }
                catch (ArgumentOutOfRangeException)
                {
                    return false;
                }
                finally
                {
                    this.x435f9bb16d7cfd84 = num;
                }
                return true;
            }

            public bool MoveNext()
            {
                return this.HasMoreTokens();
            }

            public string NextToken()
            {
                return this.NextToken(this.x2724c2f362cdd798);
            }

            public string NextToken(string delimiters)
            {
                this.x2724c2f362cdd798 = delimiters;
                while (true)
                {
                    long num;
                    if (this.x435f9bb16d7cfd84 == this.x80de18ecf198e7a3.Length)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    do
                    {
                        if ((Array.IndexOf<char>(delimiters.ToCharArray(), this.x80de18ecf198e7a3[(int) ((IntPtr) this.x435f9bb16d7cfd84)]) != -1) && this.xc46d8d32f194400a)
                        {
                            this.x435f9bb16d7cfd84 = (num = this.x435f9bb16d7cfd84) + 1L;
                            return (this.x80de18ecf198e7a3[(int) ((IntPtr) num)]);
                        }
                        break;
                    }
                    while ((((uint) num) - ((uint) num)) >= 0);
                }
            }

            public void Reset()
            {
            }

            private string xab05c62a2a183f47(char[] x2724c2f362cdd798)
            {
                long num;
                long num2;
                string str = "";
                goto Label_00D4;
            Label_0048:
                if (num2 == this.x80de18ecf198e7a3.Length)
                {
                    goto Label_00AD;
                }
            Label_0054:
                if (Array.IndexOf<char>(x2724c2f362cdd798, this.x80de18ecf198e7a3[(int) ((IntPtr) this.x435f9bb16d7cfd84)]) != -1)
                {
                    this.x435f9bb16d7cfd84 = num2 = this.x435f9bb16d7cfd84 + 1L;
                    goto Label_0048;
                }
            Label_001E:
                if (Array.IndexOf<char>(x2724c2f362cdd798, this.x80de18ecf198e7a3[(int) ((IntPtr) this.x435f9bb16d7cfd84)]) == -1)
                {
                    long num3;
                    str = str + this.x80de18ecf198e7a3[(int) ((IntPtr) this.x435f9bb16d7cfd84)];
                    this.x435f9bb16d7cfd84 = num3 = this.x435f9bb16d7cfd84 + 1L;
                    if (num3 != this.x80de18ecf198e7a3.Length)
                    {
                        goto Label_001E;
                    }
                    if (4 != 0)
                    {
                        if ((((uint) num2) - ((uint) num3)) <= uint.MaxValue)
                        {
                            return str;
                        }
                        goto Label_00D4;
                    }
                    if (0 != 0)
                    {
                        return str;
                    }
                    goto Label_0048;
                }
                return str;
            Label_00AD:
                this.x435f9bb16d7cfd84 = num;
                throw new ArgumentOutOfRangeException();
            Label_00D4:
                if (0 != 0)
                {
                    goto Label_00AD;
                }
                num = this.x435f9bb16d7cfd84;
                goto Label_0054;
            }

            public int Count
            {
                get
                {
                    int num3;
                    long num = this.x435f9bb16d7cfd84;
                    int num2 = 0;
                    try
                    {
                        while (true)
                        {
                            this.NextToken();
                            num2++;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        this.x435f9bb16d7cfd84 = num;
                        num3 = num2;
                    }
                    return num3;
                }
            }

            public object Current
            {
                get
                {
                    return this.NextToken();
                }
            }
        }
    }
}

