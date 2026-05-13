using RajMango.Application.Features.Commands;
using RajMango.Application.Features.Queries;
using RajMango.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RajMango.Application.DTOs;
using RajMango.WebApi.Authorization;

namespace RajMango.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [RequirePermission(Permissions.Users.View)]
        public async Task<ActionResult<Result<List<AppUserDto>>>> Get()
        {
            return await _mediator.Send(new GetAllUserQuery());
        }

        [HttpGet("{id}")]
        [RequirePermission(Permissions.Users.View)]
        public async Task<ActionResult<Result<AppUserDto>>> GetById(int id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        [HttpGet("count")]
        [RequirePermission(Permissions.Users.View)]
        public async Task<ActionResult<Result<int>>> GetCount()
        {
            return await _mediator.Send(new GetUserCountQuery());
        }

        [HttpGet]
        [Route("paged")]
        [RequirePermission(Permissions.Users.View)]
        public async Task<ActionResult<PaginatedResult<AppUserDto>>> GetUserWithPagination([FromQuery] GetUserWithPaginationQuery query)
        {
            var validator = new GetUserWithPaginationValidator();

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
        //public async Task<IEnumerable<UserInformationDto>> GetPagedAndSortedResult([FromQuery] PagedAndSortedDto inputDto)
        //{
        //    try
        //    {
        //        var userInfo = await _userInformationRepository.GetAsync(filter: x => x.deleted_at == null,
        //                                                        orderBy: x => x.OrderBy(o => o.id),
        //                                                        inputDto.SkipCount,
        //                                                        inputDto.MaxResultCount);
        //        var mappedInfo = _mapper.Map<IEnumerable<UserInformationDto>>(userInfo);
        //        return mappedInfo;
        //    }
        //    catch (Exception ex)
        //    {
        //        _errorHandler.Handle(ex);
        //        throw;
        //    }
        //}

        [HttpPost]
        [RequirePermission(Permissions.Users.Create)]
        public async Task<ActionResult<Result<int>>> Create(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [RequirePermission(Permissions.Users.Update)]
        public async Task<ActionResult<Result<int>>> Put(int id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [RequirePermission(Permissions.Users.Delete)]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteUserCommand { Id = id });
        }
    }
}