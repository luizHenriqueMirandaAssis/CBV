using System;
using System.Runtime.Serialization;

namespace CBV.Core.Domain.Shared
{
    public class Paginacao
    {
        private readonly int _qtdTotal = 0;
        private readonly int _porPagina = 0;
        private int _paginaAtual = 0;
        private int _paginas = 0;
        private int _skip = 0;

        public Paginacao(int qtdTotal, int porPagina, int? paginaAtual)
        {
            if (porPagina <= 0)
                porPagina = 50;

            _qtdTotal = qtdTotal;
            _porPagina = porPagina;
            _paginaAtual = paginaAtual ?? 1;

            _paginas = Convert.ToInt32(Math.Ceiling((double)_qtdTotal / (double)_porPagina));

            if (_paginaAtual <= 0 || _paginaAtual > _paginas)
                _paginaAtual = _paginas;

            CalcSkip();
        }

        public int Skip { get { return _skip; } }
        public int Take { get { return _porPagina; } }
        [DataMember]
        public int QtdPaginas { get { return _paginas; } }
        [DataMember]
        public int QtdTotalRegistros { get { return _qtdTotal; } }
        [DataMember]
        public int PaginaAtual { get { return _paginaAtual; } }

        public static Paginacao New(int qtdTotal, int porPagina, int? paginaAtual)
        {
            return new Paginacao(qtdTotal, porPagina, paginaAtual);
        }

        private void CalcSkip()
        {
            _skip = (_paginaAtual - 1) * _porPagina;
        }

        public void NextPage()
        {
            _paginaAtual++;
            CalcSkip();
        }
    }
}
