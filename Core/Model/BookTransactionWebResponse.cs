using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class BookTransactionWebResponse
    {
        public string Member { get; set; }
        public string Book { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDateString
        {
            get
            {
                return CreateDate.ToString("dd-MM-yyyy hh:mm:ss");
            }
        }
        public string ReturnDateString
        {
            get
            {
                return ReturnDate.ToString("dd-MM-yyyy hh:mm:ss");
            }
        }
        public DateTime ReturnDate { get; set; }
        public double Penalty { get; set; }

    }
}
