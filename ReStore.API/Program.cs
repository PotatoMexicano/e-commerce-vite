using Microsoft.EntityFrameworkCore;
using ReStore.API.Middleware;
using ReStore.Infra.Data.Context;
using ReStore.Infra.IoC;
using ReStore.Infra.IoC.Initializers;

internal class Program
{
    private static void Main(String[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddCors();

        builder.Services.AddInfraestructure(builder.Configuration);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        //app.UseDeveloperExceptionPage();
        app.UseMiddleware<ExceptionMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(opt =>
        {
            opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
        });

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        IServiceScope scope = app.Services.CreateScope();
        StoreContext context = scope.ServiceProvider.GetRequiredService<StoreContext>();
        ILogger<Program> logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        
        try
        {
            context.Database.Migrate();
            ProductsInitializer.Initialize(context);
        }
        catch (System.Exception ex)
        {
            logger.LogError(ex, "A problem occurred during migration");
        }

        app.Run();
    }
}