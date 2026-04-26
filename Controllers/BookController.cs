using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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

        public BookController(IBookRepository bookRep)
        {
            this.bookRepository = bookRep;
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
            bookRepository.Change(book);
            //
            return RedirectToAction("Index", new { id = id });
        }
        
        public IActionResult Save(Guid Id, string Name, string bookText, string Description)
        {
            Book book = bookRepository.TryGetById(Id);

            if(book.Name != Name)
            {
                System.IO.File.Delete("Data/"+book.Name+".txt");
                book.Name = Name;
            }
            //book.bookText = bookText;
            book.Description = Description;

            string file = "Data/" + Name + ".txt";
            System.IO.File.WriteAllText(file, bookText);

            bookRepository.Change(book);

            return RedirectToAction("Index", new { id = Id });
        }
    }
}
