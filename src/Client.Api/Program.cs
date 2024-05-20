using Client.Api.Configurations;
using Client.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NSwag;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

builder.Services.AddControllers();
JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
{
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    MaxDepth = 10,
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};
serializerOptions.Converters.Add(new JsonStringEnumConverter());
builder.Services.AddSingleton(s => serializerOptions);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApiDocument(options =>
{
    options.PostProcess = document =>
    {
        document.Info = new OpenApiInfo
        {
            Version = "v1",
            Title = "Client API",
            Description = "Desafio Grupo Colorado - API de Cadastros de Clientes",
            Contact = new OpenApiContact
            {
                Name = "Phillipe R. Souza",
                Url = "https://br.linkedin.com/in/phillrog"
            },
            
        };
    };
});

var app = builder.Build();

app.UseOpenApi();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseExceptionHandler(options => { });
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ClienteDbContext>();
    db.Database.Migrate();
}


app.Run();
