using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.Member.GetAll
{
    public class MemberRequest
    {
        public bool IsActive { get; set; }
    }
}
