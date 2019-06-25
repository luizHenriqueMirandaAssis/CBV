using CBV.Core.Application.Interfaces.Repositories;
using CBV.Core.Application.Interfaces.Services;
using CBV.Core.Domain.Adapter;
using CBV.Core.Domain.Entities;
using CBV.Core.Domain.Shared;
using System;
using System.Linq;

namespace CBV.Core.Application.Services
{
    public class VendaAppService : IVendaAppService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IDiscoRepository _discoRepository;
        private readonly ICashbackRepository _cashbackRepository;

        public VendaAppService(IVendaRepository vendaRepository, IDiscoRepository discoRepository, ICashbackRepository cashbackRepository)
        {
            _vendaRepository = vendaRepository;
            _discoRepository = discoRepository;
            _cashbackRepository = cashbackRepository;
        }

        public Response Add(RequestVenda request)
        {
            try
            {
                #region Validations initial

                if (request.IsNotValid())
                    return Response.BuildBadRequest();

                if (request.Pedidos.Any(p => p.DiscoId <= 0))
                    return Response.BuildBadRequest(request.GetValueInvalidId());

                if (request.Pedidos.Any(p => p.Quantidade <= 0))
                    return Response.BuildBadRequest(request.GetValueInvalidQuantidade());

                #endregion

                #region Get discs

                var discos = _discoRepository.GetListById(request.GetListId());

                if (!discos.Any())
                    return Response.BuildNotFound("Discos não encontrado");

                #endregion

                #region Get percentage Cashback

                var diaSemana = DataExtensions.GetWeekCurrent();
                var listCashback = _cashbackRepository.GetByWeek(diaSemana);

                #endregion

                #region Generate venda

                #region Item

                var listItem = ItemVenda.ListEmpty();

                foreach (var item in discos)
                {
                    var itemPedido = request.Pedidos.Distinct().FirstOrDefault(x => x.DiscoId == item.DiscoId);
                    var cashback = listCashback.FirstOrDefault(c => c.GeneroId == item.GeneroId);

                    if (cashback == null)
                        return Response.BuildNotFound($"Não foi encontrado o percentual de cashback para o generoId: {item.GeneroId} e DiSemanaId: {(int)diaSemana}");

                    var itemVenda = ItemVenda.Build(item, itemPedido, cashback);
                    listItem.Add(itemVenda);
                }

                #endregion

                #region Venda

                var venda = Venda.Build(listItem);

                #endregion

                #endregion

                var data = ResponseVenda.Build(_vendaRepository.Add(venda));
                return Response.BuildSuccess(data);
            }
            catch (Exception ex)
            {
                return Response.BuildInternalServerError();
            }
        }

        public Response GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return Response.BuildBadRequest(id);

                var data = _vendaRepository.GetById(id);
                return Response.BuildSuccess(data);
            }
            catch (Exception ex)
            {
                //Realizar monitoramento (Log)
                return Response.BuildInternalServerError();
            }
        }

        public Response GetWithPagination(RequestSearchVenda request)
        {
            try
            {
                if (request.IsNotValid())
                    return Response.BuildBadRequest(null, request.GetValueInvalidDateString());

                var data = _vendaRepository.GetWithPagination(request);
                return Response.BuildSuccess(data);
            }
            catch (Exception ex)
            {
                return Response.BuildInternalServerError();
            }
        }
    }
}
