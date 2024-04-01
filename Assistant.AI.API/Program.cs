
namespace Assistant.AI.API;
/// <summary>
/// The entry point class for the application.
/// </summary>
public class Program
{
    /// <summary>
    /// The main method that starts the application.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add Seguridad con reglas CORS 
        var reglasCors = "ReglasCors";

        // Configure CORS policy
        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy(name: reglasCors,
            builder =>
            {
                builder.AllowAnyOrigin()
                .WithHeaders("Content-Type", "Authorization")
                .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
                .WithExposedHeaders("Authorization")
                .SetIsOriginAllowedToAllowWildcardSubdomains();
            });
        });

        // Clear default configuration sources
        builder.Configuration.Sources.Clear();

        // Add custom configuration file
        builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

        // Configure services for development environment


        // Configure database connection
        var cnnstr = builder.Configuration.GetConnectionString("cnnstr");
        builder.Services.AddDbContext<Context>(opt =>
        {
            opt.UseNpgsql(cnnstr);
        });

        // Add repository and service collections
        builder.Services.AddScopedCollections();

        // Add controllers
        builder.Services.AddControllers();

        // Add API explorer endpoints
        builder.Services.AddEndpointsApiExplorer();

        // Add Swagger documentation generation
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "OpenAI HTTP API",
                Version = "v1",
                Description = "Microservicio OpenAI HTTP API"
            });
        });

        var app = builder.Build();

        // Use CORS policy
        app.UseCors(reglasCors);

        // Map controllers
        app.MapControllers();

        // Habilitar el servicio de archivos estáticos
        app.UseDefaultFiles();
        app.UseStaticFiles();

        // Open database connection and check if it's successful
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<Context>();
            Console.WriteLine("Conectando a la base de datos...");
            try
            {
                context.Database.OpenConnection();
                context.Database.CloseConnection();
                Console.WriteLine("Conexión exitosa a la base de datos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar conectar a la base de datos: {ex.Message}");
                throw new Exception($"Error al intentar conectar a la base de datos: {ex.Message}");
            }
        }

        Console.WriteLine("OpenAI Assistant HTTP API - Initialized.");
        app.Run();
    }
}
