using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Seed
{
    public static class DbSeed
    {
        public static List<Member> CreateMember()
        {
            var result = new List<Member>();

            for (int i = 1; i <= 10; i++)
            {
                var mmber = new Member
                {
                    Name = $"Test",
                    Surname = i.ToString(),
                    CreateDate = DateTime.Now,
                    IsActive = true,
                };

                result.Add(mmber);
            }

            return result;
        }
        public static List<Book> CreateBook()
        {
            var result = new List<Book>();

            for (int i = 1; i <= 10; i++)
            {
                var mmber = new Book
                {
                    Name = $"Test {i}",
                    Author = $"Ömer {i}",
                    CreateDate = DateTime.Now,
                    IsActive = true,
                };

                result.Add(mmber);
            }

            return result;
        }
    }
}
