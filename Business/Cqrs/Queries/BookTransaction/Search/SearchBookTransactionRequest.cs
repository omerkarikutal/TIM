using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.BookTransaction.Search
{
    public class SearchBookTransactionRequest:IRequest<BaseResponse<List<SearchBookTransactionResponse>>>
    {
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }
    }
}
