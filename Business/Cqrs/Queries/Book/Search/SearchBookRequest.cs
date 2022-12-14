using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cqrs.Queries.Book.Search
{
    public class SearchBookRequest : IRequest<BaseResponse<List<SearchBookResponse>>>
    {
        public string Author { get; set; }
        public string? Name { get; set; }
        public string? Isbn { get; set; }

    }
}
