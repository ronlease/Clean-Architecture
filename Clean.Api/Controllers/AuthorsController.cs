// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Features.Authors.Commands.CreateAuthor;
using Clean.Application.Features.Authors.Commands.RemoveAuthor;
using Clean.Application.Features.Authors.Commands.UpdateAuthor;
using Clean.Application.Features.Authors.Queries.GetAuthor;
using Clean.Application.Features.Authors.Queries.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class AuthorsController(IMediator mediator) : Controller
    {
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new RemoveAuthorCommand
            {
                AuthorId = id
            };
            await mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IList<AuthorsViewModel>>> Get()
        {
            var result = await mediator.Send(new GetAuthorsQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorViewModel>> Get(int id)
        {
            var query = new GetAuthorQuery
            {
                AuthorId = id
            };

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateAuthorCommand command)
        {
            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(Get), id);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateAuthorCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }
    }
}
