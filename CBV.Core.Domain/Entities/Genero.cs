using System.Collections.Generic;

namespace CBV.Core.Domain.Entities
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nome { get; set; }

        public static List<Genero> ListEmpty() => new List<Genero>();
        public static Genero Build(int id, string nome)
        {
            return new Genero()
            {
                GeneroId = id,
                Nome = nome
            };
        }
    }
}
