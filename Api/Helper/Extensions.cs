using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using MediatR;
using Business.Cqrs.Queries.Member.GetAll;
using Business.Cqrs.Queries.Book.Search;
using Business.Cqrs.Queries.BookTransaction.Search;
using Business.Cqrs.Commands.BookTransaction.Add;

namespace Api.Helper
{
    public static class Extensions
    {
        public static IServiceCollection DI(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MemberRequest));
            services.AddMediatR(typeof(SearchBookRequest));
            services.AddMediatR(typeof(SearchBookTransactionRequest));
            services.AddMediatR(typeof(AddBookTransactionRequest));

            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IBookTransactionRepository, BookTransactionRepository>();
            return services;
        }
        public static IServiceCollection DbContext(this IServiceCollection services, IConfiguration configuration)
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
