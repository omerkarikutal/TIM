using Core.Model;
using DataAccess.Abstract;
using MediatR;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public SearchBookTransactionHandler(IBookTransactionRepository repository,
            IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }
        public async Task<BaseResponse<List<SearchBookTransactionResponse>>> Handle(SearchBookTransactionRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(s => (request.FirstDate.HasValue == false || s.ReturnDate.Date >= request.FirstDate)
            && (request.SecondDate.HasValue == false || s.ReturnDate.Date <= request.SecondDate), x => x.Member, x => x.Book);





            var obj = result.Data.Select(s => new SearchBookTransactionResponse
            {
                Book = s.Book.Name,
                Member = $"{s.Member.Name} {s.Member.Surname}",
                CreateDate = s.CreateDate,
                ReturnDate = s.ReturnDate,
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
            return Math.Round(total, 2);
        }
        private double Calculate(int value)
        {
            var cr = _configuration.GetValue<float>("PenaltyCalculateValue");

            var list = FibonacciList(value);

            double total = 0;
            while (value > 0)
            {
                //appsettingsden getirilecek
                total += list[value - 1] * cr;
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
                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
                    total++;
            }
            return total;
        }
    }
}
