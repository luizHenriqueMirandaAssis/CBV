using CBV.Core.Domain.Enum;
using System.Collections.Generic;

namespace CBV.Core.Domain.Entities
{
    public class Cashback
    {
        public int CashbackId { get; set; }
        public GeneroEnum GeneroId { get; set; }
        public DiaSemanaEnum DiaSemanaId { get; set; }
        public decimal Percentual { get; set; }

        public static List<Cashback> ListEmpty() => new List<Cashback>();
        public static Cashback BuildInitial(GeneroEnum genero)
        {
            return new Cashback()
            {
                CashbackId = 0,
                GeneroId = genero
            };
        }
    }
}
