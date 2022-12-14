using Business.Cqrs.Queries.Book.Search;
using Business.Cqrs.Queries.Member.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new MemberRequest { IsActive = true }));
        }

    }
}
