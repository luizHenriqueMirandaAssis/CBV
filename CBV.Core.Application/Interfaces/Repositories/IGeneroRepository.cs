using CBV.Core.Domain.Entities;
using System.Collections.Generic;

namespace CBV.Core.Application.Interfaces.Repositories
{
    public interface IGeneroRepository
    {
        void AddList(List<Genero> list);
        List<Genero> GetAll();
        bool Any();
    }
}
