using Application.Authors.GetAuthor;
using Application.books.AddBookCommand;
using Application.books.GetBookByIdQuery;
using Application.books.GetBooksQuery;
using Application.books.UpdateBookCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IMediator _Mediator;
        public BooksController(IMediator Mediator)
        {
            _Mediator= Mediator;
        }
        /// <summary>
        /// AddBookCommand
        /// </summary>
        /// <param name="createBook"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBookCommand(CreateBookCommand createBook)
        {
            var res =await _Mediator.Send(createBook);
            return Ok(res);
        }
        /// <summary>
        /// UpdateBookCommand
        /// </summary>
        /// <param name="updateBook"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBookCommand(UpdateBookCommand updateBook)
        {
            var res = await _Mediator.Send(updateBook);
            return Ok(res);
        }
        /// <summary>
        /// GetBooksQuery
        /// </summary>
        /// <param name="GetBooksQuery"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBooksQuery([FromQuery]GetBooksQuery GetBooksQuery)
        {
            var res = await _Mediator.Send(GetBooksQuery);
            return Ok(res);
        }
        /// <summary>
        /// GetBookByIdQuery
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{BookId}")]
        public async Task<IActionResult> GetBookByIdQuery([FromRoute] Guid BookId)
        {
            var res = await _Mediator.Send(new GetBookByIdQuery(BookId));
            return Ok(res);
        }
    
    }
}
