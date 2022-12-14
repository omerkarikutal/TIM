using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.BookTransaction.Search
{
    public class SearchBookTransactionHandler : IRequestHandler<Nullable, List<object>>
    {
        public Task<List<object>> Handle(Nullable request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
