using System.Collections.Generic;

namespace CBV.Core.Domain.Entities
{
    public class DiaSemana
    {
        public int DiaSemanaId { get; set; }
        public string Nome { get; set; }

        public static List<DiaSemana> ListEmpty() => new List<DiaSemana>();
        public static DiaSemana Build(int id, string nome)
        {
            return new DiaSemana()
            {
                DiaSemanaId = id,
                Nome = nome
            };
        }
    }
}
