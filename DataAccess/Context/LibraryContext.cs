using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }



        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<BookTransaction> BookTransaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed data eklenecek
            base.OnModelCreating(modelBuilder);
        }

    }
}
