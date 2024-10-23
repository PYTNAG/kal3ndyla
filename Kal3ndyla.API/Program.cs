using Kal3ndyla.Infrastructure.Converters;
using Kal3ndyla.Infrastructure.DI;
using Kal3ndyla.Persistence.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new TrackDurationConverter()));

var postgresConnectionString = 
    builder.Configuration.GetConnectionString("postgres") 
    ?? throw new Exception("Connection string \"postgres\" is not specified in appsettings");

var persistenceConfig = new PersistenceConfig(postgresConnectionString);
builder.Services.AddKal3ndylaInfrastructure(persistenceConfig);

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action}"
);

app.Run();
