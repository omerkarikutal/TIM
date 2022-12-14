using Core.Entity;
using Core.Model;
using Core.Rest;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IRestService _service;
        public BookController(IRestService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Search(string bookName, string authorName, string isbn)
        {
            var result = await _service.Get<List<BookWebResponse>>(
                $"book?Author={authorName}&" +
                $"Name={bookName}&" +
                $"Isbn={isbn}");

            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddBookTransactionWebRequest request)
        {
            return Json(await _service.Post<BookTransaction>($"booktransaction", request));
        }
        [HttpGet]
        public async Task<IActionResult> MemberList()
        {
            return Json(await _service.Get<List<MemberWebResponse>>($"member"));
        }
    }
}
