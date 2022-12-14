using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.Helper
{
    public static class Extensions
    {
        public static IServiceCollection DI(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IBookTransactionRepository, BookTransactionRepository>();
            return services;
        }
        public static IServiceCollection DbContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LibraryDb"));
            });
            return services;
        }
        public static void CreateDb(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<LibraryContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}
