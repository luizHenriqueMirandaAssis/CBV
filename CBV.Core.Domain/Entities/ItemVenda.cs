using CBV.Core.Domain.Shared;
using CBV.Core.Domain.ValueObjects;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CBV.Core.Domain.Entities
{
    [DataContract]
    public class ItemVenda
    {
        [DataMember]
        public int ItemVendaId { get; set; }
        [DataMember]
        public int VendaId { get; set; }
        [DataMember]
        public int DiscoId { get; set; }
        [DataMember]
        public int Quantidade { get; set; }
        [DataMember]
        public decimal PrecoUnitario { get; set; }
        [DataMember]
        public decimal ValorTotal { get; set; }
        [DataMember]
        public decimal CashbackPercentual { get; set; }
        [DataMember]
        public decimal CashbackValor { get; set; }
      
        public virtual Venda Venda { get; set; }

        public static List<ItemVenda> ListEmpty() => new List<ItemVenda>();

        public static ItemVenda Build(Disco disco, Pedido pedido, Cashback cashback)
        {
            var total = (pedido.Quantidade * disco.Preco).Round();

            return new ItemVenda()
            {
                Quantidade = pedido.Quantidade,
                DiscoId = disco.DiscoId,
                ValorTotal = total,
                PrecoUnitario = disco.Preco,
                CashbackPercentual = cashback.Percentual,
                CashbackValor = ItemVendaCashback.Calc(total, cashback.Percentual)
            };
        }

    }
}


