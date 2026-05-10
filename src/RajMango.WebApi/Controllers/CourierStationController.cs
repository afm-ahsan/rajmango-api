using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs;
using RajMango.Application.Features;
using RajMango.Application.Features.Commands;
using RajMango.Shared;

namespace RajMango.WebApi.Controllers
{
    [Authorize(Roles = "system_admin,admin")]
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
        public async Task<ActionResult<Result<List<CourierStationDto>>>> Get()
        {
            return await _mediator.Send(new GetAllCourierStationQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<CourierStationDto>>> GetById(int id) 
        {
            return await _mediator.Send(new GetCourierStationByIdQuery(id));
        }

        [HttpGet("count")]
        public async Task<ActionResult<Result<int>>> GetCount()
        {
            return await _mediator.Send(new GetCourierStationCountQuery());
        }

        [HttpGet("dropdown")]
        public async Task<ActionResult<Result<List<CourierStationDropdownDto>>>> GetDropdown()
        {
            return await _mediator.Send(new GetCourierStationDropdownQuery());
        }

        [HttpGet("available")]
        public async Task<ActionResult<Result<List<AvailableCourierStationDto>>>> GetStationsByArea([FromQuery] AvailableCourierStationQuery query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Returns active stations within radiusKm of the supplied coordinates, sorted by distance.
        /// No authentication required — used from the order placement page.
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
        public async Task<ActionResult<PaginatedResult<CourierStationDto>>> GetCategoryWithPagination([FromQuery] GetCourierStationWithPaginationQuery query)
        {
            var validator = new GetCourierStationWithPaginationValidator();

            // Call Validate or ValidateAsync and pass the object which needs to be validated
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        //[HttpGet]
        //[Route("GetPagedAndSortedResult")]
        //public async Task<IEnumerable<CategoryInformationDto>> GetPagedAndSortedResult([FromQuery] PagedAndSortedDto inputDto)
        //{
        //    try
        //    {
        //        var userInfo = await _userInformationRepository.GetAsync(filter: x => x.deleted_at == null,
        //                                                        orderBy: x => x.OrderBy(o => o.id),
        //                                                        inputDto.SkipCount,
        //                                                        inputDto.MaxResultCount);
        //        var mappedInfo = _mapper.Map<IEnumerable<CategoryInformationDto>>(userInfo);
        //        return mappedInfo;
        //    }
        //    catch (Exception ex)
        //    {
        //        _errorHandler.Handle(ex);
        //        throw;
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateCourierStationCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateCourierStationCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteCourierStationCommand { Id = id });
        }
    }
}