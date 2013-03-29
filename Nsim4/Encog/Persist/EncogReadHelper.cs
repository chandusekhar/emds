namespace Encog.Persist
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class EncogReadHelper
    {
        private readonly IList<string> x0383ec486664fa18 = new List<string>();
        private string x0f7286e9d651365c = "";
        private string x0fda809a7e14c39d = "";
        private EncogFileSection xb32f8dd719a105db;
        private readonly TextReader xe134235b3526fa75;

        public EncogReadHelper(Stream mask0)
        {
            this.xe134235b3526fa75 = new StreamReader(mask0);
        }

        public void Close()
        {
            try
            {
                this.xe134235b3526fa75.Close();
            }
            catch (IOException exception)
            {
                throw new PersistError(exception);
            }
        }

        public EncogFileSection ReadNextSection()
        {
            EncogFileSection section;
            try
            {
                string str;
                string str3;
                int index;
                string str4;
                string str5;
                goto Label_0107;
            Label_0005:
                return this.xb32f8dd719a105db;
            Label_0012:
                this.x0fda809a7e14c39d = "";
                this.x0f7286e9d651365c = "";
                goto Label_00B5;
            Label_002F:
                if (this.x0fda809a7e14c39d.Length == 0)
                {
                    goto Label_00CC;
                }
                this.xb32f8dd719a105db = new EncogFileSection(this.x0fda809a7e14c39d, this.x0f7286e9d651365c);
                foreach (string str6 in this.x0383ec486664fa18)
                {
                    this.xb32f8dd719a105db.Lines.Add(str6);
                }
                goto Label_0012;
            Label_00B5:
                if (0 == 0)
                {
                    goto Label_0005;
                }
                return section;
            Label_00CC:
                section = null;
                goto Label_0370;
            Label_00D1:
                if (this.x0fda809a7e14c39d.Length < 1)
                {
                    throw new PersistError("Unknown command before first section: " + str);
                }
            Label_00F0:
                this.x0383ec486664fa18.Add(str);
                goto Label_0107;
            Label_00FE:
                if (str.Length >= 1)
                {
                    goto Label_00D1;
                }
            Label_0107:
                if ((str = this.xe134235b3526fa75.ReadLine()) != null)
                {
                    goto Label_0328;
                }
                if (8 != 0)
                {
                    goto Label_002F;
                }
                goto Label_0370;
            Label_0125:
                if (str.StartsWith("["))
                {
                    goto Label_034A;
                }
                goto Label_00FE;
            Label_0139:
                throw new PersistError("Can't begin subsection " + str + ", while we are still in the section: " + this.x0fda809a7e14c39d);
            Label_0157:
                if (!str4.Equals(this.x0fda809a7e14c39d))
                {
                    goto Label_0139;
                }
            Label_0166:
                this.x0f7286e9d651365c = str5;
            Label_016E:
                return this.xb32f8dd719a105db;
            Label_017D:
                if (1 == 0)
                {
                    goto Label_0166;
                }
                if (15 != 0)
                {
                    goto Label_0157;
                }
                goto Label_0139;
            Label_018F:
                if (this.x0fda809a7e14c39d.Length < 1)
                {
                    throw new PersistError("Can't begin subsection when a section has not yet been defined: " + str);
                }
                str4 = str3.Substring(0, index);
                str5 = str3.Substring(index + 1);
                goto Label_01D7;
            Label_01B4:
                if (index == -1)
                {
                    goto Label_01FE;
                }
                if (3 == 0)
                {
                    goto Label_0259;
                }
                goto Label_018F;
            Label_01D7:
                if ((((uint) index) + ((uint) index)) >= 0)
                {
                    goto Label_017D;
                }
                if (0 == 0)
                {
                    goto Label_0125;
                }
                goto Label_0215;
            Label_01FE:
                this.x0fda809a7e14c39d = str3;
                this.x0f7286e9d651365c = "";
                goto Label_016E;
            Label_0215:
                if (((uint) index) <= uint.MaxValue)
                {
                    goto Label_00D1;
                }
                goto Label_0370;
            Label_022C:
                if (!str3.EndsWith("]"))
                {
                    goto Label_0278;
                }
                goto Label_0259;
                if ((((uint) index) & 0) != 0)
                {
                    goto Label_022C;
                }
                if (8 == 0)
                {
                    goto Label_0335;
                }
            Label_0259:
                str3 = str3.Substring(0, str.Length - 2);
                index = str3.IndexOf(':');
                goto Label_028B;
            Label_0278:
                throw new PersistError("Invalid section: " + str);
            Label_028B:
                if (-1 != 0)
                {
                    goto Label_01B4;
                }
                goto Label_0370;
            Label_029A:
                if ((((uint) index) | 2) != 0)
                {
                    goto Label_022C;
                }
                if (((uint) index) < 0)
                {
                    goto Label_018F;
                }
                goto Label_0278;
            Label_02CF:
                foreach (string str2 in this.x0383ec486664fa18)
                {
                    this.xb32f8dd719a105db.Lines.Add(str2);
                }
                this.x0383ec486664fa18.Clear();
                str3 = str.Substring(1).Trim();
                goto Label_029A;
            Label_0328:
                str = str.Trim();
                if (0 != 0)
                {
                    goto Label_00F0;
                }
            Label_0335:
                if (str.StartsWith("//"))
                {
                    goto Label_0107;
                }
                goto Label_0125;
            Label_034A:
                this.xb32f8dd719a105db = new EncogFileSection(this.x0fda809a7e14c39d, this.x0f7286e9d651365c);
                goto Label_02CF;
            Label_0370:
                if ((((uint) index) & 0) == 0)
                {
                    return section;
                }
                goto Label_0005;
            }
            catch (IOException exception)
            {
                throw new PersistError(exception);
            }
            return section;
        }
    }
}

