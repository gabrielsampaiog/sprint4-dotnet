namespace TAQUI.API.Configuration
{
    public class AppConfiguration
    {
        public SwaggerDoc Swagger { get; set; }

        public MongoDbConfig ClienteMongoDb { get; set; }

        public class MongoDbConfig
        {
            public string Connection { get; set; }
            public string Database { get; set; }
        }

        public class SwaggerDoc
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
        }
    }
}
