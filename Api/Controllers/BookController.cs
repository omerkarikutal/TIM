using Business.Cqrs.Queries.Book.Search;
using Business.Cqrs.Queries.BookTransaction.Search;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SearchBookRequest query)
        {
            return Ok(await _mediator.Send(query));
        }

    }
}
