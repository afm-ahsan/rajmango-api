using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs;
using RajMango.Application.Features;
using RajMango.Application.Features.Commands;
using RajMango.Shared;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/courier-station")]
    public class CourierStationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourierStationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [RequirePermission(Permissions.Couriers.View)]
        public async Task<ActionResult<Result<List<CourierStationDto>>>> Get()
        {
            return await _mediator.Send(new GetAllCourierStationQuery());
        }

        [HttpGet("{id}")]
        [RequirePermission(Permissions.Couriers.View)]
        public async Task<ActionResult<Result<CourierStationDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetCourierStationByIdQuery(id));
        }

        [HttpGet("count")]
        [RequirePermission(Permissions.Couriers.View)]
        public async Task<ActionResult<Result<int>>> GetCount()
        {
            return await _mediator.Send(new GetCourierStationCountQuery());
        }

        [HttpGet("dropdown")]
        [RequirePermission(Permissions.Couriers.View)]
        public async Task<ActionResult<Result<List<CourierStationDropdownDto>>>> GetDropdown()
        {
            return await _mediator.Send(new GetCourierStationDropdownQuery());
        }

        [HttpGet("available")]
        [RequirePermission(Permissions.Couriers.View)]
        public async Task<ActionResult<Result<List<AvailableCourierStationDto>>>> GetStationsByArea([FromQuery] AvailableCourierStationQuery query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Returns active stations within radiusKm of the supplied coordinates.
        /// Public — used from the order placement page.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("nearby")]
        public async Task<ActionResult<Result<List<NearbyStationDto>>>> GetNearby(
            [FromQuery] double latitude,
            [FromQuery] double longitude,
            [FromQuery] int radiusKm = 10,
            [FromQuery] int maxResults = 10,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(
                new GetNearbyStationsQuery(latitude, longitude, radiusKm, maxResults),
                cancellationToken);
        }

        [HttpGet]
        [Route("paged")]
        [RequirePermission(Permissions.Couriers.View)]
        public async Task<ActionResult<PaginatedResult<CourierStationDto>>> GetCategoryWithPagination([FromQuery] GetCourierStationWithPaginationQuery query)
        {
            var validator = new GetCourierStationWithPaginationValidator();
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpPost]
        [RequirePermission(Permissions.Couriers.Create)]
        public async Task<ActionResult<Result<int>>> Create(CreateCourierStationCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [RequirePermission(Permissions.Couriers.Update)]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateCourierStationCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [RequirePermission(Permissions.Couriers.Delete)]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteCourierStationCommand { Id = id });
        }
    }
}
