using Microsoft.EntityFrameworkCore;
using MasterTechParallelMAUI.Data;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace MasterTechParallelMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().UseMauiCommunityToolkit();
            // Build a cross-platform path: AppDataDirectory/stock.db
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "stock.db");
            builder.Services.AddDbContextFactory<StockDbContext>(options =>
            {
                options.UseSqlite($"Data Source={dbPath}");
#if DEBUG
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
#endif
            });
            // Optional: a small initializer to ensure DB exists & seed
            builder.Services.AddSingleton<DbInitializer>();
            var app = builder.Build();
            // Create DB on first run
            using (var scope = app.Services.CreateScope())
            {
                var init = scope.ServiceProvider.GetRequiredService<DbInitializer>();
                init.EnsureCreatedAsync().GetAwaiter().GetResult();
            }

            return app;
        }
    }
}