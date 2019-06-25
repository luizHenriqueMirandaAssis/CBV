using CBV.Core.Domain.Adapter;
using CBV.Core.Domain.Entities;
using System.Collections.Generic;

namespace CBV.Core.Application.Interfaces.Repositories
{
    public interface IVendaRepository
    {
        Venda GetById(int id);
        List<Venda> GetWithPagination(RequestSearchVenda request);
        Venda Add(Venda venda);
    }
}
