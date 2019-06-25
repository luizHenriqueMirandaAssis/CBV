using CBV.Core.Application.Interfaces.Services;
using CBV.Core.Domain.Adapter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CBV.Integration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ICatalogoAppService _catalogoAppService;

        public CatalogosController(ICatalogoAppService catalogoAppService)
        {
            _catalogoAppService = catalogoAppService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public ActionResult<Response> Get(int id)
        {
            var response = _catalogoAppService.GetById(id);

            return Ok(response);
        }

        [HttpGet("Search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public ActionResult<Response> GetAll([FromQuery]int genero, [FromQuery] int pagina, [FromQuery] int quantidadePorPagina)
        {
            var request = RequestSearchCatalog.Build(genero, quantidadePorPagina, pagina);
            var response = _catalogoAppService.GetWithPagination(request);

            return Ok(response);
        }

        [HttpGet("Genero")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public ActionResult<Response> GetAllGenero()
        {
            var response = _catalogoAppService.GetAllGenero();
            return Ok(response);
        }
    }
}
