using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Commands.BookTransaction.Add
{
    public class AddBookTransactionHandler : IRequestHandler<AddBookTransactionRequest, AddBookTransactionResponse>
    {
        private readonly IBookTransactionRepository _repository;
        public AddBookTransactionHandler(IBookTransactionRepository repository)
        {
            _repository = repository;
        }
        public async Task<AddBookTransactionResponse> Handle(AddBookTransactionRequest request, CancellationToken cancellationToken)
        {
            return await _repository.AddBookTransactionAsync(request, cancellationToken);
        }
    }
}
