namespace Encog
{
    using System;

    public class ConsoleStatusReportable : IStatusReportable
    {
        public void Report(int total, int current, string message)
        {
            object[] objArray;
            if (total == 0)
            {
                goto Label_0084;
            }
        Label_002F:
            objArray = new object[5];
            do
            {
                objArray[0] = current;
                objArray[1] = "/";
                objArray[2] = total;
            }
            while ((((uint) current) - ((uint) current)) < 0);
            objArray[3] = " : ";
            objArray[4] = message;
            Console.WriteLine(string.Concat(objArray));
            if ((((uint) current) + ((uint) current)) <= uint.MaxValue)
            {
                if (((uint) current) <= uint.MaxValue)
                {
                    return;
                }
            }
            else
            {
                goto Label_002F;
            }
        Label_0084:
            Console.WriteLine(current + " : " + message);
        }
    }
}

