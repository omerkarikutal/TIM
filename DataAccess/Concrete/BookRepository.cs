using Core.Entity;
using Core.Repository.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BookRepository : EfRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }
    }
}
