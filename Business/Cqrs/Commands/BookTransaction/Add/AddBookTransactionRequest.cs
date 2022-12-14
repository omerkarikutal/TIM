using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Commands.BookTransaction.Add
{
    public class AddBookTransactionRequest
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
