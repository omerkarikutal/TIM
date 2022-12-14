using Core.Model;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.Member.GetAll
{
    public class MemberHandler : IRequestHandler<MemberRequest, BaseResponse<List<MemberResponse>>>
    {
        private readonly IMemberRepository _repository;
        public MemberHandler(IMemberRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<MemberResponse>>> Handle(MemberRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(s => s.IsActive == request.IsActive);
            //mapster
            var obj = result.Data.Select(s => new MemberResponse { Id = s.Id, Name = s.Name, Surname = s.Surname }).ToList();
            return new BaseResponse<List<MemberResponse>>().Success(obj);
        }
    }
}
