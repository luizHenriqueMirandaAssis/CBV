using CBV.Core.Domain.Entities;
using System;

namespace CBV.Core.Domain.Adapter
{
    public class ResponseVenda
    {
        public int VendaId { get; set; }
        public DateTime Data { get; set; }

        public static ResponseVenda Build(Venda venda)
        {
            return new ResponseVenda()
            {
                VendaId = venda.VendaId,
                Data = venda.Data
            };
        }
    }
}
