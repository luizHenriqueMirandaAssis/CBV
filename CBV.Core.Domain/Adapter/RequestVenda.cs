using CBV.Core.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace CBV.Core.Domain.Adapter
{
    public class RequestVenda
    {
        public List<Pedido> Pedidos { get; set; }

        public bool IsNotValid()
        {
            return
                this.Pedidos == null ||
                this.Pedidos != null && !this.Pedidos.Any();
        }

        public List<int> GetListId()
        {
            return this.Pedidos.GroupBy(p => p.DiscoId).Select(p => p.Key).ToList();
        }


        public string GetValueInvalidId()
        {
            var valuesInvalid = string.Join(", ", this.Pedidos.Where(x => x.DiscoId <= 0).Select(x=>x.DiscoId).ToList());
            return "DiscoId: {" + valuesInvalid + "}";
        }

        public string GetValueInvalidQuantidade()
        {
            var valuesInvalid = string.Join(", ", this.Pedidos.Where(x => x.Quantidade <= 0).Select(x=>x.Quantidade).ToList());
            return "Quantidade: {" + valuesInvalid + "}";
        }


    }

}
