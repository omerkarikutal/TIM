using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class AddBookTransactionWebRequest
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
    }
}
