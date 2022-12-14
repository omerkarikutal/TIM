using Core.Model;
using Core.Rest;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BookTransactionController : Controller
    {
        private readonly IRestService _service;
        public BookTransactionController(IRestService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Search(string first, string second)
        {
            var parseFirst = DateTime.Parse(first);
            var parseSecond = DateTime.Parse(second);


            return Json(await _service.Get<List<BookTransactionWebResponse>>($"booktransaction?FirstDate={first}&SecondDate={second}"));
        }
    }
}
