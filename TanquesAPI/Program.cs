using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Agregar configuración del entorno
if (builder.Environment.IsProduction())
{
    builder.Configuration.AddJsonFile("appsettings.Production.json", optional: false, reloadOnChange: true);
}

builder.Services.AddControllers();  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{   
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Descomenta esta línea solo para desarrollo/debugging
// app.UseHttpsRedirection();

// Endpoint de prueba raíz
app.MapGet("/", () => Results.Ok(new { message = "API de Tanques funcionando correctamente", version = "1.0" }))
    .WithName("Health")
    .Produces<object>();

// app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("API iniciada en modo {Environment}", app.Environment.EnvironmentName);

app.Run();

// Ensure you have the following NuGet package installed in your project:
// Swashbuckle.AspNetCore
// You can install it using the following command in the Package Manager Console:
// Install-Package Swashbuckle.AspNetCore
