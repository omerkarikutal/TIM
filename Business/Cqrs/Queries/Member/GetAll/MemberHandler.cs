using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.Member.GetAll
{
    public class MemberHandler : IRequestHandler<MemberRequest, List<MemberResponse>>
    {
        private readonly IMemberRepository _repository;
        public MemberHandler(IMemberRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<MemberResponse>> Handle(MemberRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
