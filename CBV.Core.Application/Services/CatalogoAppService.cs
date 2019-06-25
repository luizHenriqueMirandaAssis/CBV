using CBV.Core.Application.Interfaces.Repositories;
using CBV.Core.Application.Interfaces.Services;
using CBV.Core.Domain.Adapter;
using System;

namespace CBV.Core.Application.Services
{
    public class CatalogoAppService : ICatalogoAppService
    {
        private readonly IDiscoRepository _discoRepository;
        private readonly IGeneroRepository _generoRepository;

        public CatalogoAppService(IDiscoRepository discoRepository,
            IGeneroRepository generoRepository)
        {
            _discoRepository = discoRepository;
            _generoRepository = generoRepository;
        }

        public Response GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return Response.BuildBadRequest(id);

                var data = _discoRepository.GetById(id);
                return Response.BuildSuccess(data);
            }
            catch (Exception ex)
            {
                //Realizar monitoramento (Log)
                return Response.BuildInternalServerError();
            }
        }

        public Response GetAllGenero()
        {
            try
            {
                var data = _generoRepository.GetAll();
                return Response.BuildSuccess(data);
            }
            catch (Exception)
            {
                return Response.BuildInternalServerError();
            }
        }

        public Response GetWithPagination(RequestSearchCatalog request)
        {
            try
            {
                var data = _discoRepository.GetWithPagination(request);
                return Response.BuildSuccess(data);
            }
            catch (Exception ex)
            {
                return Response.BuildInternalServerError();
            }
        }
    }
}
