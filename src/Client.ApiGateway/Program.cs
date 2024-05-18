using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using CacheManager.Core;
using Ocelot.Values;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", false, false);
// Add services to the container.
builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddOcelot().AddCacheManager(x => {
    x.WithDictionaryHandle("*");

});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseOcelot();

app.Run();

