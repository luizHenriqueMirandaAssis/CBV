using CBV.Core.Domain.Adapter;

namespace CBV.Core.Application.Interfaces.Services
{
    public interface IVendaAppService
    {
        Response GetById(int id);

        Response GetWithPagination(RequestSearchVenda request);
        Response Add(RequestVenda request);
    }
}
