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
                CreateDate = s.CreateDate,
                Penalty = s.ReturnDate < DateTime.Now ? CalculatePenalty(s.ReturnDate) : 0
            }).ToList();

            return new BaseResponse<List<SearchBookTransactionResponse>>().Success(obj);
        }
        private double CalculatePenalty(DateTime returnDate)
        {
            int days = CalculateDay(returnDate);
            double total = 0;

            if (days > 0)
            {
                total = Calculate(days);
            }
            return total;
        }
        private double Calculate(int value)
        {
            var list = FibonacciList(value);

            double total = 0;
            while (value > 0)
            {
                total += list[value] * 0.20;
                value--;
            }
            return total;
        }
        //fibonacci listesini hesaplar
        private List<int> FibonacciList(int len)
        {
            var list = new List<int>();

            if (len > 0)
                list.Add(0);
            if (len > 1)
                list.Add(1);

            if (len > 2)
            {
                int a = 0, b = 1, c = 0;
                for (int i = 2; i < len; i++)
                {
                    c = a + b;
                    list.Add(c);
                    a = b;
                    b = c;
                }
            }

            return list;
        }
        //gecikmiş gün sayısı hesaplanıyor. haftasonu çıkarılarak.
        private int CalculateDay(DateTime returnDate)
        {
            int total = 0;
            for (var i = returnDate; i <= DateTime.Now; i = i.AddDays(1))
            {
                if (i.DayOfWeek != DayOfWeek.Saturday || i.DayOfWeek != DayOfWeek.Sunday)
                    total++;
            }
            return total;
        }
    }
}
