using CBV.Core.Application.Interfaces.Repositories;
using CBV.Core.Domain.Entities;
using CBV.Infra.Data.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CBV.Infra.Data.EntityFramework.Repository
{
    public class DiaSemanaRepository : IDiaSemanaRepository, IDisposable
    {
        protected readonly CBVContext _context;

        public DiaSemanaRepository(CBVContext context)
        {
            _context = context;
        }
    
        public void AddList(List<DiaSemana> list)
        {
            _context.DiaSemana.AddRange(list);
            _context.SaveChanges();
        }

        public bool Any()
        {
            return _context.DiaSemana.Any();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
