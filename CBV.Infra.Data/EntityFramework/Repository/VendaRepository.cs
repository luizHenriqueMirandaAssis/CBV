using CBV.Core.Application.Interfaces.Repositories;
using CBV.Core.Domain.Adapter;
using CBV.Core.Domain.Entities;
using CBV.Infra.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CBV.Infra.Data.EntityFramework.Repository
{
    public class VendaRepository : IVendaRepository, IDisposable
    {
        protected readonly CBVContext _context;

        public VendaRepository(CBVContext context)
        {
            _context = context;
        }

        public Venda GetById(int id)
        {
            return _context.Venda.Include(v => v.ItensVenda).FirstOrDefault(v => v.VendaId == id);
        }

        public List<Venda> GetWithPagination(RequestSearchVenda request)
        {
            var where = new Func<Venda, bool>(v => v.Data >= request.DataInicio && v.Data <= request.DataFim);

            var total = _context.Venda.Count(where);

            if (total == 0)
                return Venda.ListEmpty();

            request.WithPagination(total);

            return _context.Venda
                          .Include(v => v.ItensVenda)
                          .Where(where)
                          .OrderByDescending(d => d.Data)
                          .Skip(request.Paginacao.Skip)
                          .Take(request.Paginacao.Take)
                          .ToList();
        }

        public Venda Add(Venda venda)
        {
            _context.Venda.Add(venda);
            _context.SaveChanges();
            return venda;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
