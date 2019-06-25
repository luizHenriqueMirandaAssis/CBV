using System;

namespace CBV.Core.Domain.Shared
{
    public static class DecimalExtensions
    {
        public static decimal Round(this decimal value)
        {
            return decimal.Round(value, 2, MidpointRounding.AwayFromZero);
        }

    }
}
