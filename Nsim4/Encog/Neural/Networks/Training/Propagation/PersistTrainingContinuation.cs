namespace Encog.Neural.Networks.Training.Propagation
{
    using Encog.Persist;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PersistTrainingContinuation : IEncogPersistor
    {
        public object Read(Stream mask0)
        {
            EncogReadHelper helper;
            EncogFileSection section;
            IDictionary<string, string> dictionary;
            TrainingContinuation continuation = new TrainingContinuation();
            if (3 != 0)
            {
                helper = new EncogReadHelper(mask0);
                goto Label_001E;
            }
        Label_0010:
            if ((-2 == 0) || (4 == 0))
            {
                goto Label_005C;
            }
        Label_001E:
            if ((section = helper.ReadNextSection()) == null)
            {
                return continuation;
            }
            if (!section.SectionName.Equals("CONT"))
            {
                if (1 != 0)
                {
                    if (0xff == 0)
                    {
                        return continuation;
                    }
                    goto Label_0010;
                }
                if (0 == 0)
                {
                    goto Label_0077;
                }
                goto Label_001E;
            }
        Label_005C:
            if (section.SubSectionName.Equals("PARAMS"))
            {
                dictionary = section.ParseParams();
            }
            else if ((0 == 0) && ((0 != 0) || (3 != 0)))
            {
                goto Label_001E;
            }
        Label_0077:
            using (IEnumerator<string> enumerator = dictionary.Keys.GetEnumerator())
            {
                string current;
                double[] numArray;
                goto Label_0090;
            Label_0086:
                continuation.Put(current, numArray);
            Label_0090:
                if (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (current.Equals("type", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continuation.TrainingType = dictionary[current];
                        goto Label_0090;
                    }
                    numArray = EncogFileSection.ParseDoubleArray(dictionary, current);
                    if (0xff != 0)
                    {
                    }
                    goto Label_0086;
                }
            }
            goto Label_001E;
        }

        public void Save(Stream os, object obj)
        {
            TrainingContinuation continuation;
            EncogWriteHelper helper = new EncogWriteHelper(os);
            if (0 == 0)
            {
                goto Label_0070;
            }
        Label_000A:
            helper.WriteProperty("type", continuation.TrainingType);
            foreach (string str in continuation.Contents.Keys)
            {
                double[] d = (double[]) continuation.Get(str);
                helper.WriteProperty(str, d);
            }
            helper.Flush();
            if (4 != 0)
            {
                return;
            }
        Label_0070:
            continuation = (TrainingContinuation) obj;
            if (0xff != 0)
            {
                helper.AddSection("CONT");
            }
            helper.AddSubSection("PARAMS");
            goto Label_000A;
        }

        public virtual int FileVersion
        {
            get
            {
                return 1;
            }
        }

        public Type NativeType
        {
            get
            {
                return typeof(TrainingContinuation);
            }
        }

        public virtual string PersistClassString
        {
            get
            {
                return "TrainingContinuation";
            }
        }
    }
}

