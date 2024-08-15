// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Application.Features.Authors.Commands.CreateAuthor;
using Clean.Application.Features.Authors.Queries.GetAuthor;
using Clean.Application.Features.Authors.Queries.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController(IMediator mediator) : Controller
    {
        [HttpGet(Name = "GetAllAuthors")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<AuthorsViewModel>>> GetAllAuthors()
        {
            var result = await mediator.Send(new GetAuthorsQuery());

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetAuthorById")]
        public async Task<ActionResult<AuthorViewModel>> GetAuthorById(int id)
        {
            var query = new GetAuthorQuery
            {
                AuthorId = id
            };

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("AddAuthor")]
        public async Task<ActionResult<int>> Create([FromBody] CreateAuthorCommand command)
        {
            var id = await mediator.Send(command);
            return Ok(id);
        }
    }
}
