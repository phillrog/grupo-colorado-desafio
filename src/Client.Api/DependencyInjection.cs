using Client.Api.Middlewares;
using Client.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddHttpContextAccessor();

        services.AddHealthChecks().AddDbContextCheck<ClienteDbContext>();

        services.AddExceptionHandler<ExceptionHandlerMiddleware>();

        services.AddRazorPages();

        services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        services.AddEndpointsApiExplorer();

        return services;
    }   
}
