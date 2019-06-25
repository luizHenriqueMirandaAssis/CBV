using System;
using CBV.Core.Application.Interfaces.Services;
using CBV.Core.Domain.Adapter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CBV.Integration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendaAppService _vendaAppService;
        public VendasController(IVendaAppService vendaAppService)
        {
            _vendaAppService = vendaAppService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public ActionResult<Response> Get(int id)
        {
            var response = _vendaAppService.GetById(id);

            return Ok(response);
        }

        [HttpGet("Search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public ActionResult<Response> GetAll([FromQuery]DateTime dataInicio, [FromQuery] DateTime dataFim, [FromQuery] int pagina, [FromQuery] int quantidadePorPagina)
        {
            var request = RequestSearchVenda.Build(dataInicio, dataFim, quantidadePorPagina, pagina);
            var response = _vendaAppService.GetWithPagination(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public ActionResult<Response> Post([FromBody] RequestVenda request)
        {
            var response = _vendaAppService.Add(request);

            return Ok(response);
        }
    }
}