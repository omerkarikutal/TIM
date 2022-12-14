using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.BookTransaction.Search
{
    public class SearchBookTransactionResponse
    {
        public string Member { get; set; }
        public string Book { get; set; }
        public DateTime CreateDate { get; set; }
        public double Penalty { get; set; }
    }
}
