using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.Member.GetAll
{
    public class MemberResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NameSurname
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }
    }
}
