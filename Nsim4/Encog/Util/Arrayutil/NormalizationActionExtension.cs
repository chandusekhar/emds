namespace Encog.Util.Arrayutil
{
    using System;
    using System.Runtime.CompilerServices;

    public static class NormalizationActionExtension
    {
        public static bool IsClassify(this NormalizationAction extensionParam)
        {
            if ((extensionParam != NormalizationAction.OneOf) && ((2 == 0) || (extensionParam != NormalizationAction.SingleField)))
            {
                return (extensionParam == NormalizationAction.Equilateral);
            }
            return true;
        }
    }
}

