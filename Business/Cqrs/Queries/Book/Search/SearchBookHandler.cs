using Core.Model;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.Book.Search
{
    public class SearchBookHandler : IRequestHandler<SearchBookRequest, BaseResponse<List<SearchBookResponse>>>
    {
        private readonly IBookRepository _repository;
        public SearchBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<SearchBookResponse>>> Handle(SearchBookRequest request, CancellationToken cancellationToken)
        {
            var today = DateTime.Now;


            //gönderilen form queryi deki parametlere göre filtrelenir
            //booktransaction tablosunda bu 2 tarih arasında olmayan kitaplar alınır.
            //return date tarihinde kitapların iade olduğu varsayılıyor.
            var result = await _repository.GetAllAsync(s =>
            (string.IsNullOrEmpty(request.Author) || s.Author.ToLower().Contains(request.Author.ToLower())) &&
            (string.IsNullOrEmpty(request.Name) || s.Name.ToLower().Contains(request.Name.ToLower())) &&
            (string.IsNullOrEmpty(request.Isbn) || s.Isbn.ToString().Contains(request.Isbn)) &&
            (!s.BookTransactions.Any(a => a.CreateDate < today && a.ReturnDate > today)));

            //mapster kullanılacak
            var obj = result.Data.Select(s => new SearchBookResponse
            {
                Author = s.Author,
                Isbn = s.Isbn,
                Name = s.Name
            }).ToList();

            return new BaseResponse<List<SearchBookResponse>>().Success(obj);
        }
    }
}
