using CBV.Core.Application.Interfaces.Repositories;
using CBV.Core.Domain.Adapter;
using CBV.Core.Domain.Entities;
using CBV.Core.Domain.Enum;
using CBV.Infra.Data.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CBV.Infra.Data.EntityFramework.Repository
{
    public class DiscoRepository : IDiscoRepository, IDisposable
    {
        protected readonly CBVContext _context;

        public DiscoRepository(CBVContext context)
        {
            _context = context;
        }

        public void AddList(List<Disco> list)
        {
            _context.Disco.AddRange(list);
            _context.SaveChanges();
        }

        public Disco GetById(int id)
        {
            return _context.Disco.FirstOrDefault(d => d.DiscoId == id);
        }

        public List<Disco> GetListById(List<int> ids)
        {
            return _context.Disco.Where(d=> ids.Contains(d.DiscoId)).ToList();
        }

        public List<Disco> GetWithPagination(RequestSearchCatalog request)
        {
            var where = request.FilterGenero <= 0
                ? new Func<Disco, bool>(d => d.GeneroId != 0)
                : new Func<Disco, bool>(d => d.GeneroId == (GeneroEnum)request.FilterGenero);

            var total = _context.Disco.Count(where);

            if (total == 0)
                return Disco.ListEmpty();

            request.WithPagination(total);

            return _context.Disco
                          .Where(where)
                          .OrderBy(d => d.Nome)
                          .Skip(request.Paginacao.Skip)
                          .Take(request.Paginacao.Take)
                          .ToList();
        }

        public bool Any()
        {
            return _context.Disco.Any();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
