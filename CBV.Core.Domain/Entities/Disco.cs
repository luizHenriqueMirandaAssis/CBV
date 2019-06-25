using CBV.Core.Domain.Enum;
using CBV.Core.Domain.ValueObjects;
using System.Collections.Generic;

namespace CBV.Core.Domain.Entities
{
    public class Disco
    {
        public int DiscoId { get; set; }
        public GeneroEnum GeneroId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Artistas { get; set; }

        public static List<Disco> ListEmpty() => new List<Disco>();

        public static Disco Build(int generoId, string nome, List<string> artistas)
        {
            return new Disco()
            {
                DiscoId = 0,
                GeneroId = (GeneroEnum)generoId,
                Nome = nome,
                Preco = DiscoPreco.GetPrice(),
                Artistas = string.Join(", ", artistas)
            };
        }

    }
}
