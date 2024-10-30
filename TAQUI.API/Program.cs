using _2TDPM.Services.Recommendation;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using TAQUI.API.Configuration;
using TAQUI.API.Extensions;
using TAQUI.Service.ClienteViewService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = builder.Configuration;
AppConfiguration appConfiguration = new AppConfiguration();
configuration.Bind(appConfiguration);

// Sobrescreve a Connection e Database se as variáveis de ambiente estiverem definidas
appConfiguration.ClienteMongoDb.Connection = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING") ?? appConfiguration.ClienteMongoDb.Connection;
appConfiguration.ClienteMongoDb.Database = Environment.GetEnvironmentVariable("MONGODB_DATABASE") ?? appConfiguration.ClienteMongoDb.Database;

builder.Services.Configure<AppConfiguration>(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddServices();
builder.Services.AddDBContexts(appConfiguration);
builder.Services.AddSwagger(appConfiguration);
builder.Services.AddRepositories();
builder.Services.AddHealthChecks(appConfiguration);
builder.Services.AddSingleton<RecommendationEngine>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health-check", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = HealthCheckExtensions.WriteResponse
    });
});


app.Run();
