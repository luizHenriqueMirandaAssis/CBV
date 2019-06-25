using System;

namespace CBV.Core.Domain.ValueObjects
{
    public class DiscoPreco
    {
        public static decimal GetPrice()
        {
            var price = decimal.Parse($"{new Random().Next(1, 500)},{GetCents()}");
            return decimal.Round(price, 2, MidpointRounding.AwayFromZero);
        }

        #region Auxiliary methods

        private static decimal GetCents()
        {
            return new Random().Next(0, 99);
        }

        #endregion
    }
}
