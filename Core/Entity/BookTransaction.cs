using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class BookTransaction
    {
        public int MemberId { get; set; }
        public string BookIsbn { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
