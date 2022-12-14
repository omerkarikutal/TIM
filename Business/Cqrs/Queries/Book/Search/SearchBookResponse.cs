using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.Book.Search
{
    public class SearchBookResponse
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
