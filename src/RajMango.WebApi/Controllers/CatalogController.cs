using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns all mango types enriched with today's live pricing and crate options.
        /// Publicly accessible — no login required.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<Result<List<CatalogItemDto>>>> Get()
        {
            return await _mediator.Send(new GetCatalogQuery());
        }

        /// <summary>
        /// Returns full detail for a single mango type including current pricing and crate options.
        /// Publicly accessible — no login required.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<CatalogItemDetailDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetCatalogItemQuery(id));
        }
    }
}
