using CBV.Core.Domain.Shared;

namespace CBV.Core.Domain.Adapter
{
    public class RequestSearchCatalog
    {
        public int FilterGenero { get; set; }
        public int QuantidadePorPagina { get; set; }
        public int PaginaAtual { get; set; }
        public Paginacao Paginacao { get; set; }

        public static RequestSearchCatalog Build(int genero, int quantidade, int pagina)
        {
            return new RequestSearchCatalog()
            {
                FilterGenero = genero,
                QuantidadePorPagina = quantidade,
                PaginaAtual = pagina
            };
        }

        public RequestSearchCatalog WithPagination(int quantidadeTotal)
        {
            this.Paginacao = Paginacao.New(quantidadeTotal, this.QuantidadePorPagina, this.PaginaAtual);
            return this;
        }

    }
}
