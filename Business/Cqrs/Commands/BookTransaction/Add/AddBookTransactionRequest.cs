using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Commands.BookTransaction.Add
{
    public class AddBookTransactionRequest: IRequest<BaseResponse<Core.Entity.BookTransaction>>
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
