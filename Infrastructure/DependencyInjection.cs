using Domain.BookModel;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.Authors;
using Infrastructure.Repositories.Books;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        //services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));

        services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LibraryDbContext"));
        });

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();

        return services;
    }
}