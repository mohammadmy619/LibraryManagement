using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Library.Api;

public static class DependencyInjection
{

    
    
    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });

        return services;
    }

}
