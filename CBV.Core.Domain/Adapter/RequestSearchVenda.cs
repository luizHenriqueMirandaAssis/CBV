using CBV.Core.Domain.Shared;
using System;
using System.Collections.Generic;

namespace CBV.Core.Domain.Adapter
{
    public class RequestSearchVenda
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int QuantidadePorPagina { get; set; }
        public int PaginaAtual { get; set; }
        public Paginacao Paginacao { get; set; }

        public static RequestSearchVenda Build(DateTime dataInicio, DateTime dataFim, int quantidade, int pagina)
        {
            return new RequestSearchVenda()
            {
                DataInicio = dataInicio,
                DataFim = dataFim,
                QuantidadePorPagina = quantidade,
                PaginaAtual = pagina
            };
        }

        public RequestSearchVenda WithPagination(int quantidadeTotal)
        {
            this.Paginacao = Paginacao.New(quantidadeTotal, this.QuantidadePorPagina, this.PaginaAtual);
            return this;
        }

        public bool IsNotValid()
        {
            return
                this.DateStartNotValid() ||
                this.DateEndNotValid();
        }

        private bool DateStartNotValid()
        {
            return this.DataInicio == DateTime.MinValue || this.DataInicio > this.DataFim;
        }

        private bool DateEndNotValid()
        {
            return this.DataFim == DateTime.MinValue || this.DataFim > DateTime.Now;
        }

        public List<string> GetValueInvalidDateString()
        {
            var list = new List<string>();

            if (!this.IsNotValid())
                return list;

            if (this.DateStartNotValid())
                list.Add("Data inicial inválida");

            if(this.DateEndNotValid())
                  list.Add("Data final inválida");

            return list;
        }

    }
}
