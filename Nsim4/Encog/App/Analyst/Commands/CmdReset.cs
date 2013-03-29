namespace Encog.App.Analyst.Commands
{
    using Encog.App.Analyst;
    using System;
    using System.Collections.Generic;

    public class CmdReset : Cmd
    {
        public const string CommandName = "RESET";

        public CmdReset(EncogAnalyst analyst) : base(analyst)
        {
        }

        public sealed override bool ExecuteCommand(string args)
        {
            IDictionary<string, string> revertData = base.Analyst.RevertData;
            base.Script.Properties.PerformRevert(revertData);
            return false;
        }

        public override string Name
        {
            get
            {
                return "RESET";
            }
        }
    }
}

