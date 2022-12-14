using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.Book.Search
{
    public class SearchBookHandler : IRequestHandler<SearchBookRequest, SearchBookResponse>
    {
        private readonly IBookRepository _repository;
        public SearchBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<SearchBookResponse> Handle(SearchBookRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
