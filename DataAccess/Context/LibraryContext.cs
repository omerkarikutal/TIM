using Core.Entity;
using Core.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }



        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<BookTransaction> BookTransaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().
            //    HasKey(x => new { x.Isbn });


            //modelBuilder.Entity<Member>()
            //    .HasData(DbSeed.CreateMember());
            //modelBuilder.Entity<Book>()
            //    .HasData(DbSeed.CreateBook());



            //seed data eklenecek.
            base.OnModelCreating(modelBuilder);
        }

    }
}
