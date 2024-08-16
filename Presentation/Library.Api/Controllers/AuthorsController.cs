using Application.Authors.AddAuthorCommand;
using Application.Authors.GetAuthor;
using Application.Authors.GetAuthorBooksByAuthorId;
using Application.Authors.GetAuthorsQuery;
using Application.Authors.UpdateAuthorCommand;
using Application.books.UpdateBookCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {

        private readonly IMediator _Mediator;
        public AuthorsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }
        /// <summary>
        /// AddAuthorCommand
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateAuthorCommandResponse), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AddAuthorCommand(CreateAuthorCommand command)
        {
            var CreateAuthor = await _Mediator.Send(command);
            return Ok(CreateAuthor);
        }
        /// <summary>
        /// UpdateAuthorCommand
        /// </summary>
        /// <param name="UpdateAuthor"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(UpdateAuthorCommandResponse), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateAuthorCommand(UpdateAuthorCommand UpdateAuthor)
        {
            var UpdateAuthorCommand = await _Mediator.Send(UpdateAuthor);
            return Ok(UpdateAuthorCommand);
        }

        /// <summary>
        /// GetAuthorsQuery
        /// </summary>
        /// <param name="Author"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetAuthoresponse), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAuthorsQuery([FromQuery]GetAuthorQuery Author)
        {
            var GetAuthors = await _Mediator.Send(Author);
            return Ok(GetAuthors);
        }
        /// <summary>
        /// GetAuthorByIdQuery
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(GetAuthorResponse), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAuthorByIdQuery([FromRoute] Guid Id)
        {
            var GetAuthor = await _Mediator.Send(new GetAuthorByIdQuery(Id));
            return Ok(GetAuthor);
        }
        /// <summary>
        /// AuthorBooks
        /// </summary>
        /// <param name="AuthorId"></param>
        /// <returns></returns>
        [HttpGet("{AuthorId}/AuthorBooks")]
        [ProducesResponseType(typeof(GetAuthorBooksResponse), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AuthorBooks([FromRoute] Guid AuthorId, [FromRoute] int PageNumber, [FromRoute] int PageSize)
        {
            var CreateAuthor = await _Mediator.Send(new GetAuthorBooksQuery(AuthorId, PageNumber, PageSize));
            return Ok(CreateAuthor);
        }
    }
}
