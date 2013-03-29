namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script.Prop;
    using System;

    public class CmdSet : Cmd
    {
        public const string CommandName = "SET";

        public CmdSet(EncogAnalyst analyst) : base(analyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            string str;
            string str2;
            PropertyEntry entry;
            string str3;
            int index = args.IndexOf('=');
            goto Label_0112;
        Label_0029:;
            string[] strArray = str.Split(new char[] { '.' });
        Label_0041:
            str3 = strArray[0];
            string subSection = strArray[1];
            string theName = strArray[2];
            entry.Validate(str3, subSection, theName, str2);
            base.Prop.SetProperty(entry.Key, str2);
            if (0 == 0)
            {
                if (0 == 0)
                {
                    return false;
                }
                goto Label_00EB;
            }
            goto Label_00AC;
        Label_009F:
            if (str2[0] == '"')
            {
                goto Label_0103;
            }
            goto Label_00BE;
        Label_00AC:
            if (((uint) index) > uint.MaxValue)
            {
                goto Label_009F;
            }
        Label_00BE:
            if (!str2.EndsWith("\""))
            {
                goto Label_0029;
            }
            str2 = str2.Substring(0, str2.Length - 1);
            if ((((uint) index) | 0xfffffffe) == 0)
            {
                goto Label_0112;
            }
            if ((((uint) index) - ((uint) index)) <= uint.MaxValue)
            {
                if (2 == 0)
                {
                    goto Label_0041;
                }
                goto Label_0029;
            }
            goto Label_00AC;
        Label_00EB:
            if ((((uint) index) - ((uint) index)) <= uint.MaxValue)
            {
            }
        Label_0103:
            str2 = str2.Substring(1);
            goto Label_00AC;
        Label_0112:
            str = args.Substring(0, index).Trim();
            str2 = args.Substring(index + 1).Trim();
            entry = PropertyConstraints.Instance.FindEntry(str);
            if (entry != null)
            {
                goto Label_009F;
            }
            throw new AnalystError("Unknown property: " + args.ToUpper());
            if (0 == 0)
            {
                goto Label_009F;
            }
            goto Label_00EB;
        }

        public override string Name
        {
            get
            {
                return "SET";
            }
        }
    }
}

