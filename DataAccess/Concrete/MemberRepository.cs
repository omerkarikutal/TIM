using Core.Entity;
using Core.Repository.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class MemberRepository:EfRepository<Member>,IMemberRepository
    {
        public MemberRepository(LibraryContext context) : base(context)
        {
        }

    }
}
