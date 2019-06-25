using CBV.Core.Domain.Adapter;
using CBV.Core.Domain.Entities;
using System.Collections.Generic;

namespace CBV.Core.Application.Interfaces.Repositories
{
    public interface IDiscoRepository
    {
        void AddList(List<Disco> list);
        bool Any();
        Disco GetById(int id);
        List<Disco> GetListById(List<int> ids);
        List<Disco> GetWithPagination(RequestSearchCatalog request);
    }
}
