using CBV.Core.Application.Interfaces.Repositories;
using CBV.Core.Domain.Entities;
using CBV.Core.Domain.Enum;
using CBV.Infra.Data.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CBV.Infra.Data.EntityFramework.Repository
{
    public class CashbackRepository : ICashbackRepository, IDisposable
    {
        protected readonly CBVContext _context;

        public CashbackRepository(CBVContext context)
        {
            _context = context;
        }

        public void AddList(List<Cashback> list)
        {
            _context.Cashback.AddRange(list);
            _context.SaveChanges();
        }

        public List<Cashback> GetByWeek(DiaSemanaEnum week)
        {
            return _context.Cashback.Where(c => c.DiaSemanaId == week).ToList();
        }

        public bool Any()
        {
            return _context.Cashback.Any();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

      
    }
}
