using Business.Cqrs.Commands.BookTransaction.Add;
using Business.Cqrs.Queries.BookTransaction.Search;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SearchBookTransactionRequest query)
        {
            return Ok(await _mediator.Send(query));
        }
        //validation add
        [HttpPost]
        public async Task<IActionResult> Post(AddBookTransactionRequest query)
        {
            if (ModelState.IsValid)
                return Ok(await _mediator.Send(query));

            return BadRequest($"Wrong Model");
        }
    }
}
