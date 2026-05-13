using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [RequirePermission(Permissions.Roles.View)]
        public async Task<ActionResult<Result<List<GetAllRoleDto>>>> Get()
        {
            return await _mediator.Send(new GetAllRoleQuery());
        }

        [HttpGet("{id}")]
        [RequirePermission(Permissions.Roles.View)]
        public async Task<ActionResult<Result<GetRoleByIdDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetRoleByIdQuery(id));
        }

        [HttpGet("count")]
        [RequirePermission(Permissions.Roles.View)]
        public async Task<ActionResult<Result<GetRoleCountDto>>> GetCount()
        {
            return await _mediator.Send(new GetRoleCountQuery());
        }

        [HttpGet]
        [Route("paged")]
        [RequirePermission(Permissions.Roles.View)]
        public async Task<ActionResult<PaginatedResult<GetRoleWithPaginationDto>>> GetRoleWithPagination([FromQuery] GetRoleWithPaginationQuery query)
        {
            var validator = new GetRoleWithPaginationValidator();

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
        //public async Task<IEnumerable<RoleInformationDto>> GetPagedAndSortedResult([FromQuery] PagedAndSortedDto inputDto)
        //{
        //    try
        //    {
        //        var userInfo = await _userInformationRepository.GetAsync(filter: x => x.deleted_at == null,
        //                                                        orderBy: x => x.OrderBy(o => o.id),
        //                                                        inputDto.SkipCount,
        //                                                        inputDto.MaxResultCount);
        //        var mappedInfo = _mapper.Map<IEnumerable<RoleInformationDto>>(userInfo);
        //        return mappedInfo;
        //    }
        //    catch (Exception ex)
        //    {
        //        _errorHandler.Handle(ex);
        //        throw;
        //    }
        //}

        [HttpPost]
        [RequirePermission(Permissions.Roles.Create)]
        public async Task<ActionResult<Result<int>>> Create(CreateRoleCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [RequirePermission(Permissions.Roles.Update)]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateRoleCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [RequirePermission(Permissions.Roles.Delete)]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteRoleCommand { Id = id });
        }
    }
}