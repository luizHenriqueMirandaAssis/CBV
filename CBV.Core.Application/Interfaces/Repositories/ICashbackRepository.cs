using CBV.Core.Domain.Entities;
using CBV.Core.Domain.Enum;
using System.Collections.Generic;

namespace CBV.Core.Application.Interfaces.Repositories
{
    public interface ICashbackRepository
    {
        void AddList(List<Cashback> list);
        List<Cashback> GetByWeek(DiaSemanaEnum week);
        bool Any();
    }
}
