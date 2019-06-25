using CBV.Core.Domain.Shared;

namespace CBV.Core.Domain.ValueObjects
{
    public class ItemVendaCashback
    {
        public static decimal Calc(decimal valorTotal, decimal percentual)
        {
            return ((valorTotal * percentual) / 100).Round();
        }
    }
}
