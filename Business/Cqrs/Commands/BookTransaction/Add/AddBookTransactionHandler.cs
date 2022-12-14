using Core.Entity;
using Core.Model;
using DataAccess.Abstract;
using MediatR;
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
        public AddBookTransactionHandler(IBookTransactionRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<Core.Entity.BookTransaction>> Handle(AddBookTransactionRequest request, CancellationToken cancellationToken)
        {
            //mapster todo
            var model = new Core.Entity.BookTransaction
            {
                MemberId = request.MemberId,
                BookIsbn = request.BookId,
                ReturnDate = request.ReturnDate,
                CreateDate = DateTime.Now
            };

            return await _repository.AddAsync(model);
        }
    }
}
