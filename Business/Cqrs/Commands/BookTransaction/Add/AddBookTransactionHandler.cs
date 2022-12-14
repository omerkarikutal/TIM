using Core.Entity;
using Core.Model;
using DataAccess.Abstract;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Commands.BookTransaction.Add
{
    public class AddBookTransactionHandler : IRequestHandler<AddBookTransactionRequest, BaseResponse<Core.Entity.BookTransaction>>
    {
        private readonly IBookTransactionRepository _repository;
        private readonly IConfiguration _configuration;
        public AddBookTransactionHandler(IBookTransactionRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }
        public async Task<BaseResponse<Core.Entity.BookTransaction>> Handle(AddBookTransactionRequest request, CancellationToken cancellationToken)
        {
            //mapster todo
            var model = new Core.Entity.BookTransaction
            {
                MemberId = request.MemberId,
                BookIsbn = request.BookId,
                ReturnDate = CalculateReturnDate(),
                CreateDate = DateTime.Now
            };

            return await _repository.AddAsync(model);
        }
        private DateTime CalculateReturnDate()
        {
            //appsettingsden getirilecek
            int control = _configuration.GetValue<int>("ReturnDateCount");
            var startDate = DateTime.Now;
            while (control > 0)
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                    control--;
                startDate = startDate.AddDays(1);
            }
            return startDate;
        }
    }
}
