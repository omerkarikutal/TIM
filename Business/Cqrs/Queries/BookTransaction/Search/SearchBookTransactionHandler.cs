using Core.Model;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.BookTransaction.Search
{
    public class SearchBookTransactionHandler : IRequestHandler<SearchBookTransactionRequest, BaseResponse<List<SearchBookTransactionResponse>>>
    {
        private readonly IBookTransactionRepository _repository;
        public SearchBookTransactionHandler(IBookTransactionRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<SearchBookTransactionResponse>>> Handle(SearchBookTransactionRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(s => s.ReturnDate.Date >= request.FirstDate
            && s.ReturnDate.Date <= request.SecondDate, x => x.Member, x => x.Book);


            var obj = result.Data.Select(s => new SearchBookTransactionResponse
            {
                Book = s.Book.Name,
                Member = $"{s.Member.Name} {s.Member.Surname}",
                CreateDate = s.CreateDate.Value
            }).ToList();

            return new BaseResponse<List<SearchBookTransactionResponse>>().Success(obj);
        }
    }
}
