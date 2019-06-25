using CBV.Core.Domain.Entities;
using System.Collections.Generic;

namespace CBV.Core.Application.Interfaces.Repositories
{
    public interface IDiaSemanaRepository
    {
        void AddList(List<DiaSemana> list);
        bool Any();
    }
}
