namespace VIPGCStatPlatform.API;

class Program
{
    static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddRazorPages();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VIPGC Stat Platform API v1");
            });
        }

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(c =>
        {
            app.MapRazorPages();
            app.MapControllers();

            app.Map("/api/{**slug}", HandleApiFallback);
            app.Map("/swagger/{**slug}", HandleApiFallback);
            app.MapFallbackToFile("{**slug}", "index.html");
        });

        app.Run();
    }

    internal static Task HandleApiFallback(HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;

        return Task.CompletedTask;
    }
}