using Microsoft.AspNetCore.Mvc;
using WriterApp.Models;
using WriterApp.Data;

namespace WriterApp.Controllers
{
    public class BookController : Controller
    {
        AllBooksFromFile bookRepository = new AllBooksFromFile();

        public IActionResult Index(Guid id)
        {
            var product = bookRepository.TryGetById(id);
            return View(product);
        }
        
    }
}
