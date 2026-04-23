using Microsoft.AspNetCore.Mvc;
using OnLineShop2026.Data;
using WriterApp.Data;
using WriterApp.Models;

namespace WriterApp.Controllers
{
    public class BookController : Controller
    {
        IBookRepository bookRepository;

        public IActionResult Index(Guid id)
        {
            var book = bookRepository.TryGetById(id);
            return View(book);
        }

        public BookController(IBookRepository prodRep)
        {
            this.bookRepository = prodRep;
        }
        public IActionResult Redact(Guid id)
        {
            var book = bookRepository.TryGetById(id);
            return View(book);
        }

        public IActionResult ChangeStatus(Guid id)
        {
            var book = bookRepository.TryGetById(id);
            book.IsDone = !book.IsDone;

            return RedirectToAction("Index", new { id = id });
        }
        
    }
}
