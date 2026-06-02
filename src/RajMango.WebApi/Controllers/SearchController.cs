using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.Features.Search.Queries;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Global search across orders, customers (admin), courier stations (admin), and mango types.
        /// Minimum 3 characters. Returns up to maxPerSection results per section.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<Result<GlobalSearchResultDto>>> Search(
            [FromQuery] string term,
            [FromQuery] int maxPerSection = 5)
        {
            if (string.IsNullOrWhiteSpace(term) || term.Trim().Length < 3)
                return BadRequest("Search term must be at least 3 characters.");

            return await _mediator.Send(new GlobalSearchQuery
            {
                Term           = term,
                MaxPerSection  = maxPerSection,
            });
        }
    }
}
