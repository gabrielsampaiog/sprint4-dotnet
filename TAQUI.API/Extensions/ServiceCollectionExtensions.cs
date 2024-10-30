using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TAQUI.API.Configuration;
using TAQUI.Database;
using TAQUI.Model;
using TAQUI.Repository;
using TAQUI.Service.CEP;


namespace TAQUI.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddDBContexts(this IServiceCollection service, AppConfiguration appConfiguration)
        {

            service.AddDbContext<FIAPMongoDBContext>(options =>
            {
                options.UseMongoDB(appConfiguration.ClienteMongoDb.Connection, appConfiguration.ClienteMongoDb.Database);
            });

            return service;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<ICEPService, CEPService>();
            service.AddScoped<IRepository<Cliente>, MongoDbRepository<Cliente>>();
            service.AddScoped<IRepository<Produto>, MongoDbRepository<Produto>>();
            service.AddScoped<IRepository<ClienteView>, MongoDbRepository<ClienteView>>();


            return service;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection service, AppConfiguration appConfiguration)
        {

            service.AddSwaggerGen(swagger =>
            {
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = appConfiguration.Swagger.Title,
                    Version = "v1",
                    Description = appConfiguration.Swagger.Description,
                    Contact = new OpenApiContact()
                    {
                        Email = appConfiguration.Swagger.Email,
                        Name = appConfiguration.Swagger.Name
                    }
                }
                );

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                swagger.IncludeXmlComments(xmlPath);
            });

            return service;
        }

        
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, AppConfiguration appConfiguration)
        {
            services
            .AddHealthChecks()
                .AddMongoDb(appConfiguration.ClienteMongoDb.Connection)
                .AddUrlGroup(new Uri("https://viacep.com.br/ws/08737-290/json/"), name: "VIAP CEP");


            return services;
        }
        
    }
}
