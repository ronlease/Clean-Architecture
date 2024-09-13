// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Features.Books.Commands.CreateBook;
using Clean.Application.Features.Books.Commands.RemoveBook;
using Clean.Application.Features.Books.Commands.UpdateBook;
using Clean.Application.Features.Books.Queries.GetBook;
using Clean.Application.Features.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class BooksController(IMediator mediator) : Controller
    {
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new RemoveBookCommand
            {
                BookId = id
            };
            await mediator.Send(command);

            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<IList<BooksViewModel>>> Get()
        {
            var result = await mediator.Send(new GetBooksQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookViewModel>> Get(int id)
        {
            var query = new GetBookQuery
            {
                BookId = id
            };

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateBookCommand command)
        {
            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(Get), id);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateBookCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }
    }
}
