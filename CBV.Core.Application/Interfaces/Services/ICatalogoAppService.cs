using CBV.Core.Domain.Adapter;

namespace CBV.Core.Application.Interfaces.Services
{
    public interface ICatalogoAppService
    {
        Response GetById(int id);
        Response GetAllGenero();
        Response GetWithPagination(RequestSearchCatalog request);
    }
}
