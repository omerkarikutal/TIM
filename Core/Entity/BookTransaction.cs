using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class BookTransaction : BaseEntity
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int BookIsbn { get; set; }
        [ForeignKey("BookIsbn")]
        public virtual Book Book { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
