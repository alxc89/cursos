using Microsoft.EntityFrameworkCore;
using src.api.Infrastructure.Database.Context;

namespace ConsultorioLegal.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite("Data source=consultorio_legal.db");
            });
        }

        public static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
