using CBV.Core.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CBV.Core.Domain.Entities
{
    public class Venda
    {
        public int VendaId { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal CashbackTotal { get; set; }
        public DateTime Data { get; set; }

        public static List<Venda> ListEmpty() => new List<Venda>();
        public virtual ICollection<ItemVenda> ItensVenda { get; set; }

        public static Venda Build(List<ItemVenda> itemVendas)
        {
            return new Venda()
            {
                VendaId = 0,
                ValorTotal = itemVendas.Sum(e => e.ValorTotal).Round(),
                CashbackTotal = itemVendas.Sum(e => e.CashbackPercentual).Round(),
                ItensVenda = itemVendas,
                Data = DateTime.Now
            };
        }
    }
}


