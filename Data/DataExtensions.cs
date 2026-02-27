using Microsoft.EntityFrameworkCore;

namespace BookManagement.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BookContext>();
        context.Database.MigrateAsync();
    }
    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("BookContext") ?? "Server=localhost;Database=BookManagement;User=root;Password=1234;";
        builder.Services.AddDbContext<BookContext>(options =>
        options.UseMySql(connString, ServerVersion.AutoDetect(connString)));
    }
}