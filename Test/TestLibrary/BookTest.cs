using Application.books.GetBooksQuery;
using Domain.BookModel;
using Moq;
using Moq;
using Xunit;
using FluentAssertions;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.Books;
using TestLibrary.Fixtures;

namespace TestLibrary
{

    public class GetBooksHandlerTests: IClassFixture<LibraryDbContext>
    {
       
        private readonly LibraryDbContextFixture _fixture;

        public GetBooksHandlerTests(LibraryDbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_WhenBooksExist_ReturnsBooks()
        {
            // Arrange  
            var bookRepository = new BookRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
            var _sut = new GetBooksHandler(bookRepository);
            var query = new GetBooksQuery { PageNumber = 1, PageSize = 10 };
           

            // Act  
            var response = await _sut.Handle(query, CancellationToken.None);
            // Assert  
            response.Should().NotBeNull();
            // Additional assertions on the expected structure of GetBooksResponse  
        }

       
    }
}
